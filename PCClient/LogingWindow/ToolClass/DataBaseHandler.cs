using LogingWindow.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow.ToolClass
{

    public class DataBaseHandler
    {
        private static string CON_FORM = @"Data Source=" + Application.StartupPath + @"\..\..\LocalDataBase.sdf";
        private static SqlCeConnection con = new SqlCeConnection(CON_FORM);
        private static SqlCeDataAdapter da;
        private static SqlCeCommandBuilder scb;
        private static DataTable dt;

        private static Object dataBase = new Object();

        public static DataTable GetNameList(string searchStr)
        {
            Monitor.Enter(dataBase);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmmd = new SqlCeCommand("SELECT [ID] [编号],[name] [姓名]" +
                                                " from ElderBaseData WHERE [name] LIKE  @姓名 ", con);
            cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "姓名").Value = "%" + searchStr + "%";
            da = new SqlCeDataAdapter(cmmd);
            scb = new SqlCeCommandBuilder(da);
            dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (InvalidOperationException e)
            {      
                Console.WriteLine("数据源打开失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库1    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
            return dt;
        }

        public static DataTable GetNameList_AllColums(string searchStr)
        {
            Monitor.Enter(dataBase);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmmd = new SqlCeCommand("SELECT * " +
                                                " from ElderBaseData WHERE [name] LIKE  @姓名 ", con);
            cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "姓名").Value = "%" + searchStr + "%"; 
            da = new SqlCeDataAdapter(cmmd);
            scb = new SqlCeCommandBuilder(da);
            dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (InvalidOperationException e)
            {      
                Console.WriteLine("数据源打开失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库2    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
            return dt;
        }

        public static void UserData(LogUser user,Boolean isSavePassword)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                Monitor.Enter(dataBase); 
            }
            SqlCeCommand cmd = new SqlCeCommand("SELECT [name] FROM  UserList  WHERE [name] = @name", con);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = user.userName;
            SqlCeCommand cmmd = null;
            if (Convert.ToString(cmd.ExecuteScalar()) == "")
            {
                if (isSavePassword)
                {
                    //@name--用户名, @password--密码,'1'--是否保存密码的判断位
                    cmmd = new SqlCeCommand("INSERT INTO UserList  VALUES ( @name, @password,'1' )", con);
                }
                else
                {
                    cmmd = new SqlCeCommand("INSERT INTO UserList  VALUES ( @name,null ,'0')", con);
                }
            }
            else
            {
                if (isSavePassword)
                {
                    cmmd = new SqlCeCommand("UPDATE UserList SET [name]= @name, [password]=@password ,[isSavePassword]='1'  WHERE [name]=@name", con);
                }
                else
                {
                    cmmd = new SqlCeCommand("UPDATE UserList SET [name]= @name, [password]=null , [isSavePassword]='0' WHERE [name]=@name", con);
                }
            }
            cmmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = user.userName;
            cmmd.Parameters.Add("@password", SqlDbType.NVarChar, 50, "password").Value = user.userPassword;
            try
            {
                cmmd.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {    
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库3    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
        }

        public static ComboBox GetUserList(ComboBox comboBox)
        {
            Monitor.Enter(dataBase);
            string jiansuo = comboBox.Text;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            } 
            SqlCeCommand cmd = new SqlCeCommand("SELECT [name] FROM UserList ",con);
            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();
                comboBox.Items.Clear();
                while (dr.Read())
                {
                    comboBox.Items.Add(dr["name"]);
                }
            }
            catch (InvalidOperationException e)
            {     
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库4    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
            return comboBox;
        }

        public static LogUser GetUserObj(LogUser user)
        {
            Monitor.Enter(dataBase);
            string jiansuo = user.userName;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmdName = new SqlCeCommand("SELECT [name] FROM UserList WHERE [name] = @name ", con);
            SqlCeCommand cmdPassword = new SqlCeCommand("SELECT [password] FROM UserList WHERE [name] = @name ", con);
            SqlCeCommand cmdIsSavePassword = new SqlCeCommand("SELECT [isSavePassword] FROM UserList WHERE [name] = @name ", con);
            cmdName.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = user.userName;
            cmdPassword.Parameters.Add("@name", SqlDbType.NVarChar, 50, "@name").Value = user.userName;
            cmdIsSavePassword.Parameters.Add("@name", SqlDbType.NVarChar, 50, "@name").Value = user.userName;
            try
            {
                user.userName = Convert.ToString(cmdName.ExecuteScalar());
                user.userPassword = Convert.ToString(cmdPassword.ExecuteScalar());
                user.isSavePassword = Convert.ToInt16(cmdIsSavePassword.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {      
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e); 
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库5    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }  
            return user;
        }

        public static ElderInfor GetElderRecord(ElderInfor elder)
        {
            Monitor.Enter(dataBase);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmmdID, cmmdName, cmmdBirthday, cmmdSex, cmmdIdCard, cmmdPhone, cmmdArea;
            string jiansuo = elder.id;
            cmmdID = new SqlCeCommand("SELECT [ID] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdName = new SqlCeCommand("SELECT [name] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdBirthday = new SqlCeCommand("SELECT [birthday] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdSex = new SqlCeCommand("SELECT [sex] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdIdCard = new SqlCeCommand("SELECT [idCard] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdPhone = new SqlCeCommand("SELECT [phone] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdArea = new SqlCeCommand("SELECT [area] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            try
            {
                elder.id = Convert.ToString(cmmdID.ExecuteScalar());
                elder.name = Convert.ToString(cmmdName.ExecuteScalar());
                elder.birthday = OtherTools.DateTimeToString(Convert.ToDateTime(cmmdBirthday.ExecuteScalar()));
                elder.sex = Convert.ToString(cmmdSex.ExecuteScalar());
                elder.idCard = Convert.ToString(cmmdIdCard.ExecuteScalar());
                elder.phone = Convert.ToString(cmmdPhone.ExecuteScalar());
                elder.area = Convert.ToString(cmmdArea.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {      
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库6    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
            return elder;
        }

        public static void AmendElderRecord(ElderInfor theMan)
        {
            Monitor.Enter(dataBase);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand("UPDATE ElderBaseData SET [name]=@姓名, [birthday]=@年龄, "
                                               + "[sex]=@性别, [child]=@监护人, [childnum]=@监护人联系方式, [area]=@安全活动范围 "
                                               + " WHERE  [ID]='" + theMan.id + "' ", con);
            cmd.Parameters.Add("@编号", SqlDbType.NVarChar, 50, "ID").Value = theMan.id;
            cmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "name").Value = theMan.name;
            cmd.Parameters.Add("@性别", SqlDbType.NVarChar, 50, "sex").Value = theMan.sex;
            cmd.Parameters.Add("@年龄", SqlDbType.DateTime, 8, "birthday").Value = Convert.ToDateTime(theMan.birthday);
            cmd.Parameters.Add("@身份证", SqlDbType.NVarChar, 50, "idCard").Value = theMan.idCard;
            cmd.Parameters.Add("@联系电话", SqlDbType.NVarChar, 50, "phone").Value = theMan.phone;
            cmd.Parameters.Add("@安全活动范围", SqlDbType.NVarChar, 2000, "area").Value = theMan.area;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {    
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库7    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
        }

        public static void CreatElderRecord(ElderInfor theMan)
        {
            Monitor.Enter(dataBase);
            bool IFADDLIST = false;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand("INSERT INTO ElderBaseData VALUES(@编号, @姓名,"
                                                + "  @年龄, @性别, @监护人, @监护人联系方式, @安全活动范围)", con);
            cmd.Parameters.Add("@编号", SqlDbType.NVarChar, 50, "ID").Value = theMan.id;
            cmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "name").Value = theMan.name;
            cmd.Parameters.Add("@性别", SqlDbType.NVarChar, 50, "sex").Value = theMan.sex;
            cmd.Parameters.Add("@年龄", SqlDbType.DateTime, 8, "birthday").Value = Convert.ToDateTime(theMan.birthday); ;
            cmd.Parameters.Add("@身份证", SqlDbType.NVarChar, 50, "idCard").Value = theMan.idCard;
            cmd.Parameters.Add("@联系电话", SqlDbType.NVarChar, 50, "phone").Value = theMan.phone;
            cmd.Parameters.Add("@安全活动范围", SqlDbType.NVarChar, 2000, "area").Value = theMan.area;
            string creatRingDataSql = "CREATE TABLE [" + theMan.id + "] ( [ID] NVARCHAR(50) NOT NULL," +
                                      "[Time] DATETIME  NOT NULL ,[Lng] NVARCHAR(50) NOT NULL,[Lat] NVARCHAR(50) NOT NULL," +
                                      "[HardRate] INT NULL  ) ";
            SqlCeCommand cmmd = new SqlCeCommand(creatRingDataSql,con);
            try
            {
                cmd.ExecuteNonQuery();
                IFADDLIST = true;
            }
            catch (InvalidOperationException e)
            {
                IFADDLIST = false;
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库8    其他异常：\r" + e);
            }
            if (IFADDLIST)
            {
                try
                {
                    cmmd.ExecuteNonQuery();
                }
                catch (InvalidOperationException e)
                {       
                    Console.WriteLine("数据源操作失败，可能是数据源失效");
                    MessageBox.Show("" + e);
                }
                catch (Exception e)
                {
                    MessageBox.Show("数据库9    其他异常：\r" + e);
                }
            }
            con.Close();
            Monitor.Exit(dataBase);
        }

        public static void DeleteElderRecord(ElderInfor theMan)
        {
            Monitor.Enter(dataBase);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand("delete FROM ElderBaseData WHERE [ID]='" + theMan.id + "' ", con);
            SqlCeCommand cmmd = new SqlCeCommand("DROP TABLE " + theMan.id + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {     
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库10    其他异常：\r" + e);
            }
            try
            {
                cmmd.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {      
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库11    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
        }

        public static ComboBox ComboBoxDropDown(ComboBox cmBox,string jiansuo,string BOXID)
        {
            Monitor.Enter(dataBase);
            if(con.State!=ConnectionState.Open)
            {
                con.Open();
            }
           string cmmStr = null;
           string drItemStr = null;
           Boolean IsNullItem = false;
           switch (BOXID)
           {
               case ComboBoxDropDownCaller.NameComboBox: cmmStr = "SELECT [name] FROM ElderBaseData WHERE [name] LIKE  @姓名 ";
                         drItemStr = "name";
                   break;
               case ComboBoxDropDownCaller.IDComboBox: cmmStr = "SELECT [ID] FROM ElderBaseData WHERE [name] =  @编号 ";
                         drItemStr = "ID";
                         IsNullItem = true;
                   break;
               default: return cmBox;
           }
           SqlCeCommand cmmd = new SqlCeCommand(cmmStr, con);
           cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "name").Value = "%" + jiansuo + "%";
           cmmd.Parameters.Add("@编号", SqlDbType.NVarChar, 50, "name").Value = jiansuo;
           try
           {
               SqlCeDataReader dr = cmmd.ExecuteReader();
               cmBox.Items.Clear(); 
               if (!IsNullItem || jiansuo != "")
               {
                   while (dr.Read())
                   {
                       cmBox.Items.Add(dr[drItemStr]);
                   }
               }
           }
           catch (InvalidOperationException e)
           {     
               Console.WriteLine("数据源操作失败，可能是数据源失效");
               MessageBox.Show("" + e);
           }
           catch (Exception e)
           {
               MessageBox.Show("数据库12    其他异常：\r" + e);
           }
           finally
           {
               con.Close();
               Monitor.Exit(dataBase);
           }
            return cmBox;
        }

        public static RingData GetRingData(RingData rdObj)
        {
            Monitor.Enter(dataBase);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string jiansuo = rdObj.curID;
            SqlCeCommand cmmdID, cmmdTime, cmmdLng, cmmdLat, cmmdHard;
            cmmdID = new SqlCeCommand("SELECT [ID] from  " + jiansuo + "  ORDER BY [Time] DESC ", con);
            cmmdTime = new SqlCeCommand("SELECT [Time] from  " + jiansuo + "  ORDER BY [Time] DESC ", con);
            cmmdLng = new SqlCeCommand("SELECT [Lng] from  " + jiansuo + "  ORDER BY [Time] DESC ", con);
            cmmdLat = new SqlCeCommand("SELECT [Lat] from  " + jiansuo + "  ORDER BY [Time] DESC ", con);
            cmmdHard = new SqlCeCommand("SELECT [HardRate] from  " + jiansuo + "  ORDER BY [Time] DESC ", con);
            try
            {
                rdObj.curID = Convert.ToString(cmmdID.ExecuteScalar());
                rdObj.datetime = Convert.ToString(cmmdTime.ExecuteScalar());
                rdObj.lng = Convert.ToString(cmmdLng.ExecuteScalar());
                rdObj.lat = Convert.ToString(cmmdLat.ExecuteScalar());
                rdObj.heartRate = Convert.ToInt32(cmmdHard.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {     
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch(Exception e)
            {
                MessageBox.Show("数据库13    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
            return rdObj;
        }

        public static RingData GetRingDataByTime(RingData rdObj)
        {
            Monitor.Enter(dataBase);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string jiansuo = rdObj.curID;
            DateTime  time=Convert.ToDateTime(rdObj.datetime);
            SqlCeCommand cmmdID, cmmdTime, cmmdLng, cmmdLat, cmmdHard;
            cmmdID = new SqlCeCommand("SELECT [ID] from  " + jiansuo + "  WHERE [Lng] = '"+time+"' ", con);
            cmmdTime = new SqlCeCommand("SELECT [Time] from  " + jiansuo + " WHERE [Time] = '" + time + "' ", con);
            cmmdLng = new SqlCeCommand("SELECT [Lng] from  " + jiansuo + "  WHERE [Time] = '" + time + "' ", con);
            cmmdLat = new SqlCeCommand("SELECT [Lat] from  " + jiansuo + "  WHERE [Time] = '" + time + "' ", con);
            cmmdHard = new SqlCeCommand("SELECT [HardRate] from  " + jiansuo + " WHERE [Time] = '" + time + "' ", con);
            try
            {
                rdObj.curID = Convert.ToString(cmmdID.ExecuteScalar());
                rdObj.datetime = Convert.ToString(cmmdTime.ExecuteScalar());
                rdObj.lng = Convert.ToString(cmmdLng.ExecuteScalar());
                rdObj.lat = Convert.ToString(cmmdLat.ExecuteScalar());
                rdObj.heartRate = Convert.ToInt32(cmmdHard.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库14    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
            return rdObj;
        }

        public static void SaveRingData(RingData rdObj)
        {
            Monitor.Enter(dataBase);
            string jiansuo = rdObj.curID;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand("INSERT INTO "+jiansuo+"  VALUES(@编号, @时间, @经度, @纬度, @心率)", con);
            cmd.Parameters.Add("@编号", SqlDbType.NVarChar, 50, "ID").Value = rdObj.curID;
            cmd.Parameters.Add("@时间", SqlDbType.DateTime, 8, "Time").Value = rdObj.datetime;
            cmd.Parameters.Add("@经度", SqlDbType.NVarChar, 50, "Lng").Value = rdObj.lng;
            cmd.Parameters.Add("@纬度", SqlDbType.NVarChar, 50, "Lat").Value = rdObj.lat;
            cmd.Parameters.Add("@心率", SqlDbType.NVarChar, 50, "HardRate").Value = rdObj.heartRate;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {      
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库15    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);
            }
        }

    }
}
