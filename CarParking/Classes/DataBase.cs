using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace курсовой
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-62KUD44;Initial Catalog=PARKING;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public DataTable Select(string tableFrom, string where, string where2)
        {
            openConnection();
            string  query = $"select * from {tableFrom} where {where}='{where2}'";
            DataTable inv = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, this.GetConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                inv.Load(dr);
                dr.Close();
            }
            closeConnection();
            return inv;
        }

        public DataTable SelectAll(string table)
        {
            openConnection();
            string query = $"select * from {table}";
            DataTable inv = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, this.GetConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                inv.Load(dr);
                dr.Close();
            }
            closeConnection();
            return inv;
        }

        
        public void Delete(string table, string where, string where2)
        {
            openConnection();
            string query = $"delete from {table} where {where}='{where2}'";
            using (SqlCommand cmd = new SqlCommand(query, this.GetConnection()))
            {
                cmd.ExecuteNonQuery();
            }
            closeConnection();
        }

        public void InsertIntoHistory(string tableTo, string operation, DateTime date)
        {
            openConnection();

            string query = $"insert into {tableTo} (operation, date) values(@operation, @date)";

            using (SqlCommand command = new SqlCommand(query, this.GetConnection()))
            {
                command.Parameters.Add("@operation", SqlDbType.VarChar).Value = operation;
                command.Parameters.Add("@date", SqlDbType.VarChar).Value = date;

                command.ExecuteNonQuery();
            }
            closeConnection();
        }

        public void UpdateUserParametr(string param1, string param2, string param3, string param4)
        {
            openConnection();
            string query = $"update users set {param1}=@param2 where {param3}=@param4";
            using (SqlCommand cmd = new SqlCommand(query, this.GetConnection()))
            {
                cmd.Parameters.Add("@param2", SqlDbType.VarChar).Value = param2;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar).Value = param4;


                cmd.ExecuteNonQuery();
                
             
            }
            closeConnection();
        }

    }
}
