using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instancelock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailByProductId(int productId)
        {
            List<OrderDetail> orderDetailList;
            try
            {
                using (var ctx = new PRN221_Assignment01Context())
                {
                    int pId = ctx.Products.Where(p => p.ProductId == productId).FirstOrDefault().ProductId;
                    orderDetailList = ctx.OrderDetails.Where(o => o.ProductId == pId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetailList;
        }
        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            List<OrderDetail> orderDetailList;
            try
            {
                using (var ctx = new PRN221_Assignment01Context())
                {
                    int oId = ctx.Orders.Where(o => o.OrderId == orderId).FirstOrDefault().OrderId;
                    orderDetailList = ctx.OrderDetails.Where(o => o.OrderId == oId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetailList;
        }
        public void DeleteOrderDetailByOrderId(IEnumerable<OrderDetail> orderDetails)
        {
            try
            {   
                foreach(var orderDetail in orderDetails){
                    using (var ctx = new PRN221_Assignment01Context())
                    {
                        ctx.OrderDetails.Remove(orderDetail);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
