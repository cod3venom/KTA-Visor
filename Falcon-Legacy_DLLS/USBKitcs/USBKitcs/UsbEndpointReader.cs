// Decompiled with JetBrains decompiler
// Type: USBKitcs.UsbEndpointReader
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using USBKitcs.Internal;
using USBKitcs.Main;

namespace USBKitcs
{
  public class UsbEndpointReader : UsbEndpointBase
  {
    private static int mDefReadBufferSize = 4096;
    private bool mDataReceivedEnabled;
    private int mReadBufferSize;
    private Thread mReadThread;
    private ThreadPriority mReadThreadPriority = ThreadPriority.Normal;

    internal UsbEndpointReader(
      UsbDevice usbDevice,
      int readBufferSize,
      ReadEndpointID readEndpointID,
      EndpointType endpointType)
      : base(usbDevice, (byte) readEndpointID, endpointType)
    {
      this.mReadBufferSize = readBufferSize;
    }

    public static int DefReadBufferSize
    {
      get => UsbEndpointReader.mDefReadBufferSize;
      set => UsbEndpointReader.mDefReadBufferSize = value;
    }

    public virtual bool DataReceivedEnabled
    {
      get => this.mDataReceivedEnabled;
      set
      {
        if (value == this.mDataReceivedEnabled)
          return;
        this.StartStopReadThread();
      }
    }

    public int ReadBufferSize
    {
      get => this.mReadBufferSize;
      set => this.mReadBufferSize = value;
    }

    public ThreadPriority ReadThreadPriority
    {
      get => this.mReadThreadPriority;
      set => this.mReadThreadPriority = value;
    }

    public virtual ErrorCode Read(byte[] buffer, int timeout, out int transferLength) => this.Read(buffer, 0, buffer.Length, timeout, out transferLength);

    public virtual ErrorCode Read(
      IntPtr buffer,
      int offset,
      int count,
      int timeout,
      out int transferLength)
    {
      return this.Transfer(buffer, offset, count, timeout, out transferLength);
    }

    public virtual ErrorCode Read(
      byte[] buffer,
      int offset,
      int count,
      int timeout,
      out int transferLength)
    {
      return this.Transfer((object) buffer, offset, count, timeout, out transferLength);
    }

    public virtual ErrorCode Read(
      object buffer,
      int offset,
      int count,
      int timeout,
      out int transferLength)
    {
      return this.Transfer(buffer, offset, count, timeout, out transferLength);
    }

    public virtual ErrorCode Read(object buffer, int timeout, out int transferLength) => this.Transfer(buffer, 0, Marshal.SizeOf(buffer), timeout, out transferLength);

    public virtual ErrorCode ReadFlush()
    {
      byte[] buffer = new byte[64];
      int num = 0;
      while (this.Read(buffer, 10, out int _) == ErrorCode.None && num < 128)
        ++num;
      return ErrorCode.None;
    }

    private static void ReadData(object context)
    {
      UsbTransfer usbTransfer = (UsbTransfer) context;
      UsbEndpointReader endpointBase = (UsbEndpointReader) usbTransfer.EndpointBase;
      endpointBase.mDataReceivedEnabled = true;
      EventHandler<DataReceivedEnabledChangedEventArgs> receivedEnabledChanged1 = endpointBase.DataReceivedEnabledChanged;
      if (receivedEnabledChanged1 != null)
        receivedEnabledChanged1((object) endpointBase, new DataReceivedEnabledChangedEventArgs(endpointBase.mDataReceivedEnabled));
      usbTransfer.Reset();
      byte[] numArray = new byte[endpointBase.mReadBufferSize];
      try
      {
        while (!usbTransfer.IsCancelled)
        {
          int transferLength;
          switch (endpointBase.Transfer((object) numArray, 0, numArray.Length, -1, out transferLength))
          {
            case ErrorCode.IoTimedOut:
              continue;
            case ErrorCode.None:
              EventHandler<EndpointDataEventArgs> dataReceived = endpointBase.DataReceived;
              if (dataReceived != null && !usbTransfer.IsCancelled)
              {
                dataReceived((object) endpointBase, new EndpointDataEventArgs(numArray, transferLength));
                continue;
              }
              continue;
            default:
              return;
          }
        }
      }
      catch (ThreadAbortException ex)
      {
        UsbError.Error(ErrorCode.ReceiveThreadTerminated, 0, "ReadData:Read thread aborted.", (object) endpointBase);
      }
      finally
      {
        endpointBase.Abort();
        endpointBase.mDataReceivedEnabled = false;
        EventHandler<DataReceivedEnabledChangedEventArgs> receivedEnabledChanged2 = endpointBase.DataReceivedEnabledChanged;
        if (receivedEnabledChanged2 != null)
          receivedEnabledChanged2((object) endpointBase, new DataReceivedEnabledChangedEventArgs(endpointBase.mDataReceivedEnabled));
      }
    }

    private void StartReadThread()
    {
      this.mReadThread = new Thread(new ParameterizedThreadStart(UsbEndpointReader.ReadData));
      this.mReadThread.Priority = this.ReadThreadPriority;
      this.mReadThread.Start((object) this.TransferContext);
      Thread.Sleep(1);
      Application.DoEvents();
    }

    private bool StopReadThread()
    {
      this.Abort();
      Thread.Sleep(1);
      Application.DoEvents();
      DateTime now = DateTime.Now;
      while (this.mReadThread.IsAlive && (DateTime.Now - now).TotalSeconds < 5.0)
      {
        Thread.Sleep(100);
        Application.DoEvents();
      }
      if (!this.mReadThread.IsAlive)
        return true;
      UsbError.Error(ErrorCode.ReceiveThreadTerminated, 0, "Failed stopping read thread.", (object) this);
      this.mReadThread.Abort();
      return false;
    }

    private void StartStopReadThread()
    {
      if (this.IsDisposed)
        throw new ObjectDisposedException(this.GetType().FullName);
      if (this.mDataReceivedEnabled)
        this.StopReadThread();
      else
        this.StartReadThread();
    }

    public virtual event EventHandler<EndpointDataEventArgs> DataReceived;

    public virtual event EventHandler<DataReceivedEnabledChangedEventArgs> DataReceivedEnabledChanged;

    internal override UsbTransfer CreateTransferContext() => (UsbTransfer) new OverlappedTransferContext((UsbEndpointBase) this);
  }
}
