using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BusinessLayer
{
    public class EmployeeBL
    {
        public static DataTable GetAll()
        {
            string query = "select * from employee";
            return Company.DBManager.DataAccessLayer.ExecuteQuery(query);
        }
        public static DataTable GetOne(string id)
        {
            var query = $"select * from employee where ssn='{id}'";
            return Company.DBManager.DataAccessLayer.ExecuteQuery(query);
        }
        public static int Add(Employee emp1)
        {
            var query = "insert into employee (ssn,fname,lname,address) values(@id,@fn,@ln,@address)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",emp1.ssn),
                new SqlParameter("@fn",emp1.fname),
                new SqlParameter("@ln",emp1.lname),
                new SqlParameter("@address",emp1.Address)
            };
            return Company.DBManager.DataAccessLayer.ExecuteNonQuery(query, parameters);
        }
        public static int Update(Employee a1)
        {
            var query = "update employee set fname=@fn,lname=@ln,address=@address where ssn=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",a1.ssn),
                new SqlParameter("@fn",a1.fname),
                new SqlParameter("@ln",a1.lname),
                new SqlParameter("@address",a1.Address)
            };
            return Company.DBManager.DataAccessLayer.ExecuteNonQuery(query,parameters);
        }
        public static int  Delete(string id) 
        {
            var query = "delete from employee where ssn=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            return Company.DBManager.DataAccessLayer.ExecuteNonQuery (query, parameters);
        }
    }

    
}
