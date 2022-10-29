using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;




namespace WindowsFormsApp1
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
        public byte vibrate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public byte[] reserved;
    }
    enum S_DEV_CMD_CUSTOMIZED
    {
        CUSTOMIZED_CMD_RED_LED_CTRL = 0x40,
        CUSTOMIZED_CMD_GREEN_LED_CTRL = 0x41,
        CUSTOMIZED_CMD_END = 0x4f,
    }

    // BWC Info
    public struct ZFY_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] cSerial;   /* Serial No	(Example: "1234567"	)		执法记录仪产品序号，不可为空*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[] userNo;    /* User Id	(Example: "123456")			执法记录仪使用者警号，不可为空*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public byte[] userName; /* User Name (Example: "HERO1234")		执法记录仪使用者姓名，管理系统使用警号关联时可为空*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
        public byte[] unitNo;   /* Unit Id	(Example: "123456")			执法记录仪使用者单位编号，管理系统使用警号关联时可为空*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public byte[] unitName; /* Unit Name	(Example: "WEST STATION")	执法记录仪使用者单位名称，管理系统使用警号关联时可为空*/
    }

    public class CameraCtrl
    {
        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Init_Device_UsbTotal")]
        public static extern int Init_Device_UsbTotal(byte[] IDCode, int[] iRet, int[] Usb_TotalNum);

        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetZFYInfo_ByIndex")]
        public static extern int GetZFYInfo_ByIndex(ref ZFY_INFO info, byte[] sPwd, int[] iRet, int usb_index);

        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteZFYInfo_ByIndex")]
        public static extern int WriteZFYInfo_ByIndex(ref ZFY_INFO info, byte[] sPwd, int[] iRet, int usb_index);

        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Eylog_GetMenuConfig_ByIndex")]
        public static extern int Eylog_GetMenuConfig_ByIndex(ref MENU_CONFIG menu_conf, int config_len, int[] iRet, int usb_index);

        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Eylog_SetMenuConfig_ByIndex")]
        public static extern int Eylog_SetMenuConfig_ByIndex(ref MENU_CONFIG menu_conf, int config_len, int[] iRet, int usb_index);

        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Eylog_Customized_Command")]
        public static extern int Eylog_Customized_Command(char cmd, byte[] cmd_params, int[] iRet, int usb_index);

        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ReadDeviceBatteryDumpEnergy_ByIndex")]
        public static extern int ReadDeviceBatteryDumpEnergy_ByIndex(int[] Battery, byte[] sPwd, int[] iRet, int usb_index);

        [DllImport("dll\\h22_4g_pc.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetMSDC_ByIndex")]
        public static extern int SetMSDC_ByIndex(byte[] sPwd, int[] iRet, int usb_index);

        [DllImport("dll\\msc_con.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?ConnectStorageDevice@@YAHDPAPAX@Z")]
        public static extern int ConnectStorageDevice(char drv_letter, IntPtr[] filehandle);

        [DllImport("dll\\msc_con.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?PassWordCheck@@YAHPAXPADPAH@Z")]
        public static extern int PassWordCheck(IntPtr filehandle, byte[] sPwd, int[] iRet);

        [DllImport("dll\\msc_con.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?SetBWC_MSC@@YAHPAXPAH@Z")]
        public static extern int SetBWC_MSC_Return(IntPtr filehandle, int[] iRet);


    }




    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            byte[] idcode = new byte[6];
            int[] iret = new int[1];
            int[] usb_totalnum = new int[1];

            CameraCtrl.Init_Device_UsbTotal(idcode, iret, usb_totalnum);
            CameraCtrl.Init_Device_UsbTotal(idcode, iret, usb_totalnum);


            var zfy_info = new ZFY_INFO();
            byte[] spwd = new byte[6];
            spwd[0] = 0x30;
            spwd[1] = 0x30;
            spwd[2] = 0x30;
            spwd[3] = 0x30;
            spwd[4] = 0x30;
            spwd[5] = 0x30;

            int usb_index = 0;

            CameraCtrl.GetZFYInfo_ByIndex(ref zfy_info, spwd, iret, usb_index);

            string cSerial = "12345";//the length must match and limit with the zfy_info.cSerial which you get from camera.
            char[] cSerial_tmp = cSerial.ToCharArray();
            Array.Copy(cSerial_tmp, zfy_info.cSerial, cSerial.Length);

            CameraCtrl.GetZFYInfo_ByIndex(ref zfy_info, spwd, iret, usb_index);


            var menu_config = new MENU_CONFIG();
            int config_len = Marshal.SizeOf(menu_config);

            usb_index = 0;
            CameraCtrl.Eylog_GetMenuConfig_ByIndex(ref menu_config, config_len, iret, usb_index);

            menu_config.gps = 1;
            menu_config.vibrate = 0;
            CameraCtrl.Eylog_SetMenuConfig_ByIndex(ref menu_config, config_len, iret, usb_index);



            byte[] cmd_params = new byte[1];
            int[] bat = new int[1];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < usb_totalnum[0]; j++)
                {
                    if (i % 2 == 0)
                    {
                        cmd_params[0] = 0;
                        CameraCtrl.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_RED_LED_CTRL, cmd_params, iret, j);
                        cmd_params[0] = 1;
                        CameraCtrl.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_GREEN_LED_CTRL, cmd_params, iret, j);
                    }
                    else
                    {
                        cmd_params[0] = 1;
                        CameraCtrl.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_RED_LED_CTRL, cmd_params, iret, j);
                        cmd_params[0] = 0;
                        CameraCtrl.Eylog_Customized_Command((char)S_DEV_CMD_CUSTOMIZED.CUSTOMIZED_CMD_GREEN_LED_CTRL, cmd_params, iret, j);
                    }
                    CameraCtrl.ReadDeviceBatteryDumpEnergy_ByIndex(bat, spwd, iret, j);

                }


                Thread.Sleep(1000);
            }
            CameraCtrl.SetMSDC_ByIndex(spwd, iret, 0);



            Thread.Sleep(10000);// delay time depend on PC performance or  connecting it by drive letter in your application flow.
            IntPtr[] filehandle = new IntPtr[1];//if two or more u disk,you can increase the array to two or more,max is 20.
            CameraCtrl.ConnectStorageDevice('F', filehandle);

            CameraCtrl.PassWordCheck(filehandle[0], spwd, iret);
            CameraCtrl.ConnectStorageDevice('E', filehandle);

            CameraCtrl.PassWordCheck(filehandle[0], spwd, iret);

            CameraCtrl.SetBWC_MSC_Return(filehandle[0], iret);

            Application.Run(new Form());
        }
    }
}
