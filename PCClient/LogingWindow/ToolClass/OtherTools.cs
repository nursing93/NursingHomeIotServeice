using PCClintSoftware.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.ToolClass
{
    class OtherTools
    {
        /// <summary>
        /// 将老人的出年月转化为年龄，并返回年龄值（int）型
        /// </summary>
        /// <param name="elder">所需转化年龄的老人对象</param>
        /// <returns></returns>
        public static int BirthdayToYear(ElderInfor elder)
        {
            int year = -1;
            try
            {
                year = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4)) - Convert.ToInt32(elder.elderBirthday.Substring(0, 4));
            }
            catch
            {
                year = -1;
            }
            return year;
        }
        /// <summary>
        /// 将DateTime类型转换为字符串，并且只返回日期，不返回时间
        /// </summary>
        /// <param name="dateTime">DateTime类型的数据</param>
        /// <returns>返回一个日期字符串</returns>
        public static string DateTimeToString(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("u");    //将dateTime转换成字符串,字符串中带有time的字段
            string dateString = dateTimeString.Substring(0,10);     //只提取日期字符，作为返回
            return dateString;
        }
    }
}
