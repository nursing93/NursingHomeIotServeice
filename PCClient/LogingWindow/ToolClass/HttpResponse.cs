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
    class HttpResponse
    {
        private UTF8Encoding encoding = new UTF8Encoding(false);   //注明utf-8去除BOM
        private HttpWebResponse httpResp = null;
        private string result = null;

        public HttpResponse(HttpWebResponse httpResp)
        {
            this.httpResp = httpResp;
            getResultStr();
        }

        public string getSession()
        {
            return httpResp.Headers.Get("Set-Cookie");
        }

        public string getToken()
        {
            return httpResp.Headers.Get("token");
        }

        public bool needUpdateSession(string oldSession)
        {
            return httpResp.Headers.Get("Set-Cookie") != null && !httpResp.Headers.Get("Set-Cookie").Equals(oldSession);
        }

        public bool needUpdateToken(string oldSession)
        {
            return httpResp.Headers.Get("token") != null && !httpResp.Headers.Get("token").Equals(oldSession);
        }

        private void getResultStr()
        {
            Stream respStream = httpResp.GetResponseStream();
            StreamReader respStreamReader = new StreamReader(respStream, encoding);
            result = respStreamReader.ReadToEnd();
        }
        public string getResult()
        {
            return result;
        }

        public T getResultAsObj<T>()    //TODO 设置空对象保护
        {
            return JSON.parse<T>(result); ;
        }

        public List<T> getResultAsObjList<T>()
        {
            return JSON.parse<List<T>>(result);;
        }
    }
}
