using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace ToDoList
{
    public class DBInfo
    {
        string conString;
        string user;
        string password;
        string catalog;
        string dataSource;
        private byte[] Key = { 13, 27, 179, 121, 214, 216, 211, 21, 112, 187, 17, 62, 137, 110, 212, 209,
                                     200, 100, 188, 90, 43, 171, 160, 140, 2, 216, 117, 190, 132, 226, 5, 222 };
        private byte[] Vector = { 211, 146, 191, 110, 213, 40, 141, 8, 77, 99, 222, 254, 231, 23, 22, 156 };
        public DBInfo()
        {
            dataSource = "localhost";
            user = "sa";
            password = "as";
            catalog = "DBToDo";

            conString = "Data Source=" + dataSource + ";" + "Initial Catalog=" + catalog + ";" +
                "User id=" + user + ";" + "Password=" + password + ";";
        }
        public string getUser() 
        {
            return user;
        }
        public string getPassword()
        {
            return password;
        }
        public string getCatalog()
        {
            return catalog;
        }
        public string getDataSource()
        {
            return dataSource;
        }
        public string getConString()
        {
            return conString;
        }
    }

    
}