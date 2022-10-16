// Decompiled with JetBrains decompiler
// Type: USBKitcs.UsbError
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System;
using USBKitcs.Internal;
using USBKitcs.Main;
using USBKitcs.MonoLibUsb;

namespace USBKitcs
{
  public class UsbError : EventArgs
  {
    internal static int mLastErrorNumber;
    internal static string mLastErrorString = string.Empty;
    internal string mDescription;
    internal ErrorCode mErrorCode;
    private object mSender;
    internal int mWin32ErrorNumber;
    internal string mWin32ErrorString = "None";

    internal UsbError(
      ErrorCode errorCode,
      int win32ErrorNumber,
      string win32ErrorString,
      string description,
      object sender)
    {
      this.mSender = sender;
      string str1 = string.Empty;
      string str2;
      if (this.mSender is UsbEndpointBase || this.mSender is UsbTransfer)
      {
        UsbEndpointBase usbEndpointBase = !(this.mSender is UsbTransfer) ? this.mSender as UsbEndpointBase : ((UsbTransfer) this.mSender).EndpointBase;
        if (usbEndpointBase.mEpNum > (byte) 0)
          str1 = str2 = str1 + string.Format(" Ep 0x{0:X2} ", (object) usbEndpointBase.mEpNum);
      }
      else if (this.mSender is Type)
      {
        Type mSender = this.mSender as Type;
        str1 = str2 = str1 + string.Format(" {0} ", (object) mSender.Name);
      }
      this.mErrorCode = errorCode;
      this.mWin32ErrorNumber = win32ErrorNumber;
      this.mWin32ErrorString = win32ErrorString;
      this.mDescription = description + str1;
    }

    public object Sender => this.mSender;

    public ErrorCode ErrorCode => this.mErrorCode;

    public int Win32ErrorNumber => this.mWin32ErrorNumber;

    public string Description => this.mDescription;

    public string Win32ErrorString => this.mWin32ErrorString;

    public override string ToString()
    {
      if (this.Win32ErrorNumber == 0)
        return string.Format("{0}:{1}", (object) this.ErrorCode, (object) this.Description);
      return string.Format("{0}:{1}\r\n{2}:{3}", (object) this.ErrorCode, (object) this.Description, (object) this.Win32ErrorNumber, (object) this.mWin32ErrorString);
    }

    internal static UsbError Error(
      ErrorCode errorCode,
      int ret,
      string description,
      object sender)
    {
      string win32ErrorString = string.Empty;
      if (errorCode == ErrorCode.Win32Error && !UsbDevice.IsLinux && ret != 0)
        win32ErrorString = Kernel32.FormatSystemMessage(ret);
      else if (errorCode == ErrorCode.MonoApiError && ret != 0)
        win32ErrorString = ((MonoUsbError) ret).ToString() + ":" + MonoUsbApi.StrError((MonoUsbError) ret);
      UsbError usbError = new UsbError(errorCode, ret, win32ErrorString, description, sender);
      lock (UsbError.mLastErrorString)
      {
        UsbError.mLastErrorNumber = (int) usbError.ErrorCode;
        UsbError.mLastErrorString = usbError.ToString();
      }
      UsbDevice.FireUsbError(sender, usbError);
      return usbError;
    }
  }
}
