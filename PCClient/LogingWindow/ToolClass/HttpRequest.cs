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

        public HttpRequest(string urlStr, string method = HttpMethod.POST)
        {
            httpReq = (HttpWebRequest)WebRequest.Create(new Uri(urlStr));
            setMethod(method);
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
            return doRequest(reqMsg);
        }

        public HttpResponse request()
        {
            return doRequest("");  //TODO 空串定义为常量
        }

        public HttpResponse request(string reqMsg)
        {
            return doRequest(reqMsg);
        }

        private HttpResponse doRequest(string reqMsg)
        {
            Console.WriteLine("url：" + httpReq.RequestUri);
            Console.WriteLine("content：" + reqMsg);
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
            return httpReq.Method.ToLower();
        }

    }
}
