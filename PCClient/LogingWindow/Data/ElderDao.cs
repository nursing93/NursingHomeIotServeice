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
            string sql = "SELECT [ID] [编号],[name] [姓名] from ElderBaseData WHERE [name] LIKE  @name ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = "%" + searchStr + "%";
            DataTable dt = getDataTable(new SqlCeDataAdapter(cmmd));
            dataSrc.freeSyncSouce();
            return dt;
        }

        public DataTable listAsDataTable(string searchStr)
        {
            string sql = "SELECT [ID] [编号],[name] [姓名],[birthday] [生日],[sex] [性别],[idCard] [身份证],[phone] [联系方式],[area] [安全区域] "
                       + "from ElderBaseData WHERE [name] LIKE  @name ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = "%" + searchStr + "%";
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

        public List<ElderInfo> list()
        {
            string sql = "SELECT [ID],[name],[birthday],[sex],[idCard],[phone],[area] from ElderBaseData ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            SqlCeDataReader dr = cmmd.ExecuteReader();
            List<ElderInfo> list = new List<ElderInfo>();
            while (dr.Read())
            {
                list.Add(getElderWithDataReader(dr));
            }
            dr.Close();
            dataSrc.freeSyncSouce();
            return list;
        }

        public ElderInfo get(string id)
        {
            string sql = "SELECT [ID],[name],[birthday],[sex],[idCard],[phone],[area] from ElderBaseData WHERE [ID] =  @ID ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = id;
            SqlCeDataReader dr = cmmd.ExecuteReader();
            ElderInfo info = dr.Read() ? getElderWithDataReader(dr) : (ElderInfo.getInvalidInst());
            dr.Close();
            dataSrc.freeSyncSouce();
            return info;
        }

        private ElderInfo getElderWithDataReader(SqlCeDataReader dr)
        {
            ElderInfo info = new ElderInfo();
            try
            {
                info.id = dr.GetString(0);
                info.name = dr.GetString(1);
                info.birthday = dr.GetDateTime(2).ToString();
                info.sex = dr.GetString(3);
                info.idCard = dr.GetString(4);
                info.phone = dr.GetString(5);
                info.area = dr.GetString(6);
            }
            catch (Exception e)
            {
                MessageBox.Show("read ElderInfo from DataReader Faild!\n" + e);
            }
            return info;
        }

        public void create(ElderInfo info)
        {
            if (get(info.id).isValid())
            {
                MessageBox.Show("elder[id=" + info.id + "] alerady existed! try again with new id!");
                return;
            }
            string sql = "INSERT INTO ElderBaseData VALUES(@ID, @name, @birthday, @sex, @area, @idCard, @phone)";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = info.id;
            cmmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = info.name;
            cmmd.Parameters.Add("@sex", SqlDbType.NVarChar, 50, "sex").Value = info.sex;
            cmmd.Parameters.Add("@birthday", SqlDbType.DateTime, 8, "birthday").Value = Convert.ToDateTime(info.birthday);
            cmmd.Parameters.Add("@idCard", SqlDbType.NVarChar, 50, "idCard").Value = info.idCard;
            cmmd.Parameters.Add("@phone", SqlDbType.NVarChar, 50, "phone").Value = info.phone;
            cmmd.Parameters.Add("@area", SqlDbType.NVarChar, 2000, "area").Value = info.area;
            dataSrc.execSyncNonQuery(cmmd);
        }

        public void update(ElderInfo info)
        {
            if (!get(info.id).isValid())
            {
                MessageBox.Show("elder[id=" + info.id + "] is not existed! try again with valid id!");
                return;
            }
            string sql = "UPDATE ElderBaseData SET [name]=@name, [birthday]=@birthday, "
                      + "[sex]=@sex, [phone]=@phone, [idCard]=@idCard, [area]=@area "
                      + " WHERE  [ID]=@ID ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = info.id;
            cmmd.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name").Value = info.name;
            cmmd.Parameters.Add("@sex", SqlDbType.NVarChar, 50, "sex").Value = info.sex;
            cmmd.Parameters.Add("@birthday", SqlDbType.DateTime, 8, "birthday").Value = Convert.ToDateTime(info.birthday);
            cmmd.Parameters.Add("@idCard", SqlDbType.NVarChar, 50, "idCard").Value = info.idCard;
            cmmd.Parameters.Add("@phone", SqlDbType.NVarChar, 50, "phone").Value = info.phone;
            cmmd.Parameters.Add("@area", SqlDbType.NVarChar, 2000, "area").Value = info.area;
            dataSrc.execSyncNonQuery(cmmd);
        }

        public void delete(ElderInfo info)
        {
            if (!get(info.id).isValid())
            {
                MessageBox.Show("elder[id=" + info.id + "] is not existed!");
                return;
            }
            string sql = "delete FROM ElderBaseData WHERE [ID]=@ID ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50, "ID").Value = info.id;
            dataSrc.execSyncNonQuery(cmmd);
        }

    }
}
