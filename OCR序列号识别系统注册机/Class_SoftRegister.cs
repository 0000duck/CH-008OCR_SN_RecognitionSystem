using System;
using System.Diagnostics;


class Class_SoftRegister
    {
       /*CPUid*/
        public static string GetCpuId()
        {
            System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_Processor");
            System.Management.ManagementObjectCollection moc = mc.GetInstances();

            string strCpuID = null;
            foreach (System.Management.ManagementObject mo in moc)
            {
                strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }
            return strCpuID;
        }

        /* 生成序列号 */
        public static string CreatSerialNumber(string cpuid)
        {
            string SerialNumber = cpuid+ "+" + DateTime.Now.AddMonths(1).ToString("2099-01-01");
            return SerialNumber;
        }

        /* 
         * i=1 得到 CUP 的id 
         * i=0 得到上次或者 开始时间 
         */
        public static string GetSoftEndDateAllCpuId(int i, string SerialNumber)
        {
            if (i == 1)
            {
                string cupId = SerialNumber.Substring(0, SerialNumber.LastIndexOf("+")); // .LastIndexOf("-"));

                return cupId;
            }
            if (i == 0)
            {
                string dateTime = SerialNumber.Substring(SerialNumber.LastIndexOf("+") + 1);
                //  dateTime = dateTime.Insert(4, "/").Insert(7, "/");
                //  DateTime date = Convert.ToDateTime(dateTime);

                return dateTime;
            }
            else
            {
                return string.Empty;
            }
        }

        /*写入注册表*/
        public static void WriteSetting(string Section, string Key, string Setting)  // name = key  value=setting  Section= path
        {
            string text1 = Section;
            Microsoft.Win32.RegistryKey key1 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Ocr_AutoSystem\\key1"); 
            if (key1 == null)
            {
                return;
            }
            try
            {
                key1.SetValue(Key, Setting);
            }
            catch 
            {
                return;
            }
            finally
            {
                key1.Close();
            }

        }

    
    }

