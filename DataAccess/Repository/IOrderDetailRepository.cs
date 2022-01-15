using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailObject> GetOrderDetailList();
        OrderDetailObject GetOrderDetail(int orderId, int productId);
        void CreateOrderDetail(OrderDetailObject orderDetailObject);
    }
}
