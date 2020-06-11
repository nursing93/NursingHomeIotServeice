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
    class ElderDao
    {
        DataSource dataSrc;

        public ElderDao()
        {
            dataSrc = new DataSource();
        }

        public DataTable listNameAsDataTable(string searchStr)
        {
            string sql = "SELECT [ID] [编号],[name] [姓名] from ElderBaseData WHERE [name] LIKE  @姓名 ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "姓名").Value = "%" + searchStr + "%";
            DataTable dt = getDataTable(new SqlCeDataAdapter(cmmd));
            dataSrc.freeSyncSouce();
            return dt;
        }

        public DataTable listAsDataTable(string searchStr)
        {
            string sql = "SELECT * from ElderBaseData WHERE [name] LIKE  @姓名 ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@姓名", SqlDbType.NVarChar, 50, "姓名").Value = "%" + searchStr + "%";
            DataTable dt = getDataTable(new SqlCeDataAdapter(cmmd));
            dataSrc.freeSyncSouce();
            return dt;
        }

        private DataTable getDataTable(SqlCeDataAdapter da)
        {
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("open data source failed!\n" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("database failed! other exception:\n" + e);
            }
            return dt;
        }

        public ElderInfor get(string id)    //TODO 验证
        {
            string sql = "SELECT * from ElderBaseData WHERE [ID] =  @ID ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = id;
            SqlCeResultSet ds = cmmd.ExecuteResultSet(ResultSetOptions.None);
            ElderInfor elder;
            if (ds.ReadFirst())
            {
                elder = (ElderInfor)ds[0];
            }
            else
            {
                elder = new ElderInfor();
            }
            dataSrc.freeSyncSouce();
            return elder;
        }

    }
}
