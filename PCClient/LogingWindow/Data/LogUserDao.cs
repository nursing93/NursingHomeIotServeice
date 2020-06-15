using LogingWindow.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow.Data
{
    class LogUserDao
    {
        DataSource dataSrc;
        public LogUserDao()
        {
            dataSrc = new DataSource();
        }

        public void create(LogUser user)
        {
            if (get(user.id).isValid())
            {
                MessageBox.Show("logUser[id=" + user.id + "] alerady existed! try again with new id!");
                return;
            }
            string sql = "INSERT INTO UserList  VALUES ( @ID, @password, @needSavePas )";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = user.id;
            cmmd.Parameters.Add("@password", SqlDbType.NVarChar, 50, "password").Value = user.password;
            cmmd.Parameters.Add("@needSavePas", SqlDbType.NVarChar, 50, "isSavePassword").Value = user.isSavePassword;
            dataSrc.execSyncNonQuery(cmmd);
        }

        public void update(LogUser user)
        {
            if (!get(user.id).isValid())
            {
                MessageBox.Show("logUser[id=" + user.id + "] is not existed! try again with valid id!");
                return;
            }
            string sql = "UPDATE UserList SET [ID]= @ID, [password]=@password, [isSavePassword]=@needSavePass  WHERE [ID]=@ID";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = user.id;
            cmmd.Parameters.Add("@password", SqlDbType.NVarChar, 50, "password").Value = user.password;
            cmmd.Parameters.Add("@needSavePass", SqlDbType.NVarChar, 50, "isSavePassword").Value = user.isSavePassword;
            dataSrc.execSyncNonQuery(cmmd);
        }

        public LogUser get(string id)
        {
            string sql = "SELECT [ID], [password], [isSavePassword] FROM  UserList  WHERE [ID] = @ID";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = id;
            SqlCeDataReader dr = cmmd.ExecuteReader();
            LogUser user = dr.Read() ? getLogUserWithDataReader(dr) : LogUser.getInvalidInst();
            dr.Close();
            dataSrc.freeSyncSouce();
            return user;
        }

        public List<LogUser> list()
        {
            string sql = "SELECT [ID], [password], [isSavePassword] FROM  UserList";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            SqlCeDataReader dr = cmmd.ExecuteReader();
            List<LogUser> list = new List<LogUser>();
            while(dr.Read())
            {
                list.Add(getLogUserWithDataReader(dr));
            }
            dr.Close();
            dataSrc.freeSyncSouce();
            return list;
        }

        private LogUser getLogUserWithDataReader(SqlCeDataReader dr)
        {
            LogUser user = new LogUser();
            try
            {
                user.id = dr.GetString(0);
                user.password = dr.GetString(1);
                user.isSavePassword = dr.GetInt32(2);
            }
            catch (Exception e)
            {
                MessageBox.Show("read LogUser from DataReader Faild!\n" + e);
            }
            return user;
        }

        public void delete(LogUser user)
        {
            if (!get(user.id).isValid())
            {
                MessageBox.Show("logUser[id=" + user.id + "] is not existed!");
                return;
            }
            string sql = "delete FROM UserList WHERE [ID]=@ID ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = user.id;
            dataSrc.execSyncNonQuery(cmmd);
        }
    }
}
