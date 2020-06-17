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
    class RingRecordDao
    {
        static long ringRecoedId = 0;
        DataSource dataSrc;
        public RingRecordDao()
        {
            dataSrc = new DataSource();
        }

        public void create(RingRecord record)
        {
            string sql = "INSERT INTO ringRecord (elderId,heartRate,bloodPressure,temperature,lng,lat,time,keyEvent) " +
                        "  VALUES ( @elderId, @heartRate, @bloodPressure, @temperature, @lng, @lat, @time, @keyEvent)";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@elderId", SqlDbType.NVarChar, 50, "elderId").Value = record.id.ToString();
            cmmd.Parameters.Add("@heartRate", SqlDbType.Int, 4, "heartRate").Value = record.physical.heartRate;
            cmmd.Parameters.Add("@bloodPressure", SqlDbType.Int, 4, "bloodPressure").Value = record.physical.bloodPressure;
            cmmd.Parameters.Add("@temperature", SqlDbType.Int, 4, "temperature").Value = record.physical.temperature;
            cmmd.Parameters.Add("@lng", SqlDbType.NVarChar, 50, "lng").Value = record.position.lng;
            cmmd.Parameters.Add("@lat", SqlDbType.NVarChar, 50, "lat").Value = record.position.lat;
            cmmd.Parameters.Add("@time", SqlDbType.DateTime, 8, "time").Value = DateTime.Parse(record.time);
            cmmd.Parameters.Add("@keyEvent", SqlDbType.Int, 4, "keyEvent").Value = record.keyEvent;
            dataSrc.execSyncNonQuery(cmmd);
        }

        public void delete(RingRecord record)
        {
            string sql = "delete FROM ringRecord WHERE [elderId]=@elderId ";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@elderId", SqlDbType.NVarChar, 50, "elderId").Value = record.id.ToString();
            dataSrc.execSyncNonQuery(cmmd);
        }

        public RingRecord getLast(int elderId)    //TODO 优化，只读第一条
        {
            string sql = "SELECT [elderId], [heartRate], [bloodPressure], [temperature], [lng], [lat], [time], [keyEvent] FROM  ringRecord WHERE" +
                        " id in (SELECT MAX(id) FROM ringRecord WHERE [elderId] = @elderId GROUP BY elderId)";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@elderId", SqlDbType.NVarChar, 50, "elderId").Value = elderId.ToString();
            SqlCeDataReader dr = cmmd.ExecuteReader();
            RingRecord record = dr.Read() ? getRingRecordWithDataReader(dr) : RingRecord.defaultRecord();
            return record;
        }

        public RingRecord getWithTime(int elderId, string dateTime)
        {
            string sql = "SELECT [elderId], [heartRate], [bloodPressure], [temperature], [lng], [lat], [time], [keyEvent] FROM  ringRecord WHERE" +
                        " id=@elderId AND time=@time";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@elderId", SqlDbType.NVarChar, 50, "elderId").Value = elderId.ToString();
            cmmd.Parameters.Add("@time", SqlDbType.DateTime, 8, "time").Value = Convert.ToDateTime(dateTime);
            SqlCeDataReader dr = cmmd.ExecuteReader();
            RingRecord record = dr.Read() ? getRingRecordWithDataReader(dr) : RingRecord.defaultRecord();
            return record;
        }

        private RingRecord getRingRecordWithDataReader(SqlCeDataReader dr)
        {
            RingRecord record = new RingRecord();
            try
            {
                record.id = Int32.Parse(dr.GetString(0));
                record.physical.heartRate = dr.GetInt32(1);
                record.physical.bloodPressure = dr.GetInt32(2);
                record.physical.temperature = dr.GetInt32(3);
                record.position.lng = dr.GetDouble(4);
                record.position.lat = dr.GetDouble(5);
                record.time = dr.GetDateTime(6).ToString();
                record.keyEvent = (KeyEvent)Enum.ToObject(typeof(KeyEvent), dr.GetInt32(7));

            }
            catch (Exception e)
            {
                MessageBox.Show("read LogUser from DataReader Faild!\n" + e);
            }
            return record;
        }

        public List<RingRecord> list(int elderId)
        {
            string sql = "SELECT [elderId], [heartRate], [bloodPressure], [temperature], [lng], [lat], [time], [keyEvent] FROM  ringRecord WHERE [elderId] = @elderId";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            cmmd.Parameters.Add("@elderId", SqlDbType.NVarChar, 50, "elderId").Value = elderId.ToString();
            SqlCeDataReader dr = cmmd.ExecuteReader();
            List<RingRecord> list = new List<RingRecord>();
            while (dr.Read())
            {
                list.Add(getRingRecordWithDataReader(dr));
            }
            return list;
        }

        public List<RingRecord> listLastRecords()
        {
            string sql = "SELECT [elderId], [heartRate], [bloodPressure], [temperature], [lng], [lat], [time], [keyEvent] FROM  ringRecord where id in (select MAX(id) from ringRecord group by elderId)";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            SqlCeDataReader dr = cmmd.ExecuteReader();
            List<RingRecord> list = new List<RingRecord>();
            while (dr.Read())
            {
                list.Add(getRingRecordWithDataReader(dr));
            }
            return list;
        }

        public List<RingRecord> listAll()
        {
            string sql = "SELECT [elderId], [heartRate], [bloodPressure], [temperature], [lng], [lat], [time], [keyEvent] FROM  ringRecord";
            SqlCeCommand cmmd = dataSrc.getSyncSqlCeCommand(sql);
            SqlCeDataReader dr = cmmd.ExecuteReader();
            List<RingRecord> list = new List<RingRecord>();
            while (dr.Read())
            {
                list.Add(getRingRecordWithDataReader(dr));
            }
            return list;
        }

    }
}
