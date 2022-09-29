using System;

namespace Test_Automation
{
    class config_json
    {
        public config_json() {
        }
        #region 变量
        public static string WORKSTATIONID = "OCR1";
        public static string WinServer_OCR_Path = "WinServer_OCR_20200901.exe";

        public static string form_server_name = "OcrServer";
        public static string form_client_name = "WinClientOCR";
        public static string cmd_get_ocr_result = "cmdCheckingOCR";
        public static bool ocr_flag = true;


        //ocr和plc通讯协议
        //ready dint32 由ocr识别软件写入 0-ocr识别软件未准备好，1-已准备好，
        //start dint32 由plc写入，0-不识别 1-开始识别  ocr检测到1后立即启用识别软件进行序列号识别，同时将start写入0
        //done dint32 由识别软件写入 0-未完成 1-已识别完成，plc读到1后可以将data标签中的序列号作下一步处理,同时将done写入0
        //data sint32 asccii 由识别软件写入识别结果，plc读取到值使用之后将这个标签写入0
        //public static string tag_data = "data";

        public static string tag_ready      = "ready";  //ready
        public static string tag_start      = "start";
        public static string tag_done       = "done";
        public static string tag_data       = "data";
        public static string LocalIP        = "192.168.3.11";
        public static string RemoteIP       = "192.168.3.230";
        public static string RemotePort     = "44818";
        public static string pre_strings    = "T";

        public static int  length_min = 10;
        public static int  length_max = 15;

        public static string pass = "QWQ/r3FGnyU=";   //999
        public static string config_file_path = "d:\\软件配置\\config_ocr.json";

        public static string qt_filename = "GammaForH006.exe";
        public static string qt_test_item = "gamma";
        public static string sn_filename = "d:/cgm_sn.txt";
        public static string result_filename = "d:/cgm_result.txt";
        public static string form_title = "006项目白平衡色域调试";

        public static string log_filename = "log/log.txt";

        public static string error_code_txng = "BPHTS_001";
        public static string error_spot_txng = "txng";

        public static string error_code_tstimeout = "BPHTS_002";
        public static string error_spot_tstimeout = "test timeout";

        public static string error_code_tsng = "BPHTS_003";
        public static string error_spot_tsng = "test ng";


        public static string TestTimeOutSeconds = "80";


        public static bool PLC_Used = true;    //是否启用数据库
        public static bool Adapter_on_check = true;
        public static bool Adapter_off_check = true;
        public static string PLC_IP="127.0.0.1";              //PLC IP地址
        public static string PLC_Port = "502";             //PLC 端口 默认：502
        public static string PLC_Station = "1";             //PLC 站号  默认：1
        public static string PLC_StartTest_Register = "5000";   //PLC控制是否测试可以开始 0不测试 1 测试
        public static string PLC_LetTVPass_Register = "5001";
        public static string PLC_Type_Register = "5002";
        public static string PLC_SN_Register = "200";    //PLC读取sn地址
        public static string PLC_Adapter_Register = "4099";
        public static string PLC_Light_Register = "4119";     //PLC红绿黄灯控制寄存器地址
        public static string PLC_Light_GREEN = "2";
        public static string PLC_Light_RED = "1";
        public static string PLC_Light_YELLOW = "3";
        public static string ShakeHand_OK_Code = "1";  //启动测试信号值


        public static bool mysql_used=true;    //是否启用数据库
        public static string Mysql_IP="127.0.0.1";       //Mysql IP 地址
        public static string Mysql_Port="3306";      //Mysql 端口号
        public static string Mysql_User = "root";      //Mysql 用户名 需要有写入权限
        public static string Mysql_Pass = "jczx";      //Mysql 密码
        public static string mysql_database_name = "数据库_OCR识别系统";  //数据库名
        public static string mysql_testdata_table = "测试数据表";//测试数据表
        public static string mysql_yielddata_table = "生产统计表"; //生产数据统计表

        public static bool auto_run = false;            //是否运行程序后自动开始测试
        public static bool retryafterfail=true;
        public static bool sendtomes = true;
        public static bool stopafterfail=true;
        public static bool sendresulttomes=true;
        public static bool prefailsnotomes = true;
        public static bool lettvpassafterfail_notsendng=false;
        public static bool debug;
        public static string TestMaxSeconds = "2000";

        #endregion
        public static bool save(string key,string value) {
            try
            {
                string json = System.IO.File.ReadAllText("config.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj[key] =value;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("config.json", output);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static bool ReadAll()
        {

            if (System.IO.File.Exists(config_file_path) == false)
            {
                return false;
            }

            System.IO.StreamReader file = System.IO.File.OpenText(config_file_path);
            Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file);
            Newtonsoft.Json.Linq.JObject jsonObject =
                            (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);

            if (jsonObject["WORKSTATIONID"] != null) WORKSTATIONID = (string)jsonObject["WORKSTATIONID"];

            if (jsonObject["form_server_name"] != null) form_server_name = (string)jsonObject["form_server_name"];
            if (jsonObject["form_client_name"] != null) form_client_name = (string)jsonObject["form_client_name"];
            

            if (jsonObject["cmd_get_ocr_result"] != null) cmd_get_ocr_result = (string)jsonObject["cmd_get_ocr_result"];
            if (jsonObject["ocr_flag"] != null) ocr_flag = (bool)jsonObject["ocr_flag"];
            if (jsonObject["length_min"] != null) length_min = (int)jsonObject["length_min"];
            if (jsonObject["length_max"] != null) length_max = (int)jsonObject["length_max"];

            if (jsonObject["tag_ready"] != null) tag_ready = (string)jsonObject["tag_ready"];
            if (jsonObject["tag_start"] != null) tag_start = (string)jsonObject["tag_start"];
            if (jsonObject["tag_done"] != null) tag_done = (string)jsonObject["tag_done"];
            if (jsonObject["tag_data"] != null) tag_data = (string)jsonObject["tag_data"];
            if (jsonObject["LocalIP"] != null) LocalIP = (string)jsonObject["LocalIP"];
            if (jsonObject["RemoteIP"] != null) RemoteIP = (string)jsonObject["RemoteIP"];
            if (jsonObject["RemotePort"] != null) RemotePort = (string)jsonObject["RemotePort"];
            if (jsonObject["pre_strings"] != null) pre_strings = (string)jsonObject["pre_strings"];

            if (jsonObject["TestMaxSeconds"] != null) TestMaxSeconds = (string)jsonObject["TestMaxSeconds"];


            if (jsonObject["pass"] != null) pass = (string)jsonObject["pass"];

            if (jsonObject["PLC_Used"] != null) PLC_Used = (bool)jsonObject["PLC_Used"];
            if (jsonObject["Adapter_on_check"] != null) Adapter_on_check = (bool)jsonObject["Adapter_on_check"];
            if (jsonObject["Adapter_off_check"] != null) Adapter_off_check = (bool)jsonObject["Adapter_off_check"];
            
            if (jsonObject["PLC_IP"] != null) PLC_IP = (string)jsonObject["PLC_IP"];
            if (jsonObject["PLC_Port"] != null) PLC_Port = (string)jsonObject["PLC_Port"];
            if (jsonObject["PLC_Station"] != null) PLC_Station = (string)jsonObject["PLC_Station"];
            if (jsonObject["PLC_LetTVPass_Register"] != null) PLC_LetTVPass_Register = (string)jsonObject["PLC_LetTVPass_Register"];  //产品放行地址
            if (jsonObject["PLC_Adapter_Register"] != null) PLC_Adapter_Register = (string)jsonObject["PLC_Adapter_Register"];
            if (jsonObject["PLC_Light_Register"] != null) PLC_Light_Register = (string)jsonObject["PLC_Light_Register"];
            if (jsonObject["PLC_Light_GREEN"] != null) PLC_Light_GREEN = (string)jsonObject["PLC_Light_GREEN"];
            if (jsonObject["PLC_Light_RED"] != null) PLC_Light_RED = (string)jsonObject["PLC_Light_RED"];
            if (jsonObject["PLC_Light_YELLOW"] != null) PLC_Light_YELLOW = (string)jsonObject["PLC_Light_YELLOW"];
            if (jsonObject["PLC_Type_Register"] != null) PLC_Type_Register = (string)jsonObject["PLC_Type_Register"];
            if (jsonObject["PLC_SN_Register"] != null) PLC_SN_Register = (string)jsonObject["PLC_SN_Register"];
            if (jsonObject["PLC_StartTest_Register"] != null) PLC_StartTest_Register = (string)jsonObject["PLC_StartTest_Register"];
            if (jsonObject["ShakeHand_OK_Code"] != null) ShakeHand_OK_Code = (string)jsonObject["ShakeHand_OK_Code"];


            if (jsonObject["mysql_used"] != null) mysql_used = (bool)jsonObject["mysql_used"];
            if (jsonObject["Mysql_IP"] != null) Mysql_IP = (string)jsonObject["Mysql_IP"];
            if (jsonObject["Mysql_Port"] != null) Mysql_Port = (string)jsonObject["Mysql_Port"];
            if (jsonObject["Mysql_User"] != null) Mysql_User = (string)jsonObject["Mysql_User"];
            if (jsonObject["Mysql_Pass"] != null) Mysql_Pass = (string)jsonObject["Mysql_Pass"];
            if (jsonObject["mysql_database_name"] != null) mysql_database_name = (string)jsonObject["mysql_database_name"];
            if (jsonObject["mysql_yielddata_table"] != null) mysql_yielddata_table = (string)jsonObject["mysql_yielddata_table"];
            if (jsonObject["mysql_testdata_table"] != null) mysql_testdata_table = (string)jsonObject["mysql_testdata_table"];


            //if (jsonObject["IR_SerialPort_Used"] != null) IR_SerialPort_Used = (bool)jsonObject["IR_SerialPort_Used"];
            //if (jsonObject["IR_SerialPort_PortName"] != null) IR_SerialPort_PortName = (string)jsonObject["IR_SerialPort_PortName"];
            //if (jsonObject["IR_SerialPort_BaudRate"] != null) IR_SerialPort_BaudRate = (string)jsonObject["IR_SerialPort_BaudRate"];
            //if (jsonObject["IR_SerialPort_DataBits"] != null) IR_SerialPort_DataBits = (string)jsonObject["IR_SerialPort_DataBits"];
            //if (jsonObject["IR_SerialPort_StopBits"] != null) IR_SerialPort_StopBits = (string)jsonObject["IR_SerialPort_StopBits"];
            //if (jsonObject["IR_SerialPort_Parity"] != null) IR_SerialPort_Parity = (string)jsonObject["IR_SerialPort_Parity"];


            if (jsonObject["auto_run"] != null) auto_run = (bool)jsonObject["auto_run"];
            if (jsonObject["sendresulttomes"] != null) sendresulttomes = (bool)jsonObject["sendresulttomes"];
            if (jsonObject["retryafterfail"] != null) retryafterfail = (bool)jsonObject["retryafterfail"];
            if (jsonObject["stopafterfail"] != null) stopafterfail = (bool)jsonObject["stopafterfail"];
            if (jsonObject["sendtomes"] != null) sendtomes = (bool)jsonObject["sendtomes"];
            if (jsonObject["prefailsnotomes"] != null) prefailsnotomes = (bool)jsonObject["prefailsnotomes"];
            if (jsonObject["lettvpassafterfail_notsendng"] != null) lettvpassafterfail_notsendng = (bool)jsonObject["lettvpassafterfail_notsendng"];

            

            if (jsonObject["debug"] != null) debug = (bool)jsonObject["debug"];

            file.Close();

            return true;
        }
    }
}

