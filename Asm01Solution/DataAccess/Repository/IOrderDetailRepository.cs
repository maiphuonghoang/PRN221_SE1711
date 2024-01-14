using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetailByProductId(int productId);

        IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId);
        void DeleteOrderDetailByOrderId(IEnumerable<OrderDetail> orderDetails);
    }
}
