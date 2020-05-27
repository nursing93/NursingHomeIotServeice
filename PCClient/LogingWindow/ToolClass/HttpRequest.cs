using PCClintSoftware.ToolClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.ToolClass
{
    class HttpRequest
    {
        private static string session = "";
        private UTF8Encoding encoding = new UTF8Encoding(false);   //注明utf-8去除BOM

        private HttpWebRequest httpReq = null;


        private HttpResponse response = null;

        public HttpRequest(string urlStr)
        {
            httpReq = (HttpWebRequest)WebRequest.Create(new Uri(urlStr));
            setMethod(HttpMethod.POST);
            httpReq.Timeout = 10000;
            httpReq.ProtocolVersion = HttpVersion.Version11;
            setContentType("application/json");
            //TODO 部分情况下需要将session清空
            setSession(session);
        }

        public void setMethod(string method)
        {
            httpReq.Method = method;
        }

        public void setContentType(string contentType)
        {
            httpReq.ContentType = contentType;
        }

        private void setSession(string session)
        {
            httpReq.Headers.Add("Cookie", session);
        }

        public HttpResponse request(Object obj)
        {
            string reqMsg = JSON.stringify(obj);
            return request(reqMsg);
        }

        private HttpResponse request(string reqMsg)
        {
            Console.WriteLine("请求url：" + httpReq.RequestUri);
            Console.WriteLine("请求内容：" + reqMsg);
            if (method() == HttpMethod.POST)
            {
                Stream myRequestStream = httpReq.GetRequestStream();
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream, encoding);
                myStreamWriter.Write(reqMsg);
                myStreamWriter.Close();
            }
            response = new HttpResponse((HttpWebResponse)httpReq.GetResponse());
            if (response.needUpdateSession(session))
            {
                session = response.getSession();
            }
            return response;
        }

        private string method()
        {
            return httpReq.Method;
        }

    }
}
