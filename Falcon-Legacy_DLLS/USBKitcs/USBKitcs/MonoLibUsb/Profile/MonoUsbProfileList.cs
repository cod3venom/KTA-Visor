// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Profile.MonoUsbProfileList
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections;
using System.Collections.Generic;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb.Profile
{
  public class MonoUsbProfileList : IEnumerable<MonoUsbProfile>, IEnumerable
  {
    private object LockProfileList = new object();
    private List<MonoUsbProfile> mList = new List<MonoUsbProfile>();

    private static bool FindDiscoveredFn(MonoUsbProfile check) => check.mDiscovered;

    private static bool FindUnDiscoveredFn(MonoUsbProfile check) => !check.mDiscovered;

    private void FireAddRemove(MonoUsbProfile monoUSBProfile, AddRemoveType addRemoveType)
    {
      EventHandler<AddRemoveEventArgs> addRemoveEvent = this.AddRemoveEvent;
      if (addRemoveEvent == null)
        return;
      addRemoveEvent((object) this, new AddRemoveEventArgs(monoUSBProfile, addRemoveType));
    }

    private void SetDiscovered(bool discovered)
    {
      foreach (MonoUsbProfile monoUsbProfile in this)
        monoUsbProfile.mDiscovered = discovered;
    }

    private void syncWith(MonoUsbProfileList newList)
    {
      this.SetDiscovered(false);
      newList.SetDiscovered(true);
      int count = newList.mList.Count;
      for (int index1 = 0; index1 < count; ++index1)
      {
        MonoUsbProfile m = newList.mList[index1];
        int index2;
        if ((index2 = this.mList.IndexOf(m)) == -1)
        {
          m.mDiscovered = true;
          this.mList.Add(m);
          this.FireAddRemove(m, AddRemoveType.Added);
        }
        else
        {
          this.mList[index2].mDiscovered = true;
          m.mDiscovered = false;
        }
      }
      newList.mList.RemoveAll(new Predicate<MonoUsbProfile>(MonoUsbProfileList.FindDiscoveredFn));
      newList.Close();
      foreach (MonoUsbProfile m in this.mList)
      {
        if (!m.mDiscovered)
        {
          this.FireAddRemove(m, AddRemoveType.Removed);
          m.Close();
        }
      }
      this.mList.RemoveAll(new Predicate<MonoUsbProfile>(MonoUsbProfileList.FindUnDiscoveredFn));
    }

    public int Refresh(MonoUsbSessionHandle sessionHandle)
    {
      lock (this.LockProfileList)
      {
        MonoUsbProfileList newList = new MonoUsbProfileList();
        MonoUsbProfileListHandle monoUSBProfileListHandle;
        int deviceList = MonoUsbApi.GetDeviceList(sessionHandle, out monoUSBProfileListHandle);
        if (deviceList < 0 || monoUSBProfileListHandle.IsInvalid)
        {
          UsbError.Error(ErrorCode.MonoApiError, deviceList, "Refresh:GetDeviceList Failed", (object) this);
          return deviceList;
        }
        int num = deviceList;
        foreach (MonoUsbProfileHandle monoUSBProfileHandle in monoUSBProfileListHandle)
        {
          newList.mList.Add(new MonoUsbProfile(monoUSBProfileHandle));
          --num;
          if (num <= 0)
            break;
        }
        this.syncWith(newList);
        monoUSBProfileListHandle.Close();
        return deviceList;
      }
    }

    public void Close()
    {
      lock (this.LockProfileList)
      {
        foreach (MonoUsbProfile m in this.mList)
          m.Close();
        this.mList.Clear();
      }
    }

    public event EventHandler<AddRemoveEventArgs> AddRemoveEvent;

    public IEnumerator<MonoUsbProfile> GetEnumerator()
    {
      lock (this.LockProfileList)
        return (IEnumerator<MonoUsbProfile>) this.mList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public int Count
    {
      get
      {
        lock (this.LockProfileList)
          return this.mList.Count;
      }
    }

    public List<MonoUsbProfile> GetList()
    {
      lock (this.LockProfileList)
        return new List<MonoUsbProfile>((IEnumerable<MonoUsbProfile>) this.mList);
    }

    public MonoUsbProfile this[int index]
    {
      get
      {
        lock (this.LockProfileList)
          return this.mList[index];
      }
    }
  }
}
