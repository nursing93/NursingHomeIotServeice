using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingWindow.ToolClass
{
    public static class WinformName 
    {
        public const string UDFORMDETAILTAB = "userDetails";

        public const string UDFORMPASSWORDTAB = "amendPassword";

        public const string EMFORMCREATRTAB = "";

        public const string EMFORMAMENDRTAB = "amendRecord";

        public const string EMFORMDELETRTAB = "deleteRecord";

        public const string ADFORMUSERLISTTAB = "userListTab";

        public const string ADFORMUSERMANAGETAB = "userManageTab";
    }

    public static class ComboBoxDropDownCaller
    {
        /*************************************************************
         * 用于判断ComboBoxDropDown()方法是被谁调用，下拉框时间参数
         * ******************************************************/
        /// <summary>
        /// ComboBoxDropDown()方法将被修改（删除）窗口—姓名下拉框 调用
        /// </summary>
        public const string NameComboBox = "CNameComboBoxDropDown";
        /// <summary>
        /// ComboBoxDropDown()方法将被修改（删除）窗口—编号下拉框 调用
        /// </summary>
        public const string IDComboBox = "CIDComboBoxDropDown";
    }
}
