// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Descriptors.MonoUsbInterface
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace USBKitcs.MonoLibUsb.Descriptors
{
  [StructLayout(LayoutKind.Sequential)]
  public class MonoUsbInterface
  {
    private IntPtr pAltSetting;
    public readonly int num_altsetting;

    public List<MonoUsbAltInterfaceDescriptor> AltInterfaceList
    {
      get
      {
        List<MonoUsbAltInterfaceDescriptor> altInterfaceList = new List<MonoUsbAltInterfaceDescriptor>();
        for (int index = 0; index < this.num_altsetting; ++index)
        {
          IntPtr ptr = new IntPtr(this.pAltSetting.ToInt64() + (long) (Marshal.SizeOf(typeof (MonoUsbAltInterfaceDescriptor)) * index));
          MonoUsbAltInterfaceDescriptor structure = new MonoUsbAltInterfaceDescriptor();
          Marshal.PtrToStructure<MonoUsbAltInterfaceDescriptor>(ptr, structure);
          altInterfaceList.Add(structure);
        }
        return altInterfaceList;
      }
    }
  }
}
