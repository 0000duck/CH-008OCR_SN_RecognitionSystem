using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Test_Automation
{
    class Class_Mysql
    {
        //方法一：Visual Studio,在 项目(右键)-管理NuGet程序包(N)  然后在浏览里面搜索MySql.Data并进行安装。

        //方法二：安装数据库MySQL时要选中Connector.NET 6.9的安装，将C:\Program Files(x86)\MySQL\Connector.NET 6.9\Assemblies里v4.0或v4.5中的MySql.Data.dll添加到项目的引用。
        //v4.0和v4.5，对应Visual Studio具体项目 属性-应用程序-目标框架 里的.NET Framework的版本号。
        private MySqlConnection connection;
        //private string server;
        //private string database;
        //private string uid;
        //private string password;

        //Constructor
        public Class_Mysql()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            //server = "localhost";
            //database = "jczx_mysql_db";
            //uid = "root";
            //password = "jczx";

            string connectionString;
            connectionString = "SERVER=" + config_json.Mysql_IP + ";" 
                + "DATABASE=" + config_json.mysql_database_name + ";" 
                + "UID=" + config_json.Mysql_User + ";" + "PASSWORD=" + config_json.Mysql_Pass + ";charset=utf8";

            connection = new MySqlConnection(connectionString);
        }

        public static string  check_mysql() {
            MySql.Data.MySqlClient.MySqlConnection con =
                new MySql.Data.MySqlClient.MySqlConnection(
                    "Database=" + config_json.mysql_database_name + ";"+
                    "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password="+config_json.Mysql_Pass+";charset=utf8;");
            try
            {
                con.Open();
                con.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Access denied") > -1)
                {
                    //password incorrect,set to destin password  
                    //set password =password('')
                    string result = Class_Mysql.create_password();
                    //change pass failed
                    if (result != "OK") return "登录密码有误，且密码不空，无法修改为设置的密码";
                }
                try
                {
                    Class_Mysql.create_database();
                    try {

                        Class_Mysql.create_testdata_table();
                        Class_Mysql.create_tongji_table();

                    }
                    catch (Exception exx)
                    {
                        return exx.Message;
                    }

                }
                catch (Exception exx)
                {
                    return exx.Message;
                }
            }
            return "OK";
        }


        public static string create_password()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection(
                   //"Database=" + config_json.mysql_database_name + ";"+
                   "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=;charset=utf8;");
            try
            {
                con.Open();
                //set password =password('')
                string query = "set password =password('" + config_json.Mysql_Pass + "');";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "初始密码不为空，无法更改密码！";
            }
            return "OK";
        }
        public static string create_database()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection("Database=mysql;Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            try
            {
                con.Open();

                string query = "CREATE DATABASE IF NOT EXISTS " + config_json.mysql_database_name + " DEFAULT CHARACTER SET utf8 DEFAULT COLLATE utf8_general_ci";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return "OK";
            }
            catch (Exception ex)
            { return ex.Message; }
        }

        public static string create_tongji_table()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();

            string query = "CREATE TABLE IF NOT EXISTS `" + config_json.mysql_yielddata_table + "` (  `id` int(11) NOT NULL AUTO_INCREMENT,  `测试日期` varchar(100) DEFAULT NULL,  `一次直通数量` int(11) DEFAULT '0',  `一次直通率` varchar(100) DEFAULT '0',  `通过数量` int(11) DEFAULT '0',  `通过率` varchar(100) DEFAULT '0',  `误测数量` int(11) DEFAULT '0',  `误测率` varchar(100) DEFAULT '0',  `不合格数量` int(11) DEFAULT '0',  `不合格率` varchar(100) DEFAULT '0',  `备注` varchar(500) DEFAULT '0',  PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='测试统计'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "OK";
        }

        public static int[] get_produce_data() {
            int[] result = new int[4];
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();
            try
            {
                string query = "select * from " + config_json.mysql_yielddata_table + " where 测试日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//向数据库服务器发送指令
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result[0] = Convert.ToInt16(dr["一次直通数量"]);
                    result[1] = Convert.ToInt16(dr["通过数量"]);
                    result[2] = Convert.ToInt16(dr["误测数量"]);
                    result[3] = Convert.ToInt16(dr["不合格数量"].ToString());
                }
                else
                {
                    con.Close();
                    con.Open();
                    string insertstr = "insert into " + config_json.mysql_yielddata_table + " (`测试日期`) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";//插入今天日期并加载默认值0
                    MySql.Data.MySqlClient.MySqlCommand insertcmd = new MySql.Data.MySqlClient.MySqlCommand(insertstr, con);
                    insertcmd.ExecuteNonQuery();
                    result[0] = result[1] = result[2] = result[3] = 0;
                }
                dr.Close();
                con.Close();
                return result;
            }
            catch 
            {
                return null;
            }
        } 

        public static string create_testdata_table()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();
            string query = " CREATE TABLE `" + config_json.mysql_testdata_table + "` ( `id` int(11)  AUTO_INCREMENT, `MO` varchar(100) DEFAULT NULL COMMENT '型号', `SN` varchar(100)  DEFAULT 0 COMMENT '序列号', `SN2` VARCHAR(50) DEFAULT 0 COMMENT '修正后序列号',`result` varchar(100)  NULL COMMENT 'OK/TSNG/TXNG', `WORKSTATIONID` varchar(100)  DEFAULT 0 COMMENT '工作站ID', `SOFT_VER` varchar(100)  DEFAULT 0 COMMENT '软件版本',  `testdate` datetime DEFAULT NULL COMMENT '调试时间', `testseconds` int(11) DEFAULT NULL COMMENT '调试时长', `memo` varchar(500) DEFAULT NULL, PRIMARY KEY (`id`) ) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return "OK";
            }
            catch
            {
                con.Close();
                return "FAIL";
            }
        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (id,name, age) VALUES('11','John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET id='22', name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(int id)
        {
            string query = "DELETE FROM tableinfo WHERE id=" + id;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM laiyatest";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["tid"] + "");
                    list[1].Add(dataReader["tdatetime"] + "");
                    list[2].Add(dataReader["result"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
      internal  static string InsertData(OCR_Data d) {

            string query = "";
           //try
           // {
                query = "INSERT INTO `" + config_json.mysql_testdata_table + "` ( `MO`, `SN`, `SN2`, `result`, `WORKSTATIONID`, `SOFT_VER`, `testdate`, `testseconds`, `memo`) VALUES('"
                   + d.MO + "','"
                   + d.SN + "','"
                     + d.SN2 + "','"
                      + d.result + "','"
                   + d.WORKSTATIONID + "','"
                   + d.SOFT_VER + "','"
                   + DateTime.Now.ToString() + "','"
                    + d.testseconds + "','"
                   + d.memo
                   + "')";

                //return query;

                MySql.Data.MySqlClient.MySqlConnection Conn =
                 new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
                 config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
                Conn.Open();

                //create command and assign the query and connection from the constructor
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, Conn);
                //Execute command
                cmd.ExecuteNonQuery();
                Conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    // return ex.ToString();
            //    return query + "\r\n" + ex.Message;
            //}
            return "本地数据保存成功";
        }
      
        internal static string InsertData(Class_Data d)
        {
            string query = "";
            try
            {
                query = "INSERT INTO `"+config_json.mysql_testdata_table+ "` ( `MO`, `SN`, `WORKSTATIONID`, `SOFT_VER`, `ERROR_CODE`,`ERROR_SPOT`, `testdate`,`testseconds`,"
                   + " `result`, `isgood`, `mesreply`,`memo`) VALUES('"
                   + d.MO + "','"
                   + d.SN + "','"
                   + d.WORKSTATIONID + "','"
                   + d.SOFT_VER + "','"
                   + d.ERROR_CODE + "','"
                    + d.ERROR_SPOT + "','"
                   + DateTime.Now.ToString() + "','"
                    + d.调试时长 + "','"

                   + d.RESULT + "','"

                   + d.mesreply + "','"
                   + d.memo
                   + "')";

                //return query;

                MySql.Data.MySqlClient.MySqlConnection Conn =
                 new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
                 config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
                Conn.Open();

                //create command and assign the query and connection from the constructor
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, Conn);
                //Execute command
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                // return ex.ToString();
                return query+"\r\n"+ex.Message;
            }
            return "本地数据保存成功";

        }

       
    }
}















