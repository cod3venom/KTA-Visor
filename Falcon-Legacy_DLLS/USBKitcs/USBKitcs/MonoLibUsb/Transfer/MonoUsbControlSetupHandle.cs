// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Transfer.MonoUsbControlSetupHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb.Transfer
{
  public class MonoUsbControlSetupHandle : SafeContextHandle
  {
    private MonoUsbControlSetup mSetupPacket;

    public MonoUsbControlSetupHandle(
      byte requestType,
      byte request,
      short value,
      short index,
      object data,
      int length)
      : this(requestType, request, value, index, (short) (ushort) length)
    {
      if (data == null)
        return;
      this.mSetupPacket.SetData(data, 0, length);
    }

    public MonoUsbControlSetupHandle(
      byte requestType,
      byte request,
      short value,
      short index,
      short length)
      : base(IntPtr.Zero, true)
    {
      ushort num1 = (ushort) length;
      int cb = num1 <= (ushort) 0 ? MonoUsbControlSetup.SETUP_PACKET_SIZE : MonoUsbControlSetup.SETUP_PACKET_SIZE + (int) num1 + (IntPtr.Size - (int) num1 % IntPtr.Size);
      IntPtr num2 = Marshal.AllocHGlobal(cb);
      if (num2 == IntPtr.Zero)
        throw new OutOfMemoryException(string.Format("Marshal.AllocHGlobal failed allocating {0} bytes", (object) cb));
      this.SetHandle(num2);
      this.mSetupPacket = new MonoUsbControlSetup(num2);
      this.mSetupPacket.RequestType = requestType;
      this.mSetupPacket.Request = request;
      this.mSetupPacket.Value = value;
      this.mSetupPacket.Index = index;
      this.mSetupPacket.Length = (short) num1;
    }

    public MonoUsbControlSetup ControlSetup => this.mSetupPacket;

    protected override bool ReleaseHandle()
    {
      if (!this.IsInvalid)
      {
        Marshal.FreeHGlobal(this.handle);
        this.SetHandleAsInvalid();
        Debug.Print(this.GetType().Name + " : ReleaseHandle");
      }
      return true;
    }
  }
}
