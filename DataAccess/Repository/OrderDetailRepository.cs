using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using AutoMapper;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private IMapper mapper;
        public OrderDetailRepository()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Member, MemberObject>().ReverseMap();
                mc.CreateMap<Product, ProductObject>().ReverseMap();
                mc.CreateMap<Order, OrderObject>().ReverseMap();
                mc.CreateMap<OrderDetail, OrderDetailObject>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public IEnumerable<OrderDetailObject> GetOrderDetailList()
        {
            try
            {
                var ods = OrderDetailDAO.Instance.GetOrderDetailList();
                var orderDetails = mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailObject>>(ods);
                return orderDetails;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderDetailObject GetOrderDetail(int orderId, int productId)
        {
            try
            {
                var od = OrderDetailDAO.Instance.GetOrderDetail(orderId, productId);
                var orderDetail = mapper.Map<OrderDetail, OrderDetailObject>(od);
                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateOrderDetail(OrderDetailObject orderDetailObject)
        {
            try
            {
                var orderDetail = mapper.Map<OrderDetailObject, OrderDetail>(orderDetailObject);
                OrderDetailDAO.Instance.Create(orderDetail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
