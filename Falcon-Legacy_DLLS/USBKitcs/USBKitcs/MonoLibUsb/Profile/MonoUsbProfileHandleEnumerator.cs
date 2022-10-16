// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.Profile.MonoUsbProfileHandleEnumerator
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace USBKitcs.MonoLibUsb.Profile
{
  internal class MonoUsbProfileHandleEnumerator : 
    IEnumerator<MonoUsbProfileHandle>,
    IDisposable,
    IEnumerator
  {
    private readonly MonoUsbProfileListHandle mProfileListHandle;
    private MonoUsbProfileHandle mCurrentProfile;
    private int mNextDeviceProfilePos;

    internal MonoUsbProfileHandleEnumerator(MonoUsbProfileListHandle profileListHandle)
    {
      this.mProfileListHandle = profileListHandle;
      this.Reset();
    }

    public void Dispose() => this.Reset();

    public bool MoveNext()
    {
      IntPtr pProfileHandle = Marshal.ReadIntPtr(new IntPtr(this.mProfileListHandle.DangerousGetHandle().ToInt64() + (long) (this.mNextDeviceProfilePos * IntPtr.Size)));
      if (pProfileHandle != IntPtr.Zero)
      {
        this.mCurrentProfile = new MonoUsbProfileHandle(pProfileHandle);
        ++this.mNextDeviceProfilePos;
        return true;
      }
      this.mCurrentProfile = (MonoUsbProfileHandle) null;
      return false;
    }

    public void Reset()
    {
      this.mNextDeviceProfilePos = 0;
      this.mCurrentProfile = (MonoUsbProfileHandle) null;
    }

    public MonoUsbProfileHandle Current => this.mCurrentProfile;

    object IEnumerator.Current => (object) this.Current;
  }
}
