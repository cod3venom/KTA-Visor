// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbKernelVersion
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;

namespace USBKitcs.Main
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct UsbKernelVersion
  {
    public readonly int Major;
    public readonly int Minor;
    public readonly int Micro;
    public readonly int Nano;
    public readonly int BcdLibUsbDotNetKernelMod;

    public bool IsEmpty => this.Major == 0 && this.Minor == 0 && this.Micro == 0 && this.Nano == 0;

    internal UsbKernelVersion(
      int major,
      int minor,
      int micro,
      int nano,
      int bcdLibUsbDotNetKernelMod)
    {
      this.Major = major;
      this.Minor = minor;
      this.Micro = micro;
      this.Nano = nano;
      this.BcdLibUsbDotNetKernelMod = bcdLibUsbDotNetKernelMod;
    }

    public override string ToString() => string.Format("{0}.{1}.{2}.{3}", (object) this.Major, (object) this.Minor, (object) this.Micro, (object) this.Nano);
  }
}
