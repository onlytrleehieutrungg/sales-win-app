using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrder();
        Order GetOrderByID(int orderId);
        void InsertOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);
        
    }
}
