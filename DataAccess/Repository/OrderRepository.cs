using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private IMapper mapper;
        public OrderRepository()
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

        public IEnumerable<OrderObject> GetOrderList()
        {
            try
            {
                var ords = OrderDAO.Instance.GetOrderList();
                var orders = mapper.Map<IEnumerable<Order>, IEnumerable<OrderObject>>(ords);
                return orders;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<OrderObject> GetOrdersByMemberId(int id)
        {
            try
            {
                var ords = OrderDAO.Instance.GetOrdersByMemberId(id);
                var orders = mapper.Map<IEnumerable<Order>, IEnumerable<OrderObject>>(ords);
                return orders;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<OrderObject> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var ords = OrderDAO.Instance.GetOrdersByDate(startDate, endDate);
                var orders = mapper.Map<IEnumerable<Order>, IEnumerable<OrderObject>>(ords);
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderObject GetOrderById(int id)
        {
            try
            {
                var ord = OrderDAO.Instance.GetOrderById(id);
                var order = mapper.Map<Order, OrderObject>(ord);
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateOrder(OrderObject orderObject)
        {
            try
            {
                var order = mapper.Map<OrderObject, Order>(orderObject);
                OrderDAO.Instance.Create(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(OrderObject orderObject)
        {
            try
            {
                var order = mapper.Map<OrderObject, Order>(orderObject);
                OrderDAO.Instance.Update(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrder(OrderObject orderObject)
        {
            try
            {
                var order = mapper.Map<OrderObject, Order>(orderObject);
                OrderDAO.Instance.Delete(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
