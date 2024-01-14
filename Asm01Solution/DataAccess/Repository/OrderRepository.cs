using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);
        public void DeleteOrder(Order order) => OrderDAO.Instance.DeleteOrder(order);
        public IEnumerable<Order> GetAllOrders() => OrderDAO.Instance.GetAllOrders();
        public Order GetOrderById(int id) => OrderDAO.Instance.GetOrderById(id);
        public IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate) => OrderDAO.Instance.GetOrderByDate(startDate, endDate);

        public IEnumerable<Order> GetOrdersByUser(string email) => OrderDAO.Instance.GetOrderByEmail(email);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
    }
}
