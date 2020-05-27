using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.ToolClass
{
    public static class HttpURLs
    {
        private const string host = "http://localhost:8080/ElderLinkWebServer";

        public const string LOGINGURL = host + "/login";

        public const string LOGOUTURL = host + "/logout";

        public const string QUERYALLELDERURL = host + "/elder/listAll";

        public const string ADDRECORDURL = host + "/elder/newID";

        public const string SAVERECORDURL = host + "/elder/create";

        public const string QUERYTRECORDURL = host + "/elder/find/";

        public const string AMENDRECORDURL = host + "/elder/update";

        public const string DELETRECORDURL = host + "/elder/delete";

        public const string GRRINGDATAURL = host + "/ring/lastRecord/";

        public const string QEALLRINGDATAURL = host + "/ring/listByTime/";

        public const string QUERYALLUSERURL = host + "/user/listAll";

        public const string QUERYUSERDETAILURL = host + "/user/find/";

        public const string ADDUSERURL = host + "/user/create";

        public const string AMENDUSERURL = host + "/user/update";

        public const string DELETEUSERURL = host + "/user/delete/";

        public const string AMENDPASSWORDURL = host + "/user/password";
    }

    public static class HttpMethod
    {
        public const string GET = "get";
        public const string POST = "post";
    }

    public static class LogingResult
    {
        public const string ADMINISTRATOR = "ADMINISTRATOR";

        public const string USERPERMIT = "USERPERMIT";

        public const string NOPERMISSION = "NOPERMISSION";

        public const string WRONGPASSWORD = "WRONGPASSWORD";

        public const string WEBEXCEPTION = "WEBEXCEPTION";

        public const string LOGING = "LOGING";
    }

    public static class HttpRspState
    {
        public const string ADDELDER_SUCCESS = "ADD_SUCCESS";

        public const string ADDELDER_FAILD = "ADD_FAILD";

        public const string AMENDELDER_SUCCESS = "UPDATE_SUCCESS";

        public const string AMENDELDER_FAILD = "UPDATE_FAILD";

        public const string DELETEELDER_SUCCESS = "DEL_SUCCESS";

        public const string DELETEELDER_FAILD = "DEL_FAILD";

        public const string CREATUSER_SUCCESS = "ADD_SUCCESS";

        public const string CREATUSER_FAILD = "ADD_FAILD";

        public const string CREATUSER_SAMENAME = "REPEATNAME";

        public const string AMENDUSER_SUCCESS = "UPDATE_SUCCESS";

        public const string AMENDUSER_FAILD = "UPDATE_FAILD";

        public const string DELETEUSER_SUCCESS = "DEL_SUCCESS";

        public const string DELETEUSER_FAILD = "DEL_FAILD";

        public const string AMENDPASSWORD_SUCCESS = "UPDATE_SUCCESS";

        public const string AMENDPASSWORD_FAILD = "UPDATE_FAILD";
    }

    public static class JsonToObjectType
    {
        public const string LOGUSEROBJ = "LOGUSER";

        public const string ELDERINFOROBJ = "ELDERINFOR";

        public const string RINGDATAOBJ = "RINGDATA";

        public const string LISTELDEROBJ = "LISTELDER";

        public const string LISTRINGDATAOBJ = "LISTRINGDATA";

        public const string LISTLOGUSEROBJ = "LISTLOGUSER";
    }
}
