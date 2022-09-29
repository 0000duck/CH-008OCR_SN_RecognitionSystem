using System;

namespace Test_Automation
{
    class Class_Serial
    {
        public static System.IO.Ports.SerialPort Get_JYNY_SerialPort()
        {
            System.IO.Ports.SerialPort JYNY_SerialPort = new System.IO.Ports.SerialPort();
            JYNY_SerialPort.PortName = config_json.JYNY_SerialPort_PortName;
            JYNY_SerialPort.BaudRate = Convert.ToInt16(config_json.JYNY_SerialPort_BaudRate);
            JYNY_SerialPort.DataBits = Convert.ToInt16(config_json.JYNY_SerialPort_DataBits);

            return JYNY_SerialPort;

        }

        //CA410串口 COM3   38400,7,EVEV,2
        public static System.IO.Ports.SerialPort Get_CA410_SerialPort()
        {
            System.IO.Ports.SerialPort CA410_SerialPort = new System.IO.Ports.SerialPort();
            CA410_SerialPort.PortName = config_json.CA410_SerialPort_PortName;
            CA410_SerialPort.BaudRate = Convert.ToInt32(config_json.CA410_SerialPort_BaudRate);
            CA410_SerialPort.DataBits = Convert.ToInt16(config_json.CA410_SerialPort_DataBits);
            CA410_SerialPort.Parity = System.IO.Ports.Parity.Even;
            CA410_SerialPort.StopBits = System.IO.Ports.StopBits.Two;


            return CA410_SerialPort;
            /*串口名称显示为 USB-SERIAL CH340(COM4)
             OK00,P1,0,-0.063188,0.4563044,6.6227164,-0.23,-99999999   共55个字符
             MES,1
             ZRC
             */
        }
            //与电视机通讯串口
        public static System.IO.Ports.SerialPort Get_TV_SerialPort()
        {
            System.IO.Ports.SerialPort TV_SerialPort = new System.IO.Ports.SerialPort();
            TV_SerialPort.PortName = config_json.TV_SerialPort_PortName;
            TV_SerialPort.BaudRate =Convert.ToInt32( config_json.TV_SerialPort_BaudRate);
            TV_SerialPort.DataBits = Convert.ToInt16(config_json.TV_SerialPort_DataBits);
            TV_SerialPort.StopBits = System.IO.Ports.StopBits.One;
            TV_SerialPort.Parity = System.IO.Ports.Parity.None;

            return TV_SerialPort;
            #region 
            //COM5 115200,8,none,1
            /*串口名称显示为 USB-串行设备(COM4)

            //指令
            /*
             * 发送指令：36 96 80 00 00 00 4C
               握手成功： 36 86 80 00 00 00 3C
               3686800000003C

            36 96 92 00 00 00 5e

            //数据保存：36 96 8f 08 00 00 63
             
             
             */
            #endregion
        }

        //红外控制串口
        public static System.IO.Ports.SerialPort Get_IR_SerialPort()
        {
            System.IO.Ports.SerialPort IR_SerialPort = new System.IO.Ports.SerialPort();
            IR_SerialPort.PortName =config_json.IR_SerialPort_PortName;
            IR_SerialPort.BaudRate = Convert.ToInt32(config_json.IR_SerialPort_BaudRate);
            IR_SerialPort.DataBits = Convert.ToInt16(config_json.IR_SerialPort_DataBits);
            IR_SerialPort.StopBits = System.IO.Ports.StopBits.One;
            IR_SerialPort.Parity = System.IO.Ports.Parity.None;

            return IR_SerialPort;
            /*串口名称显示为 USB-SERIAL CH340(COM4)*/
        }


          /// <summary>
       /// Get the target com num.
       /// </summary>
       /// <returns></returns>
       public static string GetComNum(string keywords)
       {
            string comNum = "";
           string[] strArr = GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
           foreach (string s in strArr)
           {
               if (s.Length >= 23 && s.Contains(keywords))
               {
                   int start = s.IndexOf("(");
                   int end = s.IndexOf(")");
                   comNum = s.Substring(start+1, end - start - 1);
               }
           }
           return comNum;
       }

       /// <summary>
       /// Get the system devices information with windows api.
       /// </summary>
       /// <param name="hardType">Device type.</param>
       /// <param name="propKey">the property of the device.</param>
       /// <returns></returns>
       public static string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
       {

            System.Collections.Generic.List<string> strs = new System.Collections.Generic.List<string>();
           try
           {
                //需要添加引用：System.Management
                using (System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("select * from " + hardType))
               {
                   var hardInfos = searcher.Get();
                   foreach (var hardInfo in hardInfos)
                   {
                       if (hardInfo.Properties[propKey].Value != null)
                       {
                           String str = hardInfo.Properties[propKey].Value.ToString();
                           strs.Add(str);
                       }

                   }
               }
               return strs.ToArray();
           }
           catch
           {
               return null;
           }
           finally
           { 
               strs = null;
           }
       }//end of func GetHarewareInfo().

   /// <summary>
   /// 枚举win32 api
   /// </summary>
   public enum HardwareEnum
   {
       // 硬件
       Win32_Processor, // CPU 处理器
       Win32_PhysicalMemory, // 物理内存条
       Win32_Keyboard, // 键盘
       Win32_PointingDevice, // 点输入设备，包括鼠标。
       Win32_FloppyDrive, // 软盘驱动器
       Win32_DiskDrive, // 硬盘驱动器
       Win32_CDROMDrive, // 光盘驱动器
       Win32_BaseBoard, // 主板
       Win32_BIOS, // BIOS 芯片
       Win32_ParallelPort, // 并口
       Win32_SerialPort, // 串口
       Win32_SerialPortConfiguration, // 串口配置
       Win32_SoundDevice, // 多媒体设置，一般指声卡。
       Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
       Win32_USBController, // USB 控制器
       Win32_NetworkAdapter, // 网络适配器
       Win32_NetworkAdapterConfiguration, // 网络适配器设置
       Win32_Printer, // 打印机
       Win32_PrinterConfiguration, // 打印机设置
       Win32_PrintJob, // 打印机任务
       Win32_TCPIPPrinterPort, // 打印机端口
       Win32_POTSModem, // MODEM
       Win32_POTSModemToSerialPort, // MODEM 端口
       Win32_DesktopMonitor, // 显示器
       Win32_DisplayConfiguration, // 显卡
       Win32_DisplayControllerConfiguration, // 显卡设置
       Win32_VideoController, // 显卡细节。
       Win32_VideoSettings, // 显卡支持的显示模式。

       // 操作系统
       Win32_TimeZone, // 时区
       Win32_SystemDriver, // 驱动程序
       Win32_DiskPartition, // 磁盘分区
       Win32_LogicalDisk, // 逻辑磁盘
       Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
       Win32_LogicalMemoryConfiguration, // 逻辑内存配置
       Win32_PageFile, // 系统页文件信息
       Win32_PageFileSetting, // 页文件设置
       Win32_BootConfiguration, // 系统启动配置
       Win32_ComputerSystem, // 计算机信息简要
       Win32_OperatingSystem, // 操作系统信息
       Win32_StartupCommand, // 系统自动启动程序
       Win32_Service, // 系统安装的服务
       Win32_Group, // 系统管理组
       Win32_GroupUser, // 系统组帐号
       Win32_UserAccount, // 用户帐号
       Win32_Process, // 系统进程
       Win32_Thread, // 系统线程
       Win32_Share, // 共享
       Win32_NetworkClient, // 已安装的网络客户端
       Win32_NetworkProtocol, // 已安装的网络协议
       Win32_PnPEntity,//all device
   }

     
    }
}

/*
 串口接收数据处理

     
     */