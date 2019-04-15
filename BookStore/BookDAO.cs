using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BookStore
{
    public class BookDAO
    {
        string strConnection;

        public BookDAO()
        {
            strConnection = getConnectionString();
        }

        public string getConnectionString()
        {
            string strConnection = "server=.;database=BookStore;uid=sa;pwd=sa123456";
            return strConnection;
        }

        public DataTable getBooks()
        {
            string SQL = "Select * from Books";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtBook = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtBook);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dtBook;
        }

        public bool addNewBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert into Books values(@Name,@Price) ";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool updateBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL =
                "Update Books set BookName=@Name, BookPrice=@Price Where BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool deleteBook(int BookID)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Delete Books where BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", BookID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
    }
}
