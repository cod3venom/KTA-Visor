#ifndef _EYLOG_DLL_H_
#define _EYLOG_DLL_H_
#pragma once //build one time


#define EYLOG_DLLIMPORT __declspec(dllexport)

/********************************************************************************************************
*
*  Definitions	国标定义相关的值与相关函数
*
*********************************************************************************************************/


#define SUCCESS 1
#define FAILED	0

// BWC Info
typedef struct 
{
	char cSerial[8];   /* Serial No	(Example: "1234567"	)		执法记录仪产品序号，不可为空*/
	char userNo[7];    /* User Id	(Example: "123456")			执法记录仪使用者警号，不可为空*/
	char userName[33]; /* User Name (Example: "HERO1234")		执法记录仪使用者姓名，管理系统使用警号关联时可为空*/
	char unitNo[13];   /* Unit Id	(Example: "123456")			执法记录仪使用者单位编号，管理系统使用警号关联时可为空*/
	char unitName[33]; /* Unit Name	(Example: "WEST STATION")	执法记录仪使用者单位名称，管理系统使用警号关联时可为空*/
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
	/* Video resolution. 
		0:2688x1512P30
		1: 2560x1440P30 
		2: 2304x1296P30 
		3: 1920x1080P30 
		4: 1280x720P30 
		5: 848x480P30
		6:1920x1080P20
		7:1280X720P20
		8:848X480XP20
	*/
	char video_quality;	

	/* Video quality	
		0: Super Fine 
		1: Fine 
		2: Normal
	*/
	char video_format;		
	/* Video format		
		0: H.264	
		1: H.265
	*/
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
	char reserved[32];
}MENU_CONFIG;

// Acknowledges From BWC
typedef enum 
{
	CONNECT_SUCCESS = 0x01,	/* Connect Success			执法记录仪连接成功*/
	CONNECT_FAILED,			/* Connect Fail				执法记录仪连接失败*/
	CHECK_PWD_SUCCESS,		/* PassWord Check Success	执法记录仪管理员密码校验成功*/
	CHECK_PWD_FAILED,		/* PassWord check Fail		执法记录仪管理员密码校验失败*/
	SET_SYSTEMTIME_SUCCESS, /* Set SystemTime Success	执法记录仪系统时间同步成功*/
	SET_SYSTEMTIME_FAILED,  /* Set SystemTime Faile		执法记录仪系统时间同步失败*/
	MSDC_SUCCESS,			/* Enter MSC Success		执法记录仪转换移动磁盘模式成功*/
	MSDC_FAILED,			/* Enter MSC Fail			执法记录仪转换移动磁盘模式失败*/
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
	
#ifdef __cplusplus
}
#endif

#endif