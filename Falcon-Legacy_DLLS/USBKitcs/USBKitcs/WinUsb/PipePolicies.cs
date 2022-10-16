// Decompiled with JetBrains decompiler
// Type: USBKitcs.WinUsb.PipePolicies
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;
using USBKitcs.Main;
using USBKitcs.WinUsb.Internal;

namespace USBKitcs.WinUsb
{
  public class PipePolicies
  {
    private const int MAX_SIZE = 4;
    private readonly byte mEpNum;
    private readonly SafeHandle mUsbHandle;
    private IntPtr mBufferPtr = IntPtr.Zero;

    internal PipePolicies(SafeHandle usbHandle, byte epNum)
    {
      this.mBufferPtr = Marshal.AllocCoTaskMem(4);
      this.mEpNum = epNum;
      this.mUsbHandle = usbHandle;
    }

    public bool AllowPartialReads
    {
      get
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, (byte) 0);
        return this.GetPipePolicy(PipePolicyType.AllowPartialReads, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
      }
      set
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
        this.SetPipePolicy(PipePolicyType.AllowPartialReads, valueLength, this.mBufferPtr);
      }
    }

    public bool ShortPacketTerminate
    {
      get
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, (byte) 0);
        return this.GetPipePolicy(PipePolicyType.ShortPacketTerminate, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
      }
      set
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
        this.SetPipePolicy(PipePolicyType.ShortPacketTerminate, valueLength, this.mBufferPtr);
      }
    }

    public bool AutoClearStall
    {
      get
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, (byte) 0);
        return this.GetPipePolicy(PipePolicyType.AutoClearStall, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
      }
      set
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
        this.SetPipePolicy(PipePolicyType.AutoClearStall, valueLength, this.mBufferPtr);
      }
    }

    public bool AutoFlush
    {
      get
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, (byte) 0);
        return this.GetPipePolicy(PipePolicyType.AutoFlush, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
      }
      set
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
        this.SetPipePolicy(PipePolicyType.AutoFlush, valueLength, this.mBufferPtr);
      }
    }

    public bool IgnoreShortPackets
    {
      get
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, (byte) 0);
        return this.GetPipePolicy(PipePolicyType.IgnoreShortPackets, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
      }
      set
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
        this.SetPipePolicy(PipePolicyType.IgnoreShortPackets, valueLength, this.mBufferPtr);
      }
    }

    public bool RawIo
    {
      get
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, (byte) 0);
        return this.GetPipePolicy(PipePolicyType.RawIo, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
      }
      set
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
        this.SetPipePolicy(PipePolicyType.RawIo, valueLength, this.mBufferPtr);
      }
    }

    public int PipeTransferTimeout
    {
      get
      {
        int valueLength = 4;
        Marshal.WriteInt32(this.mBufferPtr, 0);
        return this.GetPipePolicy(PipePolicyType.PipeTransferTimeout, ref valueLength, this.mBufferPtr) ? Marshal.ReadInt32(this.mBufferPtr) : -1;
      }
      set
      {
        int valueLength = 4;
        Marshal.WriteInt32(this.mBufferPtr, value);
        this.SetPipePolicy(PipePolicyType.PipeTransferTimeout, valueLength, this.mBufferPtr);
      }
    }

    public int MaxTransferSize
    {
      get
      {
        int valueLength = 4;
        Marshal.WriteInt32(this.mBufferPtr, 0);
        return this.GetPipePolicy(PipePolicyType.MaximumTransferSize, ref valueLength, this.mBufferPtr) ? Marshal.ReadInt32(this.mBufferPtr) : -1;
      }
    }

    public override string ToString() => string.Format("AllowPartialReads:{0}\r\nShortPacketTerminate:{1}\r\nAutoClearStall:{2}\r\nAutoFlush:{3}\r\nIgnoreShortPackets:{4}\r\nRawIO:{5}\r\nPipeTransferTimeout:{6}\r\nMaxTransferSize:{7}\r\n", (object) this.AllowPartialReads, (object) this.ShortPacketTerminate, (object) this.AutoClearStall, (object) this.AutoFlush, (object) this.IgnoreShortPackets, (object) this.RawIo, (object) this.PipeTransferTimeout, (object) this.MaxTransferSize);

    internal bool GetPipePolicy(PipePolicyType policyType, ref int valueLength, IntPtr pBuffer)
    {
      bool pipePolicy = WinUsbAPI.WinUsb_GetPipePolicy(this.mUsbHandle, this.mEpNum, policyType, ref valueLength, pBuffer);
      if (!pipePolicy)
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (GetPipePolicy), (object) this);
      return pipePolicy;
    }

    internal bool SetPipePolicy(PipePolicyType policyType, int valueLength, IntPtr pBuffer)
    {
      bool flag = WinUsbAPI.WinUsb_SetPipePolicy(this.mUsbHandle, this.mEpNum, policyType, valueLength, pBuffer);
      if (!flag)
        UsbError.Error(ErrorCode.Win32Error, Marshal.GetLastWin32Error(), nameof (SetPipePolicy), (object) this);
      return flag;
    }

    ~PipePolicies()
    {
      if (this.mBufferPtr != IntPtr.Zero)
        Marshal.FreeCoTaskMem(this.mBufferPtr);
      this.mBufferPtr = IntPtr.Zero;
    }
  }
}
