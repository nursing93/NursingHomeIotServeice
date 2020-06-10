using LogingWindow.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.Test
{
    public class HttpTest
    {

        //代替http响应RequestHttp()方法测试其他功能块
        public static string TestRequestStr(string recivedStr) { 
        string str="是我";
        return str;
        }
        //代替http响应RequestHttp()方法测试其他功能块
        public static string TestRequestObj(string recivedStr) {
            string str="";
            str = recivedStr;
            return str;
        }

    public class SQLTest
    {
        public string STATE = "";

        public SQLTest(string state)
        {
            this.STATE = state;
        }

        public  string TestUpdateRecord()
        {
            return this.STATE;
        }
    }



        public class UserListTest
        {
            

            public static List<LogUser> getUserList()
            {
                List<LogUser> userList = new List<LogUser>();

                LogUser user = new LogUser();

                user.realName="张三";
                user.role = 1;
                user.nursHomeId = "ww";
                user.id = "name";
                user.birthday="1987-10-2";
                user.sex="女";
                user.phone = "502412198702134125";

                for (int i = 0; i < 15; i++)
                {
                    if(i<=10)
                    {
                        user.id += "k";
                        user.nursHomeId += "2";
                    }
                    LogUser user1 = new LogUser();
                    user1.realName = user.realName;
                    user1.id = user.id;
                    user1.role = user.role;
                    user1.nursHomeId = user.nursHomeId;
                    user1.birthday = user.birthday;
                    user1.sex = user.sex;
                    user1.phone = user.phone;
                    userList.Add(user1);
                }
                return userList;
            }

            public static List<ElderInfor> getElderList()
            {
                List<ElderInfor> elderList = new List<ElderInfor>();
                ElderInfor elder = new ElderInfor();
                elder.id = "KW170001";
                elder.name = "张三";
                for (int i = 0; i < 10;i++ )
                {
                    ElderInfor elder1 = new ElderInfor();
                    elder1.name = "张三";
                    elder1.id = "KW17000" + Convert.ToString(i);
                    elder1.sex = "男";
                    elder1.birthday = "1987/6/6 0:00:00";
                    elder1.idCard = "421545198709232561";
                    elder1.area = "2520";
                    elder1.phone = "16945785123";
                    elderList.Add(elder1);
                }
                return elderList;
            }

            public static List<RingData> getRingDataList(string elderID)
            {
                List<RingData> ringDataList = new List<RingData>();
                for(int i=0;i<10;i++)
                {
                    RingData ringData = new RingData();
                    //ringData.datetime = DateTime.Now.ToString();
                    ringData.curID = elderID;
                    ringData.datetime = "2017-7-16 10:47:5"+i;
                    ringData.lng = "108.33654";
                    ringData.lat = "34.22518";
                    ringData.heartRate = 98;
                    ringDataList.Add(ringData);

                }
                return ringDataList;
            }

        }
    }
}
