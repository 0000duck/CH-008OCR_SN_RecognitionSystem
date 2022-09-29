using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Automation
{
    class Class_Mysql
    {
        //方法一：Visual Studio,在 项目(右键)-管理NuGet程序包(N)  然后在浏览里面搜索MySql.Data并进行安装。

        //方法二：安装数据库MySQL时要选中Connector.NET 6.9的安装，将C:\Program Files(x86)\MySQL\Connector.NET 6.9\Assemblies里v4.0或v4.5中的MySql.Data.dll添加到项目的引用。
        //v4.0和v4.5，对应Visual Studio具体项目 属性-应用程序-目标框架 里的.NET Framework的版本号。
        private MySqlConnection connection;
        public static MySql.Data.MySqlClient.MySqlConnection conn =
             new MySql.Data.MySqlClient.MySqlConnection(
                 "Database=" + config_json.mysql_database_name + ";" +
                 "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");

        public static MySql.Data.MySqlClient.MySqlConnection get_conn() {
            return new MySql.Data.MySqlClient.MySqlConnection(
                 "Database=" + config_json.mysql_database_name + ";" +
                 "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
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
            catch 
            {
                return "初始密码不为空，无法更改密码！";
            }
            return "OK";
        }



        public static string check_mysql()
        {
            conn = get_conn();
            string result = "OK";
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Access denied") > -1)
                {
                    //password incorrect,set to destin password  
                    //set password =password('')
                    result = Class_Mysql.create_password();
                    //change pass failed
                    if (result != "OK")
                    {
                        return "密码有误或原密码不为空（创建密码失败，原密码必须为空）";
                    }
                }
            }

            try
            {
                if (create_database() != "OK")
                {
                    return "创建数据库失败";
                }
            }
            catch (Exception exx)
            {
                return exx.Message;
            }

            try
            {
                if (create_testdata_table_wb() == "OK") { } else { result = "创建测试数据表失败"; }
                if (create_tongji_table() == "OK") { } else { result = "创建统计表失败"; }
                if (!check_table_is_exist(config_json.mysql_database_name, "user_admin")) { create_user_admin(); }
                if (!check_table_is_exist(config_json.mysql_database_name, "user_operator")) { create_user_operator(); }
                if (!check_table_is_exist(config_json.mysql_database_name, "user_technician")) { create_user_technician(); }
                create_user_user_login_log();
            }
            catch (Exception exx)
            {
                result = exx.Message;
            }
            return result;
        }
        public Class_Mysql()
        {
            Initialize();
        }

        public static bool check_table_is_exist(string database_name, string table_name)
        {
            conn = get_conn();
            bool b = false;
            conn.Open();
            string query = "select `TABLE_NAME` from `INFORMATION_SCHEMA`.`TABLES` where `TABLE_SCHEMA`= '" + database_name + "' and `TABLE_NAME`= '" + table_name + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                b = true;
            }
            else
            {
                b = false;
            }
            conn.Close();
            return b;
        }
        public static bool check_table_column_isexist(string tablename, string columnname)
        {
            conn = get_conn();
            bool b = false;
            conn.Open();
            string query = @"SELECT count(*) FROM information_schema.COLUMNS WHERE table_name = '" + config_json.mysql_testdata_table + "' AND column_name = 'operator'";
            //string query = @"SELECT count(*) FROM information_schema.COLUMNS WHERE table_name = 'jyny_testdataV3' AND column_name = 'operator'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() == "1") b = true;
            }

            conn.Close();
            return b;

        }
        public static string create_user_admin()
        {
            conn = get_conn();
            string result = "OK";
            string query = @"CREATE TABLE  IF NOT EXISTS `user_admin` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                             `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='超级管理员';

                            INSERT INTO `user_admin` (`code` ,`name`, `pass`, `memo`) VALUES
                            ('admin','张三', 'admin', '超级管理员');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }

        public static string create_user_operator()
        {
            conn = get_conn();
            string result = "OK";
            string query = @"CREATE TABLE  IF NOT EXISTS `user_operater` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                            `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='操作工';

                            INSERT INTO `user_operater` (`code` ,`name`, `pass`, `memo`) VALUES
                            ('op','张三', 'op', '操作工');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }

        public static string create_user_technician()
        {
            conn = get_conn();
            string result = "OK";
            string query = @"
                            CREATE TABLE  IF NOT EXISTS `user_technician` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                            `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='工艺（修改设置）';

                            INSERT INTO `user_technician` (`code` ,`name`, `pass`, `memo`) VALUES
                            ('gy','张三', 'gy', '工艺');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }
        public static string create_user_user_login_log()
        {
            conn = get_conn();
            string result = "OK";
            string query = @" CREATE TABLE   IF NOT EXISTS  `user_login_log` ( 
                                `id` INT NOT NULL AUTO_INCREMENT , 
                                `login_user_type` VARCHAR(50) NOT NULL , 
                                `login_name` VARCHAR(50) NOT NULL , 
                                `login_datetime` DATETIME NOT NULL , 
                                `logout_datetime` datetime DEFAULT NULL,
                                 `online_hours` decimal(5,2) DEFAULT NULL,
                                PRIMARY KEY (`id`)) ENGINE = MyISAM; ";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }
        public static string add_logout_log(string id, string hours)
        {
            return Exexute_Sql2Str("update user_login_log set logout_datetime=now(),online_hours=" + hours + " where id=" + id);
        }
        public static string add_login_login(string user_type, string name)
        {
            return Exexute_Sql2Str("insert into user_login_log(login_user_type, login_name, login_datetime) values(N'" + user_type + "', N'" + name + "', now()); select last_insert_id();");
        }
        public static string login_operater(string code, string pass)
        {
            conn = get_conn();
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_operater where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }
        public static string login_technician(string code, string pass)
        {
            conn = get_conn();
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_technician where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }
        public static string login_admin(string code, string pass)
        {
            conn = get_conn();
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_admin where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }
        public static string add_column(string tablename, string columnname)
        {
            conn = get_conn();
            string result = "OK";
            string query = "ALTER TABLE `" + tablename + "` ADD `" + columnname + "` VARCHAR(50) NULL";
            conn.Open();
            //create command and assign the query and connection from the constructor
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            //Execute command
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            conn.Close();
            return result;
        }
        //Initialize values
        private void Initialize()
        {
            //server = "localhost";database = "jczx_mysql_db";uid = "root";password = "jczx";

            string connectionString;
            connectionString = "SERVER=" + config_json.Mysql_IP + ";" 
                + "DATABASE=" + config_json.mysql_database_name + ";" 
                + "UID=" + config_json.Mysql_User + ";" + "PASSWORD=" + config_json.Mysql_Pass + ";charset=utf8";

            connection = new MySqlConnection(connectionString);
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
        public static string Exexute_Sql(string sql)
        {
            conn = get_conn();
            string result = "OK";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            conn.Close();
            return result;
        }
        public static string Exexute_Sql2Str(string sql)
        {
            conn = get_conn();
            string result = "";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr[0].ToString();
            }

            conn.Close();
            return result;
        }
        public static string create_tongji_table()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();

            string query = "CREATE TABLE IF NOT EXISTS `" + config_json.mysql_yielddata_table + @"` (  
                            `id` int(11) NOT NULL AUTO_INCREMENT,  
                            `测试日期` varchar(100) DEFAULT NULL,  
                            `一次直通数量` int(11) DEFAULT '0',  
                            `一次直通率` varchar(100) DEFAULT '0',  
                            `通过数量` int(11) DEFAULT '0',  
                            `通过率` varchar(100) DEFAULT '0', 
                            `误测数量` int(11) DEFAULT '0', 
                            `误测率` varchar(100) DEFAULT '0', 
                            `不合格数量` int(11) DEFAULT '0',  
                            `不合格率` varchar(100) DEFAULT '0',  
                            `备注` varchar(500) DEFAULT '0', 
                            PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='测试统计'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "OK";
        }

        public static string create_testdata_table_wb()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();
            string query = " CREATE TABLE if not exists `" + config_json.mysql_testdata_table + @"` ( 
                            `id` int(11)  AUTO_INCREMENT, 
                            `MO` varchar(100) DEFAULT NULL COMMENT '模组型号', 
                            `SN` varchar(100)  DEFAULT 0 COMMENT '序列号',  
                            `result` varchar(100)  NULL COMMENT 'OK/TSNG/TXNG', 
                            `isgood` bit(1)  NULL COMMENT '0不良品 1良品', 
                            `mesreply` varchar(200) DEFAULT NULL, 
                            `WORKSTATIONID` varchar(100)  DEFAULT 0 COMMENT '工作站ID', 
                            `SOFT_VER` varchar(100)  DEFAULT 0 COMMENT '软件版本', 
                            `ERROR_CODE` varchar(100)  DEFAULT 0 COMMENT '错误代码', 
                            `ERROR_SPOT` varchar(100) DEFAULT NULL COMMENT '错误点', 
                            `testdate` datetime DEFAULT NULL COMMENT '调试时间', 
                            `testseconds` int(11) DEFAULT NULL COMMENT '调试时长',
                            `test_times` int(11) DEFAULT NULL, 
                            `memo` varchar(500) DEFAULT NULL, 
                            PRIMARY KEY (`id`) ) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8";
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

        /// <summary>
        /// 获取生产数据
        /// </summary>
        /// <returns>0 一次直通数量 1 通过数量 2误测数量 3不合格数量</returns>
        private Int16[] get_produce_data(string table_name)
        {
            Int16[] result = new Int16[4];
            MySql.Data.MySqlClient.MySqlConnection con =
                    new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name
                    + ";Data Source=" + config_json.Mysql_IP
                    + ";User Id=" + config_json.Mysql_User
                    + ";Password=" + config_json.Mysql_Pass);
            try
            {
                con.Open();
            }
            catch 
            {
                return null;
            }

            try
            {
                string query = "select * from " + table_name + " where 测试日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//向数据库服务器发送指令

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
                    string insertstr = "insert into " + table_name + " (`测试日期`) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";//插入今天日期并加载默认值0
                    //tbmemo.Text = insertstr;
                    MySql.Data.MySqlClient.MySqlCommand insertcmd = new MySql.Data.MySqlClient.MySqlCommand(insertstr, con);
                    insertcmd.ExecuteNonQuery();
                    result[0] = result[1] = result[2] = result[3] = 0;
                }
                con.Close();

            }
            catch 
            {
                return null;
            }
            return result;
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

      
        //internal static string InsertDataV20(Class_HW_Gamma_Data_V20 d)
        //{
        //    string query = "";
        //    try
        //    {
        //        string good = "0";
        //        if (d.良品 == true) good = "1";

        //        query = "INSERT INTO `"+config_json.mysql_testdata_table+ "` ( `MO`, `SN`, `WORKSTATIONID`, `SOFT_VER`, `ERROR_CODE`,`ERROR_SPOT`, `testdate`,`testseconds`,"
        //           + " `result`, `isgood`, `mesreply`,`memo`) VALUES('"
        //           + d.MO + "','"
        //           + d.SN + "','"
        //           + d.WORKSTATIONID + "','"
        //           + d.SOFT_VER + "','"
        //           + d.ERROR_CODE + "','"
        //            + d.ERROR_SPOT + "','"
        //           + DateTime.Now.ToString() + "','"
        //            + d.调试时长 + "','"

        //           + d.RESULT + "',"
        //           + good + ",'"
        //           + d.mesreply + "','"
        //           + d.memo
        //           + "')";

        //        //return query;

        //        MySql.Data.MySqlClient.MySqlConnection Conn =
        //         new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
        //         config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
        //        Conn.Open();

        //        //create command and assign the query and connection from the constructor
        //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, Conn);
        //        //Execute command
        //        cmd.ExecuteNonQuery();
        //        Conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // return ex.ToString();
        //        return query+"\r\n"+ex.Message;
        //    }
        //    return "本地数据保存成功";

        //}
    }
}















