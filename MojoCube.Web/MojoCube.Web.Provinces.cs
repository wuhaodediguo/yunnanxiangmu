using System;
using System.Data.OleDb;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MojoCube.Web.Provinces
{

    public class Provinces
    {
        public string id { set; get; }
        public string provinceid { set; get; }
        public string province { set; get; }

        public IList<Provinces> GetProvicesList()
        {
            IList<Provinces> result = new List<Provinces>();


            OleDbConnection oleDbConnection = new OleDbConnection(Connection.ConnString());
            try
            {
                oleDbConnection.Open();
                string cmdText = @"select * from Provinces order by ID asc";
                OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                OleDbDataReader dr = oleDbCommand.ExecuteReader();

                while (dr.Read())
                {
                    result.Add(new Provinces() { id = dr["id"].ToString(), provinceid = dr["provinceid"].ToString(), province = dr["province"].ToString() });
                }
            }
            catch
            {
                result = null;
            }
            finally
            {
                oleDbConnection.Close();
            }


            return result;
        }

    }
}
