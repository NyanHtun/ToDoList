using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ToDoList
{
    public class DataBase
    {
        DBInfo db = new DBInfo();
        string conString;
        public DataBase()
        {
            conString = db.getConString();
        }

        public DataTable getDataTable(String command,Boolean isProc,params SqlParameter[] param )
        {
            DataTable tbl = new DataTable();
            SqlConnection con= new SqlConnection(conString);
            SqlCommand cmd= new SqlCommand(command,con);
            
            if(isProc)
            {
                cmd.CommandType=CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType=CommandType.Text;
            }

            foreach (SqlParameter p in param)
            {
                cmd.Parameters.Add(p);
            }
            
           

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            adp.Fill(tbl);
            con.Close();

            return tbl;
         
        }

        public void executeCommand(String command, Boolean isProc, params SqlParameter[] param)
        {
            DataTable tbl = new DataTable();
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(command, con);

            if (isProc)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }

            foreach (SqlParameter p in param)
            {
                cmd.Parameters.Add(p);
            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}