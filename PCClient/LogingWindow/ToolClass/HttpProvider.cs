using PCClintSoftware.BaseClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LogingWindow.Test;

namespace PCClintSoftware.ToolClass
{
    /// <summary>
    /// http请求的类，通过新建该类的对象来实现http的请求
    /// </summary>
    class HttpProvider
    {
        private const string RespHttpCookie = "Set-Cookie";      //响应流的http头cookie名
        private const string ReqHttpCookie = "Cookie";           //请求流的http头cookie名
        private const string METHOD_GET = "get";                 //get方式请求
        private const string METHOD_POST = "post";               //post方式请求
        private const string NULL = "null";             //null字符
        private static string session = "";            //session信息
        private Object httpObject = null;  //一个对象实例，用于传输json解析后的对象，请求http时用*************************基本没用，待考虑
        private Uri httpURL=null;     //URI实例
        private HttpWebRequest httpReq=null;  //HttpWebRequest实例，用于向指定的URL发送数据
        private HttpWebResponse httpResp = null; //HttpWebResPonse实例，用于响应URL请求
        UTF8Encoding encoding = new UTF8Encoding(false);   //注明utf-8去除BOM
        /// <summary>
        /// 指定HttpWevRequest的请求方式，默认为post方式
        /// </summary>
        public string method = METHOD_POST;  //指定HttpWevRequest的请求方式，默认为post方式
        /// <summary>
        /// 指定请求体的数据交互格式，默认为json
        /// </summary>
        private string contentType = "application/json";//指定请求体的数据交互格式，默认为json
        /// <summary>
        /// http请求时用于发送数据流的字符串
        /// </summary>
        public string sendStr ="";     //http请求时用于发送数据流的字符串*********************************基本没用
        //public string reciveStr = "";  //http请求时用于缓存响应数据的字符串

        /********************************
         * 外部类可以调用的方法
         *****************************/
        /// <summary>
        /// 设置数据传输格式，默认为"application/json"，该方法只在登录时调用
        /// </summary>
        /// <param name="type"></param>
        public void setcontentType(string type)
        {
            this.contentType = type;
            setSession("");     //清空session，由于登录时不需要携带session信息
        }
        /// <summary>
        /// 对外部类开放的接口，提供请求Http的服务，返回指定类型的对象
        /// 参数objType取值可以有有"ELDERINFOR"，"RINGDATA"，"LOGUSER","LISTELDER","LISTRINGDATA"
        /// </summary>
        /// <param name="obj">向http请求时提供内容的类，将被转换为json字符串</param>
        /// <param name="objType">标志位，用于指定将要返回的对象的类型，有"ELDERINFOR"，"RINGDATA"，"LOGUSER"</param>
        /// <returns>返回一个指定的对象，对象类型由objType指定</returns>
        public object HttpRequestObj(Object obj, string objType)
        {
            this.sendStr = JsonCode(obj);  //由对象转为json，指定json格式的字符串用于请求http，必须为json格式！！！！
            string httpRespStr = RequestHttp(sendStr);    //获取http响应的字符串
            return GetJsonCode(httpRespStr,objType);   //将http响应的json转化为相应的对象并返回，objType由上一级调用函数指定
        }
        /// <summary>
        /// 对外部类开放的接口，提供请求Http的服务，返回指定类型的对象
        /// 参数objType取值可以有有"ELDERINFOR"，"RINGDATA"，"LOGUSER","LISTELDER","LISTRINGDATA"
        /// </summary>
        /// <param name="str">json字符串，由调用该方法者直接提供</param>
        /// <param name="objType">标志位，用于指定将要返回的对象的类型，有"ELDERINFOR"，"RINGDATA"，"LOGUSER"</param>
        /// <returns>返回一个指定的对象，对象类型由objType指定</returns>
        public object HttpRequestObj(String str,string objType) {
            this.sendStr = str;     //直接给定json，指定json格式的字符串用于请求http，必须为json格式！！！！
            string httpRespStr = RequestHttp(str);    //获取http响应的字符串
            return GetJsonCode(httpRespStr, objType);   //将http响应的json转化为相应的对象并返回，objType由上一级调用函数指定
        }
        /// <summary>
        /// 对外部类开放的接口，提供请求Http的服务，返回普通字符串
        /// </summary>
        /// <param name="obj">向http请求时提供内容的类，将被转换为json字符串</param>
        /// <returns>返回一个普通字符串</returns>
        public string HttpRquestStr(Object obj) {
            this.sendStr = JsonCode(obj);  //由对象转为json，指定json格式的字符串用于请求http，必须为json格式！！！！
            return RequestHttp(sendStr);   //讲http响应的字符串直接返回        
        }
        /// <summary>
        /// 对外部类开放的接口，提供请求Http的服务，返回普通字符串
        /// </summary>
        /// <param name="str">json字符串，由调用该方法者直接提供</param>
        /// <returns>对外部类开放的接口，提供请求Http的服务</returns>
        public string HttpRquestStr(String str) {
            this.sendStr = str;     //直接给定json，指定json格式的字符串用于请求http，必须为json格式！！！！
            return RequestHttp(str);   //讲http响应的字符串直接返回
        }
        /// <summary>
        /// 以get方式向服务器发起请求，并获取一个普通字符串
        /// </summary>
        /// <returns>返回一个普通字符串</returns>
        public string HttpGetResponseStr()
        {
            //发送请求
            if (method != METHOD_GET)
            {
                method = METHOD_GET;
            }
            return RequestHttp(NULL);
        }
        /// <summary>
        /// 以get方式向服务器发起请求
        /// 参数objType可选值有"ELDERINFOR"，"RINGDATA"，"LOGUSER","LISTELDER","LISTRINGDATA","LISTLOGUSER"
        /// </summary>
        /// <param name="objType">标志位，用于指定将要返回的对象的类型，有"ELDERINFOR"，"RINGDATA"，"LOGUSER"</param>
        /// <returns>返回一个指定类型的对象</returns>
        public object HttpGetResponseObj(string objType) {
            if (method != METHOD_GET)
            {
                method = METHOD_GET;
            }
            string httpRespStr = RequestHttp(NULL);    //获取http响应的字符串
            return GetJsonCode(httpRespStr, objType);   //将http响应的json转化为相应的对象并返回，objType由上一级调用函数指定
        }
        /***************************************
         * 本类内部处理逻辑关系的方法
         *************************************/
        /// <summary>
        /// 更新session信息，本类方法可调用
        /// </summary>
        /// <param name="sessionID"></param>
        private void setSession(String sessionID)
        {
            session = sessionID;
        }
        /// <summary>
        /// 在sendStr更新内容后，以POST方式向服务器发送URL请求并获取其返回值，该方法只能被类内部方法调用
        /// </summary>
        ///  <param name="httpReqStr">向http请求时提供内容json字符串，由调用者提供，和属性sendStr取值相同</param>
        /// <returns>返回一个由http响应的字符串，可能是json，也可能是普通字符</returns>
        private string RequestHttp(string httpReqStr)
        {
            Console.WriteLine("请求url：" + httpURL);      //打印每次请求链接
            Console.WriteLine("请求内容：" + httpReqStr);      //打印每次请求内容
            //发送请求
            this.httpReq = (HttpWebRequest)WebRequest.Create(httpURL);    //发送请求的实例配置
            this.httpReq.Method = method;    //配置请求方式
            this.httpReq.Timeout = 10000;    //设置请求超时的时间，为10s
            this.httpReq.ProtocolVersion = HttpVersion.Version11;
            this.httpReq.ContentType = contentType;  //配置请求体的数据格式
            this.httpReq.Headers.Add(ReqHttpCookie, session);
            Console.WriteLine("request session:" + session);
            //this.httpReq.ServicePoint.Expect100Continue = false;   //post方式下，当服务器返回错误或无响应时，继续发起请求，而不是返回错误信息
            if (method == METHOD_POST)
            {
            //用流向服务器发送出请求字符串
            Stream myRequestStream = httpReq.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, encoding);
            myStreamWriter.Write(httpReqStr);
            myStreamWriter.Close();
            }
            //响应请求
            this.httpResp = (HttpWebResponse)httpReq.GetResponse();   //响应请求实例
            if (httpResp.Headers.Get(RespHttpCookie) != null && !httpResp.Headers.Get(RespHttpCookie).Equals(session)) //判断session是否相等，不相等则更新session信息
            {
                setSession(httpResp.Headers.Get(RespHttpCookie));
            }
            Console.WriteLine("Cookie: " + httpResp.Headers.Get("Set-Cookie"));
            //用数据流缓存响应得到的数据
            Stream respStream = httpResp.GetResponseStream();
            StreamReader respStreamReader = new StreamReader(respStream, encoding);
            string recivedStr = respStreamReader.ReadToEnd();
            //Console.WriteLine("返回值："+recivedStr);      //打印每次返回结果
            return recivedStr;  //返回json格式的响应数据流(格式已经由服务器指定为json)
        }
        /// <summary>
        /// 将指定对象转化为json数据流，并返回数据，该方法只被类内部方法调用
        /// </summary>
        /// <param name="obj">为所需要转化的对象</param>
        /// <returns>返回一个json数据流</returns>
        private string JsonCode(Object obj)
        {
            string jsonCodeStr = JSON.stringify(obj);    //将传输来的对象参数转化为json数据流
            return jsonCodeStr;
        }
        /// <summary>
        /// 将http响应的json字符串转化为对应的类
        /// 参数objType取值可以有有"ELDERINFOR"，"RINGDATA"，"LOGUSER"，"LISTRINGDATA"，"LISTELDER"
        /// </summary>
        /// <param name="jsonStr">json字符串，一般是由http响应得到的</param>
        /// <param name="objType">整型参数，用于指定最终返回的对象的类型，
        /// 有五种类型"ELDERINFOR"，"RINGDATA"，"LOGUSER"，"LISTELDER"，"LISTRINGDATA"</param>
        /// <returns>返回一个被指定的类型的对象</returns>
        private object GetJsonCode(string jsonStr,string objType) {
            Object jsonObject=null;   //临时变量，用于传输json数据流转换后的对象
            switch(objType)    //判断需要返回的
            {
                case ConstantMember.ELDERINFOROBJ: jsonObject = JSON.parse<ElderInfor>(jsonStr);  //将对象赋值为老人对象
                    break;
                case ConstantMember.RINGDATAOBJ: jsonObject = JSON.parse<RingData>(jsonStr);   //将对象赋值为手环数据对象
                    break;
                case ConstantMember.LOGUSEROBJ: jsonObject = JSON.parse<LogUser>(jsonStr);    //将对象赋值为用户对象
                    break;
                case ConstantMember.LISTELDEROBJ: jsonObject = JSON.parse<List<ElderInfor>>(jsonStr);   //将对象赋值为老人对象集合
                    break;
                case ConstantMember.LISTRINGDATAOBJ: jsonObject = JSON.parse<List<RingData>>(jsonStr); //将对象赋值为手环数据对象集合
                    break;
                case ConstantMember.LISTLOGUSEROBJ: jsonObject = JSON.parse<List<LogUser>>(jsonStr);   //将对象赋值为用户对象集合
                    break;
                default:
                    break;
            }
            return jsonObject;
        }
        /*******************************
         * 构造方法
         ********************************/
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="urlStr">所需要请求的URL地址，字符串</param>
        public HttpProvider(string urlStr) {
            this.httpURL = new Uri(urlStr);      //初始化URL，配置URL路径
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="urlStr">所需要请求的URL地址，字符串</param>
        /// <param name="method">数据传输格式</param>
        public HttpProvider(string urlStr,string method) {
            this.httpURL = new Uri(urlStr);        //初始化URL，配置URL路径
            this.method = method;   //配置传输格式
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="urlStr">所需要请求的URL地址，字符串</param>
        /// <param name="method">数据传输方法</param>
        /// <param name="sendJsonStr">将要发送的json格式字符串</param>
        public HttpProvider(string urlStr, string method,string sendJsonStr)
        {
            this.httpURL = new Uri(urlStr);        //初始化URL，配置URL路径
            this.method = method;   //配置传输格式
            this.sendStr = sendJsonStr;      //给定请求URL时所传输的字符串
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="urlStr">所需要请求的URL地址，字符串</param>
        /// <param name="method">数据传输方法</param>
        /// <param name="obj">将要发送的数据对象，会被转换为json数据流</param>
        public HttpProvider(string urlStr, string method, Object obj)
        {
            this.httpURL = new Uri(urlStr);        //初始化URL，配置URL路径
            this.method = method;   //配置传输格式
            this.httpObject = obj;      //给定请求URL时所传输的对象，将被转换为json数据流
        }
    }
}
