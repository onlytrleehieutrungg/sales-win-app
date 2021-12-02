using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseDal
    {
        public StockDataProvider dataProvider { get; set; } = null;

        public SqlConnection connection = null;

        public BaseDal()
        {
            var connectionString = GetConnectionString();
            dataProvider = new StockDataProvider(connectionString);
        }

        public string GetConnectionString()
        {
            string connectionString = "Server=DESKTOP-0S3CI1N\\SQLEXPRESS;User ID=sa;Password=123123;database=FStore";


            return connectionString;
        }
        public void CloseConnection() => dataProvider.CloseConnection(connection);
    }
}
