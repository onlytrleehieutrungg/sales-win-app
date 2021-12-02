using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(int orderId) => OrderDBContext.Instance.Remove(orderId);


        public IEnumerable<Order> GetOrder() => OrderDBContext.Instance.GetOrderList();


        public Order GetOrderByID(int orderId) => OrderDBContext.Instance.GetOrderByID(orderId);


        public void InsertOrder(Order order) => OrderDBContext.Instance.AddNew(order);


        public void UpdateOrder(Order order) => OrderDBContext.Instance.Update(order);

    }
}
