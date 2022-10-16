// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.UsbEndpointList
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Collections;
using System.Collections.Generic;

namespace USBKitcs.Main
{
  public class UsbEndpointList : IEnumerable<UsbEndpointBase>, IEnumerable
  {
    private readonly List<UsbEndpointBase> mEpList = new List<UsbEndpointBase>();

    internal UsbEndpointList()
    {
    }

    public UsbEndpointBase this[int index] => this.mEpList[index];

    public int Count => this.mEpList.Count;

    public IEnumerator<UsbEndpointBase> GetEnumerator() => (IEnumerator<UsbEndpointBase>) this.mEpList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.mEpList.GetEnumerator();

    public void Clear()
    {
      while (this.mEpList.Count > 0)
        this.Remove(this.mEpList[0]);
    }

    public bool Contains(UsbEndpointBase item) => this.mEpList.Contains(item);

    public int IndexOf(UsbEndpointBase item) => this.mEpList.IndexOf(item);

    public void Remove(UsbEndpointBase item) => item.Dispose();

    public void RemoveAt(int index) => this.Remove(this.mEpList[index]);

    internal UsbEndpointBase Add(UsbEndpointBase item)
    {
      foreach (UsbEndpointBase mEp in this.mEpList)
      {
        if ((int) mEp.EpNum == (int) item.EpNum)
          return mEp;
      }
      this.mEpList.Add(item);
      return item;
    }

    internal bool RemoveFromList(UsbEndpointBase item) => this.mEpList.Remove(item);
  }
}
