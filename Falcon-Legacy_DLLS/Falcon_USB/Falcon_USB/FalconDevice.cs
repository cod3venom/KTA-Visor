// Decompiled with JetBrains decompiler
// Type: Falcon_USB.FalconDevice
// Assembly: Falcon_USB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7924EA10-DAC0-471E-BD57-BD7B43142DEE
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\Falcon_USB.dll

using System;

namespace Falcon_USB
{
  public class FalconDevice : IDisposable
  {
    private const int SetupStringLength = 18;
    private const int DeviceStringLength = 64;
    internal readonly UsbFalconDevice _dev;

    public bool IsInserted
    {
      get
      {
        IntPtr handle = this.Handle;
        return true;
      }
    }

    public event EventHandler Removed;

    internal void FireRemoved()
    {
      this.Dispose();
      if (this.Removed == null)
        return;
      this.Removed((object) this, EventArgs.Empty);
    }

    public bool RequirePassword { get; set; }

    internal string Location => this._dev.DeviceLocation;

    internal string SetupString { get; private set; }

    internal IntPtr Handle { get; set; }

    internal FalconDevice(UsbFalconDevice dev)
    {
      this._dev = dev;
      this.SetupString = "";
    }

    public bool IsDeviceInserted() => this._dev.IsOpen();

    private T ParseEnum<T>(char c) => (T) Enum.Parse(typeof (T), c.ToString());

    private char YesNo(bool setting) => !setting ? '0' : '1';

    private char NoYes(bool setting) => this.YesNo(!setting);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || !(this.Handle != IntPtr.Zero))
        return;
      this._dev.Release();
      this.Handle = IntPtr.Zero;
    }
  }
}
