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

    }
}
