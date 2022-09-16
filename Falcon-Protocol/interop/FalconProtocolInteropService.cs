using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Falcon_Protocol.interop
{
    public class FalconProtocolInteropService
    {
		public struct MENU_CONFIG
        {
			public byte video_res;
			public byte video_quality;
			public byte video_format;
			public byte split_time;
			public byte loop_record;
			public byte pre_record;
			public byte ir_mode;
			public byte time_zone;
			public byte volume;
			public byte gps;
			public byte rec_warning;
			public byte photo_size;
			public byte lte;
			public byte wifi;
			public byte post_record;
			public byte car_dv;
			public byte motion_detect;
			public byte livestream_res;
			public byte livestream_format;
			public byte gsensor;
			public byte eis;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			public byte[] res_flag;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			public byte[] photo_size_flag;
			public byte post_rec_flag;
			public byte split_time_flag;
			public byte aes_crypto;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
			public byte[] reserved;
		};

		// BWC Info
		public struct ZFY_INFO
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public char[] cSerial;   /* Serial No	(Example: "1234567"	)	*/
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
			public byte[] userNo;    /* User Id	(Example: "123456")			*/
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
			public byte[] userName; /* User Name (Example: "HERO1234")		*/
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
			public byte[] unitNo;   /* Unit Id	(Example: "123456")			*/
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
			public byte[] unitName; /* Unit Name	(Example: "WEST STATION")*/
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="user_type"></param>
		/// <param name="sPwd"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Init_Device", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Eylog_Login(ref int[] user_type, ref byte[] sPwd, int[] iRet);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IDCode"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
        [DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Init_Device", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Init_Device(ref byte IDCode, int[] iRet);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="iRet"></param>
		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "UnInit_Device", CallingConvention = CallingConvention.Cdecl)]
		public static extern void UnInit_Device(int[] iRet);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sPwd"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "SetMSDC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMSDC(ref byte[] sPwd, int[] iRet);
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="menu_conf"></param>
		/// <param name="config_len"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
        [DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Eylog_GetMenuConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Eylog_GetMenuConfig(ref MENU_CONFIG menu_conf, int config_len, int[] iRet);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="menu_conf"></param>
		/// <param name="config_len"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
        [DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Eylog_SetMenuConfig", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Eylog_SetMenuConfig(ref MENU_CONFIG menu_conf, int config_len, int[] iRet);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		/// <param name="sPwd"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "ReadDeviceResolution", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceResolution(int[] Width, int[] Height, ref byte[] sPwd, int[] iRet);
    
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Battery"></param>
		/// <param name="sPwd"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "ReadDeviceBatteryDumpEnergy", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceBatteryDumpEnergy(ref int Battery, ref byte[] sPwd, int[] iRet);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sPwd"></param>
		/// <param name="iRet"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "SyncDevTime", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SyncDevTime(ref byte[] sPwd, int[] iRet);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IDCode"></param>
		/// <param name="iRet"></param>
		/// <param name="Usb_TotalNum"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Init_Device_UsbTotal")]
		public static extern int Init_Device_UsbTotal(byte[] IDCode, int[] iRet, int[] Usb_TotalNum);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="menu_conf"></param>
		/// <param name="config_len"></param>
		/// <param name="iRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Eylog_SetMenuConfig_ByIndex")]
		public static extern int Eylog_SetMenuConfig_ByIndex(ref MENU_CONFIG menu_conf, int config_len, int[] iRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="menu_conf"></param>
		/// <param name="config_len"></param>
		/// <param name="iRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Eylog_GetMenuConfig_ByIndex")]
		public static extern int Eylog_GetMenuConfig_ByIndex(ref MENU_CONFIG menu_conf, int config_len, int[] iRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="sPwd"></param>
		/// <param name="iRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetZFYInfo_ByIndex")]
		public static extern int GetZFYInfo_ByIndex(ref ZFY_INFO info, byte[] sPwd, int[] iRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="sPwd"></param>
		/// <param name="iRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteZFYInfo_ByIndex")]
		public static extern int WriteZFYInfo_ByIndex(ref ZFY_INFO info, byte[] sPwd, int[] iRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sPwd"></param>
		/// <param name="IRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteZFYInfo_ByIndex")]
		public static extern int Eylog_FormatTFCard_ByIndex(byte[] sPwd, int[] IRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sPwd"></param>
		/// <param name="IRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteZFYInfo_ByIndex")]
		public static extern int SetMSDC_ByIndex(byte[] sPwd, int[] IRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="r_w"></param>
		/// <param name="sn"></param>
		/// <param name="IRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteZFYInfo_ByIndex")]
		public static extern int Eylog_SN_Info_ByIndex(int r_w, byte[] sn, int[] IRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteZFYInfo_ByIndex")]
		public static extern int Eylog_FactoryDefault_ByIndex(int[] IRet, int usb_index);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Battery"></param>
		/// <param name="sPwd"></param>
		/// <param name="IRet"></param>
		/// <param name="usb_index"></param>
		/// <returns></returns>
		[DllImport("DLL\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteZFYInfo_ByIndex")]
		public static extern int ReadDeviceBatteryDumpEnergy_ByIndex(int[] Battery,ref  byte[] sPwd, int[] IRet, int usb_index);

	}
}
