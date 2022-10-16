// Decompiled with JetBrains decompiler
// Type: USBKitcs.Internal.LibUsb.LibUsbIoCtl
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

namespace USBKitcs.Internal.LibUsb
{
  internal static class LibUsbIoCtl
  {
    private const int FILE_ANY_ACCESS = 0;
    private const int FILE_DEVICE_UNKNOWN = 34;
    private const int METHOD_BUFFERED = 0;
    private const int METHOD_IN_DIRECT = 1;
    private const int METHOD_NEITHER = 3;
    private const int METHOD_OUT_DIRECT = 2;
    public static readonly int ABORT_ENDPOINT = LibUsbIoCtl.CTL_CODE(34, 2063, 0, 0);
    public static readonly int CLAIM_INTERFACE = LibUsbIoCtl.CTL_CODE(34, 2069, 0, 0);
    public static readonly int CLEAR_FEATURE = LibUsbIoCtl.CTL_CODE(34, 2054, 0, 0);
    public static readonly int CONTROL_TRANSFER = LibUsbIoCtl.CTL_CODE(34, 2307, 0, 0);
    public static readonly int GET_CONFIGURATION = LibUsbIoCtl.CTL_CODE(34, 2050, 0, 0);
    public static readonly int GET_CUSTOM_REG_PROPERTY = LibUsbIoCtl.CTL_CODE(34, 2305, 0, 0);
    public static readonly int GET_DESCRIPTOR = LibUsbIoCtl.CTL_CODE(34, 2057, 0, 0);
    public static readonly int GET_INTERFACE = LibUsbIoCtl.CTL_CODE(34, 2052, 0, 0);
    public static readonly int GET_STATUS = LibUsbIoCtl.CTL_CODE(34, 2055, 0, 0);
    public static readonly int GET_VERSION = LibUsbIoCtl.CTL_CODE(34, 2066, 0, 0);
    public static readonly int GET_REG_PROPERTY = LibUsbIoCtl.CTL_CODE(34, 2304, 0, 0);
    public static readonly int INTERRUPT_OR_BULK_READ = LibUsbIoCtl.CTL_CODE(34, 2059, 2, 0);
    public static readonly int INTERRUPT_OR_BULK_WRITE = LibUsbIoCtl.CTL_CODE(34, 2058, 1, 0);
    public static readonly int ISOCHRONOUS_READ = LibUsbIoCtl.CTL_CODE(34, 2068, 2, 0);
    public static readonly int ISOCHRONOUS_WRITE = LibUsbIoCtl.CTL_CODE(34, 2067, 1, 0);
    public static readonly int RELEASE_INTERFACE = LibUsbIoCtl.CTL_CODE(34, 2070, 0, 0);
    public static readonly int RESET_DEVICE = LibUsbIoCtl.CTL_CODE(34, 2064, 0, 0);
    public static readonly int RESET_ENDPOINT = LibUsbIoCtl.CTL_CODE(34, 2062, 0, 0);
    public static readonly int SET_CONFIGURATION = LibUsbIoCtl.CTL_CODE(34, 2049, 0, 0);
    public static readonly int SET_DEBUG_LEVEL = LibUsbIoCtl.CTL_CODE(34, 2065, 0, 0);
    public static readonly int SET_DESCRIPTOR = LibUsbIoCtl.CTL_CODE(34, 2056, 0, 0);
    public static readonly int SET_FEATURE = LibUsbIoCtl.CTL_CODE(34, 2053, 0, 0);
    public static readonly int SET_INTERFACE = LibUsbIoCtl.CTL_CODE(34, 2051, 0, 0);
    public static readonly int VENDOR_READ = LibUsbIoCtl.CTL_CODE(34, 2061, 0, 0);
    public static readonly int VENDOR_WRITE = LibUsbIoCtl.CTL_CODE(34, 2060, 0, 0);

    private static int CTL_CODE(int DeviceType, int Function, int Method, int Access) => DeviceType << 16 | Access << 14 | Function << 2 | Method;
  }
}
