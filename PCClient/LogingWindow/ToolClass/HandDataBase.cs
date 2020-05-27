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
    /// <summary>
    /// 工具类，提供操作数据库的静态方法的类
    /// </summary>
    public class HandDataBase
    {
        //定义连接字符串，数据库连接对象
        private static string CON_FORM = @"Data Source=" + Application.StartupPath + @"\..\..\LocalDataBase.sdf";
        private static SqlCeConnection con = new SqlCeConnection(CON_FORM);
        //定义数据适配器和SQL语句注入对象，用于列表显示
        private static SqlCeDataAdapter da;     //
        private static SqlCeCommandBuilder scb;     //
        private static DataTable dt;          //

        private static Object dataBase = new Object();    //设置数据库对象，实现数据库资源的线程同步，防止多线程操作数据库导致数据损坏

        /******************************************************
         * Form窗体直接调用的有关操作数据库的方法
         **************************************************/
        /// <summary>
        /// 向调用者返回一个DataTable的对象，供其DataGridView填充内容,由Form窗体调用，返回两列[编号]、[姓名]
        /// </summary>
        /// <param name="searchStr">用于检索的字符串，在数据库中寻找匹配项</param>
        /// <returns>返回一个DataTable的对象</returns>
        public static DataTable GetNameList(string searchStr)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmmd = new SqlCeCommand("SELECT [ID] [编号],[name] [姓名]" +
                                                " from ElderBaseData WHERE [name] LIKE  @姓名 ", con);//向表中添加约束时，约束值需要用''阔起来
            cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "姓名").Value = "%" + searchStr + "%";  //为数据检索制定一个索引值
            da = new SqlCeDataAdapter(cmmd);
            scb = new SqlCeCommandBuilder(da);
            dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源打开失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库1    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);     //释放数据库资源锁
            }
            return dt;
        }
        /// <summary>
        /// 向调用者返回一个DataTable的对象，供其DataGridView填充内容,由Form窗体调用,返回所有的列
        /// </summary>
        /// <param name="searchStr">用于检索的字符串，在数据库中寻找匹配项</param>
        /// <returns>返回一个DataTable的对象</returns>
        public static DataTable GetNameList_AllColums(string searchStr)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmmd = new SqlCeCommand("SELECT * " +
                                                " from ElderBaseData WHERE [name] LIKE  @姓名 ", con);//向表中添加约束时，约束值需要用''阔起来
            cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "姓名").Value = "%" + searchStr + "%";  //为数据检索制定一个索引值
            da = new SqlCeDataAdapter(cmmd);
            scb = new SqlCeCommandBuilder(da);
            dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源打开失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库2    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
            return dt;
        }
        /***************************************
         * 登录窗口调用的方法，临时存储用户信息
         * ************************************/
        /// <summary>
        /// 将新输入的用户名保存到临时数据文件中，方便下次直接登录，可以分为保存密码和不保存密码两项
        /// </summary>
        /// <param name="user"></param>
        /// <param name="boolean">是否选中了保存密码选项</param>
        public static void UserData(LogUser user,Boolean isSavePassword)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                Monitor.Enter(dataBase);       //获取数据库资源锁
            }
            SqlCeCommand cmd = new SqlCeCommand("SELECT [name] FROM  UserList  WHERE [name] = @name", con);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = user.userName;  //为数据检索制定一个索引值
            SqlCeCommand cmmd = null;
            if (Convert.ToString(cmd.ExecuteScalar()) == "")
            {//如果本地不存在该用户信息，则将该用户信息插入其中
                //MessageBox.Show("将要插入该用户");
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
            else    //如果本地已经存在该用户信息，则将该用户信息更新
            {
                //MessageBox.Show("用户已经存在");
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
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库3    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
        }
        /// <summary>
        /// 自动加载登录窗口的userNameBox控件的内容，方便用户登录时使用
        /// </summary>
        /// <param name="comboBox"></param>
        /// <returns></returns>
        public static ComboBox GetUserList(ComboBox comboBox)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
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
                    comboBox.Items.Add(dr["name"]);     //向列表中添加元素
                }
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库4    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
            return comboBox;
        }
        /// <summary>
        /// 返回一个完善信息后的用户对象
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static LogUser GetUserObj(LogUser user)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
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
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库5    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }  
            return user;
        }

        /*****************************************************
         * 老人数据表有关操作数据库的方法
         **************************************************/
        /// <summary>
        /// 通过老人的ID从数据库检索该老人，并返回一个通过数据库完善了所有信息的老人对象
        /// </summary>
        /// <param name="elder">所需要的老人对象，只包含ID，其他为空</param>
        /// <returns>返回一个完善了所有信息的老人对象</returns>
        public static ElderInfor GetElderRecord(ElderInfor elder)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmmdID, cmmdName, cmmdBirthday, cmmdSex, cmmdChild, cmmdChildnum, cmmdArea;
            string jiansuo = elder.elderID;        //获取该老人对象的编号值，用于检索
            cmmdID = new SqlCeCommand("SELECT [ID] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);//向表中添加约束时，约束值需要用''阔起来
            cmmdName = new SqlCeCommand("SELECT [name] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdBirthday = new SqlCeCommand("SELECT [birthday] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdSex = new SqlCeCommand("SELECT [sex] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdChild = new SqlCeCommand("SELECT [child] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdChildnum = new SqlCeCommand("SELECT [childnum] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            cmmdArea = new SqlCeCommand("SELECT [area] from ElderBaseData WHERE [ID] = '" + jiansuo + "' ", con);
            try
            {
                elder.elderID = Convert.ToString(cmmdID.ExecuteScalar());
                elder.elderName = Convert.ToString(cmmdName.ExecuteScalar());
                elder.elderBirthday = OtherTools.DateTimeToString(Convert.ToDateTime(cmmdBirthday.ExecuteScalar()));
                elder.elderSex = Convert.ToString(cmmdSex.ExecuteScalar());
                elder.elderChild = Convert.ToString(cmmdChild.ExecuteScalar());
                elder.elderChildNumber = Convert.ToString(cmmdChildnum.ExecuteScalar());
                elder.elderArea = Convert.ToString(cmmdArea.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库6    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
            return elder;
        }
        /// <summary>
        /// 修改指定ID的老人的信息
        /// </summary>
        /// <param name="theMan">指定的老人，要求所有属性不为空</param>
        public static void AmendElderRecord(ElderInfor theMan)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            //修改该对象的数据库信息
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand("UPDATE ElderBaseData SET [name]=@姓名, [birthday]=@年龄, "
                                               + "[sex]=@性别, [child]=@监护人, [childnum]=@监护人联系方式, [area]=@安全活动范围 "
                                               + " WHERE  [ID]='" + theMan.elderID + "' ", con);
            cmd.Parameters.Add("@编号", SqlDbType.NVarChar, 50, "ID").Value = theMan.elderID;
            cmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "name").Value = theMan.elderName;
            cmd.Parameters.Add("@性别", SqlDbType.NVarChar, 50, "sex").Value = theMan.elderSex;
            cmd.Parameters.Add("@年龄", SqlDbType.DateTime, 8, "birthday").Value = Convert.ToDateTime(theMan.elderBirthday);
            cmd.Parameters.Add("@监护人", SqlDbType.NVarChar, 50, "child").Value = theMan.elderChild;
            cmd.Parameters.Add("@监护人联系方式", SqlDbType.NVarChar, 50, "childnum").Value = theMan.elderChildNumber;
            cmd.Parameters.Add("@安全活动范围", SqlDbType.NVarChar, 2000, "area").Value = theMan.elderArea;//从javascript获取字符串
            //执行
            try
            {
                cmd.ExecuteNonQuery();   //执行sql语句并返回影响的行数
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库7    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
        }
        /// <summary>
        /// 新建一条的老人的信息
        /// </summary>
        /// <param name="theMan">指定的老人，要求所有属性不为空</param>
        public static void CreatElderRecord(ElderInfor theMan)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            bool IFADDLIST = false;    //标志位，用于表示人员列表中的老人是否新建成功
            //在数据库新建一个该对象的数据
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand("INSERT INTO ElderBaseData VALUES(@编号, @姓名,"
                                                + "  @年龄, @性别, @监护人, @监护人联系方式, @安全活动范围)", con);
            cmd.Parameters.Add("@编号", SqlDbType.NVarChar, 50, "ID").Value = theMan.elderID;
            cmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "name").Value = theMan.elderName;
            cmd.Parameters.Add("@性别", SqlDbType.NVarChar, 50, "sex").Value = theMan.elderSex;
            cmd.Parameters.Add("@年龄", SqlDbType.DateTime, 8, "birthday").Value = Convert.ToDateTime(theMan.elderBirthday); ;
            cmd.Parameters.Add("@监护人", SqlDbType.NVarChar, 50, "child").Value = theMan.elderChild;
            cmd.Parameters.Add("@监护人联系方式", SqlDbType.NVarChar, 50, "childnum").Value = theMan.elderChildNumber;
            cmd.Parameters.Add("@安全活动范围", SqlDbType.NVarChar, 2000, "area").Value = theMan.elderArea;//从javascript获取字符串
            //*******************************************缺少新建对应手环数据表的命令
            string creatRingDataSql = "CREATE TABLE [" + theMan.elderID + "] ( [ID] NVARCHAR(50) NOT NULL,"+
                                      "[Time] DATETIME  NOT NULL ,[Lng] NVARCHAR(50) NOT NULL,[Lat] NVARCHAR(50) NOT NULL," +
                                      "[HardRate] INT NULL  ) ";
            SqlCeCommand cmmd = new SqlCeCommand(creatRingDataSql,con);
            try
            {
                cmd.ExecuteNonQuery();   //在人员表单中插入新数据
                IFADDLIST = true;    //表示人员列表中的老人新建成功
            }
            catch (InvalidOperationException e)
            {
                IFADDLIST = false;    //表示人员列表中的老人新建失败
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
                    cmmd.ExecuteNonQuery();   //新建对应人员的手环数据表
                }
                catch (InvalidOperationException e)
                {
                    //数据源无效时，打印错误并不做其他操作       
                    Console.WriteLine("数据源操作失败，可能是数据源失效");
                    MessageBox.Show("" + e);        //更换为状态栏提示
                }
                catch (Exception e)
                {
                    MessageBox.Show("数据库9    其他异常：\r" + e);
                }
            }
            con.Close();
            Monitor.Exit(dataBase);       //释放数据库资源锁
        }
        /// <summary>
        /// 删除指定ID的老人的信息
        /// </summary>
        /// <param name="theMan">指定的老人，要求至少ID不为空</param>
        public static void DeleteElderRecord(ElderInfor theMan)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            //删除该对象指定的数据库信息
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand("delete FROM ElderBaseData WHERE [ID]='" + theMan.elderID + "' ", con);
            SqlCeCommand cmmd = new SqlCeCommand("DROP TABLE "+theMan.elderID+" ",con);
            try
            {
                cmd.ExecuteNonQuery();   //从老人数据表中删除该老人数据
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库10    其他异常：\r" + e);
            }
            try
            {
                cmmd.ExecuteNonQuery();   //销毁该老人相关的手环数据表
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库11    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
        }
        /// <summary>
        /// 向调用者返回一个ComboBox对象，其他属性与传入的对象相同，只是向其中添加了Item，供更改和删除人员时调用
        /// </summary>
        /// <param name="cmBox">所需要的ComboBox对象</param>
        /// <param name="jiansuo">所需要检索的人名，由name下拉框给定</param>
        /// <param name="BOXID">指定ComboBox对象是指哪个对象，NameComboBox是修改(删除)窗口的name下拉框，
        /// IDComboBox是修改(删除)窗口的的ID下拉框</param>
        /// <returns></returns>
        public static ComboBox ComboBoxDropDown(ComboBox cmBox,string jiansuo,string BOXID)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            if(con.State!=ConnectionState.Open)
            {
                con.Open();
            }
           string cmmStr = null;         //植入数据库的SQL语句字符串
           string drItemStr = null;     //向SqlCeDataReader对象中插入指定列明的字符串，一般为数据库特定的列明
           Boolean IsNullItem = false;    //判断是否ID下拉框调用该方法，防止ID下拉列表在name空输入时显示所有人信息
           switch (BOXID)
           {
                   //判断调用者身份，是修改（删除）的ID下拉框或者是name下拉框
               case ComboBoxDropDownCaller.NameComboBox: cmmStr = "SELECT [name] FROM ElderBaseData WHERE [name] LIKE  @姓名 ";
                         drItemStr = "name";
                   break;
               case ComboBoxDropDownCaller.IDComboBox: cmmStr = "SELECT [ID] FROM ElderBaseData WHERE [name] =  @编号 ";
                         drItemStr = "ID";
                         IsNullItem = true;   //当jiansuo为空时，不做操作
                   break;
               default: return cmBox;
           }
           SqlCeCommand cmmd = new SqlCeCommand(cmmStr, con);//向表中添加约束时，约束值需要用''阔起来
           cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "name").Value = "%" + jiansuo + "%";  //为数据检索制定一个索引值
           cmmd.Parameters.Add("@编号", SqlDbType.NVarChar, 50, "name").Value = jiansuo;
           try
           {
               SqlCeDataReader dr = cmmd.ExecuteReader();
               cmBox.Items.Clear();        //检索结束，刷新列表前开始清空列表
               if (!IsNullItem || jiansuo != "")    //如果不是id下拉框或者jiansuo不为空才执行该条
               {
                   while (dr.Read())
                   {
                       cmBox.Items.Add(dr[drItemStr]);     //向列表中添加元素
                   }
               }
           }
           catch (InvalidOperationException e)
           {
               //数据源无效时，打印错误并不做其他操作       
               Console.WriteLine("数据源操作失败，可能是数据源失效");
               MessageBox.Show("" + e);        //更换为状态栏提示
           }
           catch (Exception e)
           {
               MessageBox.Show("数据库12    其他异常：\r" + e);
           }
           finally
           {
               con.Close();
               Monitor.Exit(dataBase);       //释放数据库资源锁
           }
            return cmBox;
        }

        /*****************************************
         * 手环数据--本地数据库操作
         * **************************************/
        /// <summary>
        /// 从数据库检索该老人手环的最后一条数据，并返回该数据的对象
        /// </summary>
        /// <param name="rdObj">所需获取的手环数据对象，必须带一个ID参数</param>
        /// <returns></returns>
        public static RingData GetRingData(RingData rdObj)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string jiansuo = rdObj.curID;    //定义检索字符
            SqlCeCommand cmmdID, cmmdTime, cmmdLng, cmmdLat, cmmdHard;
            cmmdID = new SqlCeCommand("SELECT [ID] from  " + jiansuo + "  ORDER BY [Time] DESC ", con);//向表中添加约束时，约束值需要用''阔起来
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
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch(Exception e)
            {
                MessageBox.Show("数据库13    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
            return rdObj;
        }
        /// <summary>
        /// 从本地数据库读取对应老人的指定时间的数据
        /// </summary>
        /// <param name="rdObj">所传输的老人</param>
        /// <returns></returns>
        public static RingData GetRingDataByTime(RingData rdObj)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string jiansuo = rdObj.curID;    //定义检索字符
            DateTime  time=Convert.ToDateTime(rdObj.datetime);
            SqlCeCommand cmmdID, cmmdTime, cmmdLng, cmmdLat, cmmdHard;
            cmmdID = new SqlCeCommand("SELECT [ID] from  " + jiansuo + "  WHERE [Lng] = '"+time+"' ", con);//向表中添加约束时，约束值需要用''阔起来
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
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库14    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
            return rdObj;
        }
        /// <summary>
        /// 插入指定的老人的一条手环数据信息
        /// </summary>
        /// <param name="rdObj">指定老人手环数据的对象</param>
        public static void SaveRingData(RingData rdObj)
        {
            Monitor.Enter(dataBase);       //获取数据库资源锁
            string jiansuo = rdObj.curID;    //定义检索字符
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
                cmd.ExecuteNonQuery();   //在数据表单中插入新数据
            }
            catch (InvalidOperationException e)
            {
                //数据源无效时，打印错误并不做其他操作       
                Console.WriteLine("数据源操作失败，可能是数据源失效");
                MessageBox.Show("" + e);        //更换为状态栏提示
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库15    其他异常：\r" + e);
            }
            finally
            {
                con.Close();
                Monitor.Exit(dataBase);       //释放数据库资源锁
            }
        }

    }
}
