using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore
{
    public class EmployeeDAO
    {
        string strConnection;
        public EmployeeDAO()
        {
            getConnectionString();
        }

        public string getConnectionString()
        {
            strConnection = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            return strConnection;
        }

        public EmployeeDTO CheckLogin(string userName, string password)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Select EmpID, EmpPassword, EmpRole From Employee Where EmpID = @ID And EmpPassword = @Password";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", userName);
            cmd.Parameters.AddWithValue("@Password", password);
            if (cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    EmployeeDTO emp = new EmployeeDTO
                    {
                        EmpID = reader[0].ToString(),
                        EmpPassword = reader[1].ToString(),
                        EmpRole = bool.Parse(reader[2].ToString())
                    };
                    return emp;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                reader.Close();
            }
            return null;
        }

        public bool ChagePassword(string userName, string password)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Update Employee Set EmpPassword = @Password Where EmpID = @ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@ID", userName);
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
    }
}
