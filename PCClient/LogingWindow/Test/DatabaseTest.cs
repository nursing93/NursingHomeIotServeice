using LogingWindow.BaseClass;
using LogingWindow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow.Test
{
    class DatabaseTest
    {
        PojoBuilder pojoBuilder = new PojoBuilder();


        public static void test()
        {
            DatabaseTest t = new DatabaseTest();
            //t.createElder();
            //t.modElder();
            t.deleteElder();
            //t.getElder();

            t.listElder();
        }


        public void createElder()
        {
            ElderInfo elder = pojoBuilder.getElder("93010002", "李四");
            ElderDao eDao = new ElderDao();
            eDao.create(elder);
        }

        public void modElder()
        {
            ElderDao eDao = new ElderDao();
            ElderInfo elder = pojoBuilder.getElder("93010001", "张三");
            elder.birthday = "1966/10/12";
            elder.area = "55555555555555555666666666666666668888888888888888882122222222222";
            eDao.update(elder);
        }

        public void deleteElder()
        {
            ElderInfo elder = pojoBuilder.getElder("93010001", "张三");
            ElderDao eDao = new ElderDao();
            eDao.delete(elder);
        }

        public void getElder()
        {
            ElderDao eDao = new ElderDao();
            ElderInfo elder = eDao.get("93010001");
            MessageBox.Show(pojoBuilder.printElder(elder));
        }

        public void listElder()
        {
            ElderDao eDao = new ElderDao();
            List<ElderInfo> list = eDao.list();
            MessageBox.Show(pojoBuilder.printElderList(list));
        }


    }
}
