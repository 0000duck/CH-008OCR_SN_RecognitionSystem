using HslCommunication.ModBus;
using System;

namespace Test_Automation
{
    class Class_PLC
    {

        public static HslCommunication.ModBus.ModbusTcpNet get_ModbusTcpNet()
        {
            HslCommunication.ModBus.ModbusTcpNet ModbusTcpNet1 =
                new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP,
                   Convert.ToInt16(config_json.PLC_Port),
                   Convert.ToByte(config_json.PLC_Station));
            
            return ModbusTcpNet1;
        }

        public bool light_set_green() {
            HslCommunication.ModBus.ModbusTcpNet PLC = Class_PLC.get_ModbusTcpNet();

            return true;
        }

        /// <summary>
        /// 获取电视机SN，读取PLC寄存器5022~5071
        /// </summary>
       
        public static string Get_TV_SN(ModbusTcpNet PLC)
        {
            String[] TV_SN = new String[50];
            int plc_reg = 5022;
            HslCommunication.OperateResult<byte[]> read = PLC.Read("5021", 1);

            if (read.IsSuccess)
            {
                for (int i = 0; i < 50; i++)
                {
                    HslCommunication.OperateResult<byte[]> reg_value = PLC.Read(Convert.ToString(plc_reg + i), 1);

                    short value = PLC.ByteTransform.TransInt16(reg_value.Content, 0);

                    TV_SN[i] = AsciiToStr(value);
                }
                return string.Join("", TV_SN);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取电视机机型信息，读取PLC寄存器5002~5021
        /// </summary>

        public static string Get_TV_Type(ModbusTcpNet PLC)
        {
            string plc_reg_5002 = "5002";
            HslCommunication.OperateResult<byte[]> read = PLC.Read(plc_reg_5002, 1);
            String[] TV_type = new String[20];
            if (read.IsSuccess)
            {
                for (int i = 0; i < 20; i++)
                {
                    HslCommunication.OperateResult<byte[]> reg_value = PLC.Read(Convert.ToString(5002 + i), 1);
                    short value1 = PLC.ByteTransform.TransInt16(reg_value.Content, 0);

                    TV_type[i] = AsciiToStr(value1);
                }
                return string.Join("", TV_type);
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ASCII码转Str
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string AsciiToStr(int asciiCode)
        {
            try
            {
                if (asciiCode >= 0 && asciiCode <= 255)
                {
                    System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                    byte[] byteArray = new byte[] { (byte)asciiCode };
                    string strCharacter = asciiEncoding.GetString(byteArray);
                    return (strCharacter);
                }
                else
                {
                    // throw new Exception ex("ASCII Code is not valid.");
                    return "";
                }
            }
            catch {
                return "";
            }
        }
    }




   

}
