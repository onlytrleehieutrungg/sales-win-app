using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    public class OrderDBContext:BaseDal
    {
        private static OrderDBContext instance = null;
        private static readonly object instanceLock = new object();
        private OrderDBContext()
        {

        }
        public static OrderDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDBContext();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrderList()
        {
            IDataReader dataReader = null;
            String SQLSelect = "Select OrderId, MemberId, OrderDate, RequiredDate, ShippedDate,Freight From Oder";
            var orders = new List<Order>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return orders;
        }

        public Order GetOrderByID(int orderId)
        {
            Order order = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select MemberId, OrderDate, RequiredDate, ShippedDate,Freight " +
                            " from Oder where OrderId = @OrderId";
            try
            {
                var param = dataProvider.CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new Order
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return order;
        }

        public void AddNew(Order order)
        {
            try
            {
                Order pro = GetOrderByID(order.OrderId);
                if (pro == null)
                {
                    string SQLInsert = "Insert Oder values(@OrderId,@MemberId,@OrderDate,@RequiredDate,@ShippedDate,@Freight)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderId", 4, order.OrderId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, order.MemberId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@OrderDate", 8, order.OrderDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@RequiredDate", 8, order.RequiredDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@ShippedDate", 8, order.ShippedDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@Freight", 8, order.Freight, DbType.Decimal));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Order order)
        {
            try
            {
                Order pro = GetOrderByID(order.OrderId);
                if (pro != null)
                {
                    string SQLInsert = "Update Oder set MemberId = @MemberId,OrderDate = @OrderDate,"
                        + " RequiredDate = @RequiredDate,ShippedDate = @ShippedDate,Freight = @Freight Where OrderId = @OrderId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderId", 4, order.OrderId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, order.MemberId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@OrderDate", 8, order.OrderDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@RequiredDate", 8, order.RequiredDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@ShippedDate", 8, order.ShippedDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@Freight", 8, order.Freight, DbType.Decimal));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());

                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        public void Remove(int orderId)
        {
            try
            {
                Order order = GetOrderByID(orderId);
                if (order != null)
                {
                    String SQLDelete = "Delete Oder Where OrderId = @OrderId";
                    var param = dataProvider.CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);

                }
                else
                {
                    throw new Exception("The Order is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
         
    }
}
