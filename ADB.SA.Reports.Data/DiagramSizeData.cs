using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ADB.SA.Reports.Data
{
    public class DiagramSizeData
    {
        Database db;
        public DiagramSizeData()
        {
            db = DatabaseFactory.CreateDatabase("ExtendedDb");
        }

        public bool SaveSize(int id, float percentage)
        {
            int result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format("UPDATE DiagramSize SET [Percentage]={0} WHERE [DiagramID]={1}", percentage, id)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
            return result > 0;
        }

        public double GetPercentage(int id)
        {
            double result = 5.0;
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format("SELECT Percentage FROM DiagramSize WHERE [DiagramID]={0}", id)))
            {
                result = (double)db.ExecuteScalar(cmd);
            }
            return result;
        }
    }
}
