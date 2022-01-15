using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO _instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new OrderDetailDAO();
                    }
                    return _instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var db = new FStoreDBAssignmentContext();
                orderDetails = db.OrderDetails.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int id)
        {
            List<OrderDetail> orderDetails;
            try
            {
                var db = new FStoreDBAssignmentContext();
                orderDetails = db.OrderDetails.Where(od => od.OrderId == id)
                                            .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public OrderDetail GetOrderDetail(int orderId, int productId)
        {
            OrderDetail orderDetail = null;
            try
            {
                var db = new FStoreDBAssignmentContext();
                orderDetail = db.OrderDetails.SingleOrDefault(
                    od => od.OrderId == orderId && od.ProductId == productId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public void Create(OrderDetail orderDetail)
        {
            try
            {
                var od = GetOrderDetail(orderDetail.OrderId, orderDetail.ProductId);
                if (od != null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This detail doesn't exist.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
