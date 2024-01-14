using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetailByProductId(int productId) => OrderDetailDAO.Instance.GetOrderDetailByProductId(productId);
        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId) => OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderId);
        public void DeleteOrderDetailByOrderId(IEnumerable<OrderDetail> orderDetails) => OrderDetailDAO.Instance.DeleteOrderDetailByOrderId(orderDetails);

    }
}
