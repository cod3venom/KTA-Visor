// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbRegDeviceList
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace USBKitcs.Main
{
  public class UsbRegDeviceList : IEnumerable<UsbRegistry>, IEnumerable
  {
    private readonly List<UsbRegistry> mUsbRegistryList;

    public UsbRegDeviceList() => this.mUsbRegistryList = new List<UsbRegistry>();

    private UsbRegDeviceList(IEnumerable<UsbRegistry> usbRegDeviceList) => this.mUsbRegistryList = new List<UsbRegistry>(usbRegDeviceList);

    public UsbRegistry this[int index] => this.mUsbRegistryList[index];

    public int Count => this.mUsbRegistryList.Count;

    IEnumerator<UsbRegistry> IEnumerable<UsbRegistry>.GetEnumerator() => (IEnumerator<UsbRegistry>) this.mUsbRegistryList.GetEnumerator();

    public IEnumerator GetEnumerator() => (IEnumerator) ((IEnumerable<UsbRegistry>) this).GetEnumerator();

    public UsbRegistry Find(Predicate<UsbRegistry> findUsbPredicate) => this.mUsbRegistryList.Find(findUsbPredicate);

    public UsbRegDeviceList FindAll(Predicate<UsbRegistry> findUsbPredicate) => new UsbRegDeviceList((IEnumerable<UsbRegistry>) this.mUsbRegistryList.FindAll(findUsbPredicate));

    public UsbRegistry FindLast(Predicate<UsbRegistry> findUsbPredicate) => this.mUsbRegistryList.FindLast(findUsbPredicate);

    public UsbRegistry Find(UsbDeviceFinder usbDeviceFinder) => this.mUsbRegistryList.Find(new Predicate<UsbRegistry>(usbDeviceFinder.Check));

    public UsbRegDeviceList FindAll(UsbDeviceFinder usbDeviceFinder) => this.FindAll(new Predicate<UsbRegistry>(usbDeviceFinder.Check));

    public UsbRegistry FindLast(UsbDeviceFinder usbDeviceFinder) => this.mUsbRegistryList.FindLast(new Predicate<UsbRegistry>(usbDeviceFinder.Check));

    public bool Contains(UsbRegistry item) => this.mUsbRegistryList.Contains(item);

    public void CopyTo(UsbRegistry[] array, int offset) => this.mUsbRegistryList.CopyTo(array, offset);

    public int IndexOf(UsbRegistry item) => this.mUsbRegistryList.IndexOf(item);

    internal bool Add(UsbRegistry item)
    {
      this.mUsbRegistryList.Add(item);
      return true;
    }
  }
}
