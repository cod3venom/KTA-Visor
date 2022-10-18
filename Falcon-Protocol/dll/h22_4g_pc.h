#ifndef _EYLOG_DLL_H_
#define _EYLOG_DLL_H_
#pragma once //build one time


#define EYLOG_DLLIMPORT __declspec(dllexport)

/********************************************************************************************************
*
*  Definitions	���궨����ص�ֵ����غ���
*
*********************************************************************************************************/


#define SUCCESS 1
#define FAILED	0

// BWC Info
typedef struct 
{
	char cSerial[8];   /* Serial No	(Example: "1234567"	)		ִ����¼�ǲ�Ʒ��ţ�����Ϊ��*/
	char userNo[7];    /* User Id	(Example: "123456")			ִ����¼��ʹ���߾��ţ�����Ϊ��*/
	char userName[33]; /* User Name (Example: "HERO1234")		ִ����¼��ʹ��������������ϵͳʹ�þ��Ź���ʱ��Ϊ��*/
	char unitNo[13];   /* Unit Id	(Example: "123456")			ִ����¼��ʹ���ߵ�λ��ţ�����ϵͳʹ�þ��Ź���ʱ��Ϊ��*/
	char unitName[33]; /* Unit Name	(Example: "WEST STATION")	ִ����¼��ʹ���ߵ�λ���ƣ�����ϵͳʹ�þ��Ź���ʱ��Ϊ��*/
}ZFY_INFO;			

// network connect info
typedef struct
{
	char wifi_mode;  
	char wifi_name[17];   
	char wifi_psw[17]; 
	char apn_4g[33]; 
	char pin_4g[9];
	char server_ip[17];
	char server_port[9];
}ZFY_NET_INFO;

// Items For BWC Settup Menu
typedef struct
{
	char video_res;			

	char video_quality;		

	char video_format;		

	char split_time;
	char loop_record;
	char pre_record;
	char ir_mode;
	char time_zone;
	char volume;
	char gps; 
	char rec_warning;
	char photo_size;
	char lte;
	char wifi;
	char post_record;
	char car_dv;
	char motion_detect;
	char livestream_res;
	char livestream_format;
	char gsensor;
	char eis;
	char res_flag[2];
	char photo_size_flag[2];
	char post_rec_flag;
	char split_time_flag;
	char aes_crypto;
	char reserved[23];
}MENU_CONFIG;
//config reference
	/* Video format		
		0: H.264	
		1: H.265
	*/
	/* Video quality	
		0: Super Fine 
		1: Fine 
		2: Normal
	*/
	/*
	res_flag[0]
	bit0:2688x1512 30P->0
	bit1:2560x1440 30P->1
	bit2:2304x1296 30P->1
	bit3:1920x1080 60P->0
	bit4:1920x1080 30P->1
	bit5:1440x1080 30P->0
	bit6:1280x720 60P->0
	bit7:1280x720 30P->1
	res_flag[1]
	bit0:848x480 60P->0
	bit1:848x480 30P->1
	bit2:720x480 30P->0
	*/

	/*
	photo_size_flag[0]
	bit0:5M->1
	bit1:8M->0
	bit2:10M->0
	bit3:12M->1
	bit4:16M->0
	bit5:20M->1
	bit6:21M->0
	bit7:23M->0
	photo_size_flag[1]
	bit0:25M->1
	bit1:28M->0
	bit2:30M->1
	bit3:32M->0
	bit4:36M->0
	bit5:40M->1
	bit6:50M->0
	bit7:64M->0
	*/

	
	//if photo_size  bit7 =1,using user-defined photo size,
	//otherwise using default value-> 5,12,25,30,40


	/*
	post_rec_flag
	bit0:OFF->1
	bit1:5 Sec->1
	bit2:1 Min->1
	bit3:10Min->1
	bit4:20Min->1
	bit5:35Min->1
	*/


	/*
	split_time_flag
	bit0:1 Min->1
	bit1:3 Min->1
	bit2:5 Min->1
	bit3:10Min->1
	bit4:15Min->1
	bit5:30Min->1
	bit6:45Min->1
	*/


// Acknowledges From BWC
typedef enum 
{
	CONNECT_SUCCESS = 0x01,	/* Connect Success			ִ����¼�����ӳɹ�*/
	CONNECT_FAILED,			/* Connect Fail				ִ����¼������ʧ��*/
	CHECK_PWD_SUCCESS,		/* PassWord Check Success	ִ����¼�ǹ���Ա����У��ɹ�*/
	CHECK_PWD_FAILED,		/* PassWord check Fail		ִ����¼�ǹ���Ա����У��ʧ��*/
	SET_SYSTEMTIME_SUCCESS, /* Set SystemTime Success	ִ����¼��ϵͳʱ��ͬ���ɹ�*/
	SET_SYSTEMTIME_FAILED,  /* Set SystemTime Faile		ִ����¼��ϵͳʱ��ͬ��ʧ��*/
	MSDC_SUCCESS,			/* Enter MSC Success		ִ����¼��ת���ƶ�����ģʽ�ɹ�*/
	MSDC_FAILED,			/* Enter MSC Fail			ִ����¼��ת���ƶ�����ģʽʧ��*/
};

#ifdef __cplusplus
extern "C"
{
#endif


	/*API*/
	
	
 /**
 *  @brief format tf card
 *
 *  @param [in] password
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */
	EYLOG_DLLIMPORT int	Eylog_FormatTFCard(char *sPwd, int *iRet);
	
	/**
 *  @brief set BWC net information
 *
 *  @param [in] BWC net information
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */
	EYLOG_DLLIMPORT int	Eylog_SetNetConfig(ZFY_NET_INFO *NetConf, int *iRet);
	
	/**
 *  @brief get BWC net information
 *
 *  @param [out] BWC net information
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */	
	EYLOG_DLLIMPORT int	Eylog_GetNetConfig(ZFY_NET_INFO *NetConf, int *iRet);
	
	/**
 *  @brief login bwc
 *
 *  @param [out] the password to login bwc
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */		
	EYLOG_DLLIMPORT int	Eylog_Login(int user_type,char *sPwd, int *iRet);


	/**
 *  @brief get tf card capacity
 *
 *  @param [out] capacity strings
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */		
	EYLOG_DLLIMPORT int	Eylog_GetTFVol(char *tf_vol, int *iRet);
	
	/**
 *  @brief get firmware version 
 *
 *  @param [out] firmware version strings
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */			
	EYLOG_DLLIMPORT int	Eylog_GetFwVersion(char *fw_ver, int *iRet);
	
	
	/**
 *  @brief set menu config
 *
 *  @param [in] menu config value
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */				
	EYLOG_DLLIMPORT int	Eylog_SetMenuConfig(void *menu_conf, int config_len, int *iRet);
	
	
	/**
 *  @brief set menu config
 *
 *  @param [in] menu config value
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */					
	EYLOG_DLLIMPORT int	Eylog_GetMenuConfig(void *menu_conf, int config_len, int *iRet);
	
	
	/**
 *  @brief to sense BWC is 4G camera or not
 *
 * 
 *  @param [out]  1-> 4g or 2->not 4G
 *
 *  @return 1 success, 0 failure
 */
	EYLOG_DLLIMPORT int	Eylog_Get4GDevOrNot(int *iRet);
	
	/**
 *  @brief to set default value
 *
 *  
 *  @param [out]  not use
 *
 *  @return 1 success, 0 failure
 */	
	EYLOG_DLLIMPORT int	Eylog_SetDefault(int *iRet);
	
	/**
 *  @brief to set factory default value
 *
 *  
 *  @param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */	
	EYLOG_DLLIMPORT int	Eylog_ChangePsw(int user_type, char *new_psw, int *iRet);
	
	EYLOG_DLLIMPORT int	Eylog_GetPsw(int user_type, char *old_psw, int *iRet);

/**
 *  @brief to set facory default 
 *				1).set default value
 *				2).format tf card
 *				3).enter MSC
 *  
 *  @param [out]  CONNECT_SUCCESS or CONNECT_FAILED
 *
 *  @return 1 success, 0 failure
 */		
	EYLOG_DLLIMPORT int	Eylog_FactoryDefault(int *iRet);



/**
 *  @brief to init bwc usb connection
 *  
 *  @param [out] bwc id code
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED

 *	
 *  @return 1 success, 0 failure
 */		
	EYLOG_DLLIMPORT int		Init_Device(char *IDCode, int *iRet);
	
	
	/**
 *  @brief to disconnect bwc usb connection
 *  
 * 
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *	
 *  @return 1 success, 0 failure
 */		
	EYLOG_DLLIMPORT void	UnInit_Device(int *iRet);
	


	EYLOG_DLLIMPORT int	Eylog_SN_Info(int r_w, char *sn, int *iRet);
	EYLOG_DLLIMPORT int	Eylog_ApnPsw(int r_w, char *psw, int *iRet);
	EYLOG_DLLIMPORT int	Eylog_ApnUser(int r_w, char *user, int *iRet);

 /**
 *  @brief to bwc time synchronization
 *  
 *  @param [in] password
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *	
 *  @return 1 success, 0 failure
 */	
	EYLOG_DLLIMPORT int		SyncDevTime(char *sPwd, int *iRet);
	
	
/**
 *  @brief to get bwc id code
 *  
 *  @param [out] bwc id code
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED

 *	
 *  @return 1 success, 0 failure
 */			
	EYLOG_DLLIMPORT int  GetIDCode(char *IDCode, int *iRet);
	
	
	/**
 *  @brief to get some bwc information
 *  
 *  @param [out] bwc information
  * @param [in] password
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *	
 *  @return 1 success, 0 failure
 */	
	EYLOG_DLLIMPORT int  GetZFYInfo(ZFY_INFO *info, char *sPwd, int *iRet);
	
		/**
 *  @brief to set some bwc information
 *  
 *  @param [in] bwc information
  * @param [in] password
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *	
 *  @return 1 success, 0 failure
 */	
	EYLOG_DLLIMPORT int  WriteZFYInfo(ZFY_INFO *info, char *sPwd, int *iRet);
	
	
	/**
 *  @brief to enter MSC
 *  
 * 
  * @param [in] password
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *	
 *  @return 1 success, 0 failure
 */		
	EYLOG_DLLIMPORT int  SetMSDC(char *sPwd, int *iRet);
	
	/**
 *  @brief to get video  Resolution
 *  
 *  @param [out] width
  *  @param [out] Height
  * @param [in] password
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *	
 *  @return 1 success, 0 failure
 */		
	EYLOG_DLLIMPORT int  ReadDeviceResolution(int *Width, int *Height, char *sPwd, int *iRet);
	
	
		/**
 *  @brief to get battery volume
 *  
 *  @param [out] Battery volume
  * @param [in] password
 *	@param [out] CONNECT_SUCCESS or CONNECT_FAILED
 *	
 *  @return 1 success, 0 failure
 */		
EYLOG_DLLIMPORT int  ReadDeviceBatteryDumpEnergy(int *Battery, char *sPwd, int *iRet);


/****************Add APIs for usb connect by index*********************/
EYLOG_DLLIMPORT int Init_Device_UsbTotal(char *IDCode, int *iRet, int *Usb_TotalNum);
EYLOG_DLLIMPORT int	Eylog_SetMenuConfig_ByIndex(void *menu_conf, int config_len, int *iRet, int usb_index);
EYLOG_DLLIMPORT int	Eylog_GetMenuConfig_ByIndex(void *menu_conf, int config_len, int *iRet, int usb_index);
EYLOG_DLLIMPORT int GetZFYInfo_ByIndex(ZFY_INFO *info, char *sPwd, int *iRet, int usb_index);
EYLOG_DLLIMPORT int WriteZFYInfo_ByIndex(ZFY_INFO *info, char *sPwd, int *iRet, int usb_index);
EYLOG_DLLIMPORT int	Eylog_FormatTFCard_ByIndex(char *sPwd, int *iRet, int usb_index);
EYLOG_DLLIMPORT int SetMSDC_ByIndex(char *sPwd, int *iRet, int usb_index);
EYLOG_DLLIMPORT int	Eylog_SN_Info_ByIndex(int r_w, char *sn, int *iRet, int usb_index);
EYLOG_DLLIMPORT int	Eylog_FactoryDefault_ByIndex(int *iRet, int usb_index);
EYLOG_DLLIMPORT int ReadDeviceBatteryDumpEnergy_ByIndex(int *Battery, char *sPwd, int *iRet, int usb_index);

	
#ifdef __cplusplus
}
#endif

#endif