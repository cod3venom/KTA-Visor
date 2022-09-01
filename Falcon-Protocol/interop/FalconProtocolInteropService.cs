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
		[StructLayout(LayoutKind.Sequential)]
		public struct MENU_CONFIG
        {
			public byte video_res;


			public byte video_quality;     // Menu:9
			/*
			0: Video Quality: Super Fine
			1: Video Quality: Fine
			2: Video Quality: Normal
			3: Video Quality: Low
			4: Video Quality: Super Low
			*/


			public byte video_format;      // Menu:31
			/*
			0: Video Coding Format: H.264
			1: Video Coding Format: H.265
			*/


			public byte split_time;    // Menu:14
			/*
			0: Video Split Time: 1 Min
			1: Video Split Time: 3 Min
			2: Video Split Time: 5 MIn
			3: Video Split Time: 10 MIn
			4: Video Split Time: 15 Min
			5: Video Split Time: 20 Min
			6: Video Split Time: 30 Min
			7: Video Split Time: 45 Min
			*/


			public byte loop_record;   // Menu:13
			/*
			0: Video Loop Recording: Off
			1: Video Loop Recording: On
			*/


			public byte pre_record;    // Menu:10
			/*
			0: Video Pre-recording: Off
			1: Video Pre-recording: On
			*/


			public byte ir_mode;       // Menu:16
			/*
			0: IR Mode: Off
			1: IR Mode: Manual
			2: IR Mode: Auto
			*/


			public byte time_zone;     // Menu:22
			/*
			0: Time Zone: -12
			1: Time Zone: -11
			......
			23: Time Zone: +11
			24: Time Zone: +12
			*/


			public byte volume;        // Menu:30
			/*
			0: Volume: 0
			1: Volume: 3
			2: Volume: 6
			3: Volume: 9
			4: Volume: 12
			*/


			public byte gps;       // Menu:20
			/*
			0: GPS: Off
			1: GPS: On
			*/


			public byte rec_warning;   // Menu:18
			/*
			0: Recording Warning: Off
			1: Recording Warning: On
			*/


			public byte photo_size;        // Menu:5
			/*
			0: Photo Size: 5M
			1: Photo Size: 12M
			2: Photo Size: 20M
			3: Photo Size: 25M
			4: Photo Size: 39M
			5: Photo Size: 40M
			*/


			public byte lte;

			public byte wifi;

			public byte post_record;       // Menu:11
			/*
			0: Post Recording: Off
			1: Post Recording: 5S
			2: Post Recording: 1Min
			3: Post Recording: 10Min
			4: Post Recording: 20Min
			5: Post Recording: 35Min
			*/

			public byte car_dv;        // Menu:12
			/*
			0: CarDv Mode: Off
			1: CarDv Mode: On
			*/

			public byte motion_detect;     // Menu:17
			/*
			0: Motion Detection: Off
			1: Motion Detection: On
			*/

			public byte livestream_res;
			public byte livestream_format;
			public byte gsensor;
			public byte eis;
			byte res_flag;
			byte photo_size_flag;
			public byte post_rec_flag;
			public byte split_time_flag;
			public byte aes_crypto;

			/* This is special setting for customer STC */

			public byte FrontCameraRes;    // Menu:1
			/*
			0: Front Camera Resolutin: 2560x1440
			1: Front Camera Resolutin: 2304x1296
			2: Front Camera Resolutin: 1920x1080
			3: Front Camera Resolutin: 1280x720
			4: Front Camera Resolutin: 848x480
			*/


			public byte FrontCameraFps;    // Menu:2
			/*
			0: Front Camera Frame Rate: 30fps
			1: Front Camera Frame Rate: 15fps
			*/


			public byte ExtCameraRes;  // Menu:3
			/*
			0: External Camera Resolutin: 848x480
			1: External Camera Resolutin: 1280x720
			*/


			public byte Dewarp;        // Menu:4
			/*
			0: Video Dewarp: Off
			1: Video Dewarp: On
			*/


			public byte BurstMode;     // Menu:6
			/*
			0: Photo Burst: Off
			1: Photo Burst: 2pcs
			2: Photo Burst: 3pcs
			3: Photo Burst: 5pcs
			4: Photo Burst: 6pcs
			5: Photo Burst: 8pcs
			6: Photo Burst: 10pcs
			7: Photo Burst: 15pcs
			8: Photo Burst: 20pcs
			*/

			public byte RecordingCamera;   // Menu:7
			/*
			0: Recoding Camera: Front Camera
			1: Recoding Camera: External Camera
			2: Recoding Camera: Both Camera
			*/

			public byte SelfShutterTimer;  // Menu:8
			/*
			0: Self Shutter Timer: Off
			1: Self Shutter Timer: 5Sec
			2: Self Shutter Timer: 10Sec
			3: Self Shutter Timer: 20Sec
			4: Self Shutter Timer: 30Sec
			5: Self Shutter Timer: 1Min
			*/

			public byte SlideShow;     // Menu:15
			/*
			0: Photo Slideshow: Off
			1: Photo Slideshow: On
			*/

			public byte RecordingMute;     // Menu:19
			/*
			0: Recording Mute: Off
			1: Recording Mute: On
			*/

			public byte SpeedStamp;    // Menu:21
			/*
			0: Speed Stamp: Off
			1: Speed Stamp: On
			*/

			public byte Language;      // Menu:23
			/*
			0: Language: English
			1: Language: simplified Chinese
			2: Language: Traditional Chinese
			3: Language: Russian
			4: Language: Polish
			5: Language: Korean
			6: Language: French
			7: Language: Japanese
			8: Language: Portuguese
			9: Language: Spanish
			10: Language: Turkey
			*/

			public byte ScreenSave;    // Menu:24
			/*
			0: Screen Save TImer: Off
			1: Screen Save TImer: 30Sec
			2: Screen Save TImer: 1Min
			3: Screen Save TImer: 3Min
			4: Screen Save TImer: 5Min
			*/

			public byte LcdBrightness;     // Menu:25
			/*
			0: Lcd Brightness: Low
			1: Lcd Brightness: Medium
			2: Lcd Brightness: High
			*/

			public byte AutoPowerOff;  // Menu:26
			/*
			0: Auto Power Off: Off
			0: Auto Power Off: 30Sec
			0: Auto Power Off: 1Min
			0: Auto Power Off: 3Min
			0: Auto Power Off: 5Min
			*/


			public byte IndicatorLed;  // Menu:27
			/*
			0: Indicator Led: Off
			0: Indicator Led: On 
			*/

			public byte WhiteLed;      // Menu:28
			/*
			0: White Led: Off
			0: White Led: On 
			*/

			public byte KeyTone;       // Menu:29
			/*
			0: Key Tone: Off
			0: Key Tone: On 
			*/

			public byte AutoReminderType;  // Menu:32
			/*
			0: Auto Reminder Type: Off
			1: Auto Reminder Type: Voice
			2: Auto Reminder Type: Vibrate
			3: Auto Reminder Type: Beep
			*/

			public byte AutoReminderTimer; // Menu:33
			/*
			0: Auto Reminder Timer: 1Min
			1: Auto Reminder Timer: 2Min
			2: Auto Reminder Timer: 5Min
			3: Auto Reminder Timer: 10Min
			*/

			public byte EnableAudioButton; // Menu:34
			/*
			0: Enable Audio Button: Off
			1: Enable Audio Button: On
			*/

			public byte EnablePhotoButton;// Menu:35
			/*
			0: Enable Photo Button: Off
			1: Enable Photo Button: On
			*/

			public byte EnableFuncButton; // Menu:36
			/*
			0: Enable Function Button: Off
			1: Enable Function Button: On
			*/

			public byte BitInvertion;      // Menu:37
			/*
			0: Bit Invertion: Off
			1: Bit Invertion: On 
			*/

			public byte PswCtrl;           // Menu:40
			/*
			0: Password: Off
			1: Password: On 
			*/
		};
	

		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Init_Device", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Eylog_Login(ref int[] user_type, ref byte[] sPwd, int[] iRet);

        [DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Init_Device", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Init_Device(ref byte IDCode, int[] iRet);

        [DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "SetMSDC", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMSDC(ref byte[] sPwd, int[] iRet);
        
        [DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Eylog_GetMenuConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Eylog_GetMenuConfig(ref MENU_CONFIG menu_conf, int config_len, int[] iRet);

        [DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "Eylog_SetMenuConfig", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Eylog_SetMenuConfig(ref MENU_CONFIG menu_conf, int config_len, int[] iRet);

		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "ReadDeviceResolution", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceResolution(int[] Width, int[] Height, ref byte[] sPwd, int[] iRet);
    
		[DllImport("DLL\\h22_4g_pc.dll", EntryPoint = "ReadDeviceBatteryDumpEnergy", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadDeviceBatteryDumpEnergy(ref int Battery, ref byte[] sPwd, int[] iRet);


	}
}
