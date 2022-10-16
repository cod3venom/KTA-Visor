// Decompiled with JetBrains decompiler
// Type: USBKitcs.Main.PinnedHandle
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Runtime.InteropServices;

namespace USBKitcs.Main
{
  public class PinnedHandle : IDisposable
  {
    private readonly IntPtr mPtr = IntPtr.Zero;
    private bool mFreeGcBuffer;
    private GCHandle mGcObject;

    public PinnedHandle(object objectToPin)
    {
      if (objectToPin == null)
        return;
      this.mFreeGcBuffer = PinnedHandle.GetPinnedObjectHandle(objectToPin, out this.mGcObject);
      this.mPtr = this.mGcObject.AddrOfPinnedObject();
    }

    public IntPtr Handle => this.mPtr;

    public void Dispose()
    {
      if (this.mFreeGcBuffer && this.mGcObject.IsAllocated)
      {
        this.mFreeGcBuffer = false;
        this.mGcObject.Free();
      }
      GC.SuppressFinalize((object) this);
    }

    ~PinnedHandle() => this.Dispose();

    private static bool GetPinnedObjectHandle(object objectToPin, out GCHandle pinnedObject)
    {
      bool pinnedObjectHandle = false;
      if (objectToPin is GCHandle gcHandle)
      {
        pinnedObject = gcHandle;
      }
      else
      {
        pinnedObject = GCHandle.Alloc(objectToPin, GCHandleType.Pinned);
        pinnedObjectHandle = true;
      }
      return pinnedObjectHandle;
    }
  }
}
