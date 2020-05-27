using PCClintSoftware.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow.ToolClass
{
    /// <summary>
    /// 提供窗体和js交互的静态方法，用于调用百度地图使用
    /// </summary>
    class HandMap
    {


        /// <summary>
        /// 将指定的webbroser显示为5级的地图（中国地图轮廓）,供主窗口和安全区域绘制窗口调用
        /// </summary>
        /// <param name="webbroser">将要显示地图页面的webbroser控件</param>
        public static void ShowBaseMap(WebBrowser webbroser)
        {
            webbroser.Navigate(Application.StartupPath + "/Map.html");
        }

        /// <summary>
        /// 在地图中以窗口中心为中心，放置一个三角形，仅供安全区域绘制窗口调用
        /// </summary>
        /// <param name="webBroser">显示html文件或js文件的webbroser控件</param>
        public static void SetBaseArea(WebBrowser webBroser)
        {
            webBroser.Document.InvokeScript("showPolygon");          //调用js完成向地图中添加初始化图形的工作
        }
        /// <summary>
        /// 在地图中以窗口中心为中心，放置现有的安全区域图形，仅供安全区域绘制窗口调用,
        /// 有一个boolean型返回值，必须被用到
        /// </summary>
        /// <param name="webBroser">显示html文件或js文件的webbroser控件</param>
        /// <param name="areaStr">已经有的安全区域图形数据</param>
        /// <returns>返回布尔值，判断历史区域是否成功设置</returns>
        public static Boolean  SetHistoryArea(WebBrowser webBroser, string areaStr)
        {
            if (areaStr!="nra")
            {
                Object[] objArray = new Object[1];
                objArray[0] = areaStr;
                webBroser.Document.InvokeScript("setPolygon_1", objArray);
                return true;   //返回值说明设置成功，方便窗口判断图形是否设置成功
            }
            return false;    //返回值说明设置失败，方便窗口判断图形是否设置成功
        }
        /// <summary>
        /// 保存已经绘制好的图形，把图形数据返回给调用者
        /// </summary>
        /// <param name="webBroser">显示html文件或js文件的webbroser控件</param>
        /// <returns></returns>
        public static string SaveManArea(WebBrowser webBroser)
        {
            //调用js完成安全区域图形的数据保存
            string theAreaString = (string)webBroser.Document.InvokeScript("savePolygon");     
            return theAreaString;            
        }

        public static void ShowElderPoint(WebBrowser webBrowser,ElderInfor elder,RingData elderRing)
        {
            Object[] objArray = new Object[4]; //向js传入数据的数组
            objArray[0] = elderRing.lng;   //当前经度
            objArray[1] = elderRing.lat;    //当前纬度
            objArray[2] = elder.elderArea;   //活动区域
            objArray[3] = elder.elderName;   //本人姓名
            webBrowser.Document.InvokeScript("markMap", objArray);//向js文件传输坐标信息
        }
    }
}
