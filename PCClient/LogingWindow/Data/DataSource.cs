using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWindow.Data
{
    class DataSource
    {
        private static string CON_FORM = @"Data Source=" + Application.StartupPath + @"\..\..\LocalDataBase.sdf";
        private SqlCeConnection con;
        private object dbLock = new Object();

        public DataSource()
        {
            con = new SqlCeConnection(CON_FORM);
        }

        public SqlCeCommand getSyncSqlCeCommand(string command)
        {
            Monitor.Enter(dbLock);
            return getSqlCeCommand(command);
        }

        public SqlCeCommand getSqlCeCommand(string command)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return new SqlCeCommand(command, con);
        }

        public void freeSyncSouce()
        {
            freeSouce();
            Monitor.Exit(dbLock);
        }

        public void freeSouce()
        {
            con.Close();
        }

        public void execSyncNonQuery(SqlCeCommand cmmd)
        {
            try
            {
                cmmd.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("open data source failed!\n" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("database failed! other exception:\n" + e);
            }
            finally
            {
                freeSyncSouce();
            }
        }

    }
}
