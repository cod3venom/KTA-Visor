// Decompiled with JetBrains decompiler
// Type: USBKitcs.WinUsb.PowerPolicies
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;

namespace USBKitcs.WinUsb
{
  public class PowerPolicies
  {
    private const int MAX_SIZE = 4;
    private readonly WinUsbDevice mUsbDevice;
    private IntPtr mBufferPtr = IntPtr.Zero;

    internal PowerPolicies(WinUsbDevice usbDevice)
    {
      this.mBufferPtr = Marshal.AllocCoTaskMem(4);
      this.mUsbDevice = usbDevice;
    }

    public bool AutoSuspend
    {
      get
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, (byte) 0);
        return this.mUsbDevice.GetPowerPolicy(PowerPolicyType.AutoSuspend, ref valueLength, this.mBufferPtr) && Marshal.ReadByte(this.mBufferPtr) != (byte) 0;
      }
      set
      {
        int valueLength = 1;
        Marshal.WriteByte(this.mBufferPtr, value ? (byte) 1 : (byte) 0);
        this.mUsbDevice.SetPowerPolicy(PowerPolicyType.AutoSuspend, valueLength, this.mBufferPtr);
      }
    }

    public int SuspendDelay
    {
      get
      {
        int valueLength = Marshal.SizeOf(typeof (int));
        Marshal.WriteInt32(this.mBufferPtr, 0);
        return this.mUsbDevice.GetPowerPolicy(PowerPolicyType.SuspendDelay, ref valueLength, this.mBufferPtr) ? Marshal.ReadInt32(this.mBufferPtr) : -1;
      }
      set
      {
        int valueLength = Marshal.SizeOf(typeof (int));
        Marshal.WriteInt32(this.mBufferPtr, value);
        this.mUsbDevice.SetPowerPolicy(PowerPolicyType.SuspendDelay, valueLength, this.mBufferPtr);
      }
    }

    ~PowerPolicies()
    {
      if (this.mBufferPtr != IntPtr.Zero)
        Marshal.FreeCoTaskMem(this.mBufferPtr);
      this.mBufferPtr = IntPtr.Zero;
    }
  }
}
