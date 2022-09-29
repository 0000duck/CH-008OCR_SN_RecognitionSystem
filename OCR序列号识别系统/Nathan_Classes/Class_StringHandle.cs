using System;

namespace Test_Automation
{
    class Class_StringHandle
    {
        /// <summary>
        /// 数组转换成16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="return_format">1 小写不带空格分隔 2小写带空格分隔 3大写不带空格分隔 4大写带空格分隔</param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes,int return_format)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    switch (return_format)
                    {
                        case 1:
                            returnStr += bytes[i].ToString("x2");
                            break;

                        case 2:
                            returnStr += bytes[i].ToString("x2")+" ";
                            break;
                        case 3:
                            returnStr += bytes[i].ToString("X2");
                            break;
                        case 4:
                            returnStr += bytes[i].ToString("X2")+" ";
                            break;
                    }
                    
                }
            }
            return returnStr.Trim();
        }
        /// <summary>
        /// 数组转换成16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>大写不带空格分隔</returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        /// <summary>
        /// 16进制字符串转换成数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] hexStringToBytes(String hexString)
        {
            if (hexString == null || hexString.Equals(""))
            {
                return null;
            }
            hexString = hexString.ToUpper().Replace(" ", "");
            int length = hexString.Length / 2;
            char[] hexChars = hexString.ToCharArray();
            byte[] d = new byte[length];
            for (int i = 0; i < length; i++)
            {
                int pos = i * 2;
                d[i] = (byte)(charToByte(hexChars[pos]) << 4 | charToByte(hexChars[pos + 1]));

            }
            return d;
        }
        private static byte charToByte(char c)
        {
            return (byte)"0123456789ABCDEF".IndexOf(c);
        }


        public static byte[] str2ASCII(String xmlStr)
        {
            return System.Text.Encoding.Default.GetBytes(xmlStr);
        }
        public static string Ascii2Str(byte[] buf)
        {
            return System.Text.Encoding.ASCII.GetString(buf);
        }
      }

    }
