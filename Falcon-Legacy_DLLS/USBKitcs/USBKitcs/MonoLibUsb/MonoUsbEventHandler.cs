// Decompiled with JetBrains decompiler
// Type: USBKitcs.MonoLibUsb.MonoUsbEventHandler
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Threading;
using USBKitcs.Main;

namespace USBKitcs.MonoLibUsb
{
  public static class MonoUsbEventHandler
  {
    private static readonly ManualResetEvent mIsStoppedEvent = new ManualResetEvent(true);
    private static bool mRunning;
    private static MonoUsbSessionHandle mSessionHandle;
    internal static Thread mUsbEventThread;
    private static ThreadPriority mPriority = ThreadPriority.Normal;
    private static UnixNativeTimeval mWaitUnixNativeTimeval;

    public static MonoUsbSessionHandle SessionHandle => MonoUsbEventHandler.mSessionHandle;

    public static bool IsStopped => MonoUsbEventHandler.mIsStoppedEvent.WaitOne(0, false);

    public static ThreadPriority Priority
    {
      get => MonoUsbEventHandler.mPriority;
      set => MonoUsbEventHandler.mPriority = value;
    }

    public static void Exit()
    {
      MonoUsbEventHandler.Stop(true);
      if (MonoUsbEventHandler.mSessionHandle == null || MonoUsbEventHandler.mSessionHandle.IsInvalid)
        return;
      MonoUsbEventHandler.mSessionHandle.Close();
      MonoUsbEventHandler.mSessionHandle = (MonoUsbSessionHandle) null;
    }

    private static void HandleEventFn(object oHandle)
    {
      MonoUsbSessionHandle sessionHandle = oHandle as MonoUsbSessionHandle;
      MonoUsbEventHandler.mIsStoppedEvent.Reset();
      while (MonoUsbEventHandler.mRunning)
        MonoUsbApi.HandleEventsTimeout(sessionHandle, ref MonoUsbEventHandler.mWaitUnixNativeTimeval);
      MonoUsbEventHandler.mIsStoppedEvent.Set();
    }

    public static void Init(long tvSec, long tvUsec) => MonoUsbEventHandler.Init(new UnixNativeTimeval(tvSec, tvUsec));

    public static void Init() => MonoUsbEventHandler.Init(UnixNativeTimeval.Default);

    private static void Init(UnixNativeTimeval unixNativeTimeval)
    {
      if (!MonoUsbEventHandler.IsStopped || MonoUsbEventHandler.mRunning || MonoUsbEventHandler.mSessionHandle != null)
        return;
      MonoUsbEventHandler.mWaitUnixNativeTimeval = unixNativeTimeval;
      MonoUsbEventHandler.mSessionHandle = new MonoUsbSessionHandle();
      if (MonoUsbEventHandler.mSessionHandle.IsInvalid)
      {
        MonoUsbEventHandler.mSessionHandle = (MonoUsbSessionHandle) null;
        throw new UsbException((object) typeof (MonoUsbApi), string.Format("Init:libusb_init Failed:Invalid Session Handle"));
      }
    }

    public static bool Start()
    {
      if (MonoUsbEventHandler.IsStopped && !MonoUsbEventHandler.mRunning && MonoUsbEventHandler.mSessionHandle != null)
      {
        MonoUsbEventHandler.mRunning = true;
        MonoUsbEventHandler.mUsbEventThread = new Thread(new ParameterizedThreadStart(MonoUsbEventHandler.HandleEventFn));
        MonoUsbEventHandler.mUsbEventThread.Priority = MonoUsbEventHandler.mPriority;
        MonoUsbEventHandler.mUsbEventThread.Start((object) MonoUsbEventHandler.mSessionHandle);
      }
      return true;
    }

    public static void Stop(bool bWait)
    {
      if (MonoUsbEventHandler.IsStopped || !MonoUsbEventHandler.mRunning)
        return;
      MonoUsbEventHandler.mRunning = false;
      if (bWait && !MonoUsbEventHandler.mUsbEventThread.Join((int) ((double) (MonoUsbEventHandler.mWaitUnixNativeTimeval.tv_sec * 1000L + MonoUsbEventHandler.mWaitUnixNativeTimeval.tv_usec) * 1.2)))
      {
        MonoUsbEventHandler.mUsbEventThread.Abort();
        throw new UsbException((object) typeof (MonoUsbEventHandler), "Critical timeout failure! MonoUsbApi.HandleEventsTimeout did not return within the allotted time.");
      }
      MonoUsbEventHandler.mUsbEventThread = (Thread) null;
    }
  }
}
