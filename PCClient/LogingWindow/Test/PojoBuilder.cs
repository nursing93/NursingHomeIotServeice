using LogingWindow.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow.Test
{
    class PojoBuilder
    {
        public ElderInfo getElder(string id, string name, string sex = "女")
        {
            ElderInfo info = new ElderInfo();
            info.id = id;
            info.name = name;
            info.sex = sex;
            info.birthday = "1987/6/6";
            info.idCard = "421545198709232561";
            info.area = "2520";
            info.phone = "16945785123";
            return info;
        }

        public string printElderList(List<ElderInfo> list)
        {
            string value = "";
            foreach(ElderInfo info in list)
            {
                value += printElder(info);
            }
            return value;
        }

        public string printElder(ElderInfo info)
        {
           return ("Info:\n" + "id:" + info.id + ",\nname:" + info.name + ", \nsex:" + info.sex + ", \nbirthday:" + info.birthday
                                      + ", \nidCard:" + info.idCard + ", \nphone:" + info.phone + ", \narea:" + info.area + ".\n---------------\n");
        }

        public LogUser getLogUser(string id, string pass = "123456", Int32 needSavePass = 0)
        {
            LogUser user = new LogUser(id, pass);
            user.isSavePassword = needSavePass;
            return user;
        }

        public string printLogUser(LogUser user)
        {
            return "Info:\nid:" + user.id + ",\npassword:" + user.password + ",\nisSavePassword:" + user.isSavePassword + ".\n------------------------------\n";
        }

        public string printLogUserList(List<LogUser> list)
        {
            string value = "";
            foreach (LogUser info in list)
            {
                value += printLogUser(info);
            }
            return value;
        }

        int flag = 0;
        public RingRecord getRingRecord(int elderid = 9301001)
        {
            RingRecord record = new RingRecord();
            record.id = elderid;
            record.battery = 83;
            record.physical.heartRate = (flag++) % 100 ;
            record.physical.bloodPressure = 90;
            record.physical.temperature = 36.9;
            record.position.lng = 108.36547;
            record.position.lat = 34.58745;
            record.keyEvent = KeyEvent.NON;
            record.time = DateTime.Now.ToString(); 
            return record;
        }

        public string printRingRecord(RingRecord record)
        {
            return "Info:\nid:elderId" + record.id + "\nheartRate" + record.physical.heartRate + "\nbloodPressure" + record.physical.bloodPressure  +
                "\ntemperature" + record.physical.temperature + "\nposition.lng" + record.position.lng + "\nposition.lat" + record.position.lat + "\ntime" + record.time + "\n----------------------------\n";
        }

        public string printRingRecordList(List<RingRecord> list)
        {
            string result = "";
            foreach (RingRecord record in list)
            {
                result += printRingRecord(record);
            }
            return result;
        }
    }
}
