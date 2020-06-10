using LogingWindow.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow.ToolClass
{
    class MapHandler
    {
        public static void ShowBaseMap(WebBrowser webbroser)
        {
            webbroser.Navigate(Application.StartupPath + "/Map.html");
        }

        public static void SetBaseArea(WebBrowser webBroser)
        {
            webBroser.Document.InvokeScript("showPolygon"); 
        }

        public static Boolean  SetHistoryArea(WebBrowser webBroser, string areaStr)
        {
            if (areaStr!="nra")
            {
                Object[] objArray = new Object[1];
                objArray[0] = areaStr;
                webBroser.Document.InvokeScript("setPolygon_1", objArray);
                return true;
            }
            return false;
        }

        public static string SaveManArea(WebBrowser webBroser)
        {
            string theAreaString = (string)webBroser.Document.InvokeScript("savePolygon");     
            return theAreaString;            
        }

        public static void ShowElderPoint(WebBrowser webBrowser,ElderInfor elder,RingData elderRing)
        {
            Object[] objArray = new Object[4];
            objArray[0] = elderRing.lng;
            objArray[1] = elderRing.lat;
            objArray[2] = elder.area;
            objArray[3] = elder.name;
            webBrowser.Document.InvokeScript("markMap", objArray);
        }
    }
}
