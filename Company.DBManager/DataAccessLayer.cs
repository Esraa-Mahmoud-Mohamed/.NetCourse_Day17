using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
namespace Company.DBManager
{
    public class DataAccessLayer
    {
        //select [Disconnected]
        public static DataTable ExecuteQuery(string query)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Company"].ConnectionString);
            SqlCommand command=new SqlCommand(query,con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }


        //Insert,update,delete [connected]
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters) 
        {
            int affected;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Company"].ConnectionString);
            SqlCommand command=new SqlCommand(query,con);  
            command.Parameters.AddRange(parameters);

            try
            {
                con.Open();
                affected=command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }

            return affected;
        }
    }
}
