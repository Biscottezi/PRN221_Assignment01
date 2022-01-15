using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO _instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new OrderDAO();
                    }
                    return _instance;
                }
            }
        }

        public IEnumerable<Order> GetOrderList()
        {
            List<Order> orders;
            try
            {
                var db = new FStoreDBAssignmentContext();
                orders = db.Orders.Include(o => o.OrderDetails)
                                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public IEnumerable<Order> GetOrdersByMemberId(int id)
        {
            List<Order> orders;
            try
            {
                var db = new FStoreDBAssignmentContext();
                orders = db.Orders.Where(o => o.MemberId == id)
                                    .Include(o => o.OrderDetails)
                                    .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            List<Order> orders;
            try
            {
                var db = new FStoreDBAssignmentContext();
                orders = db.Orders.Where(o => o.OrderDate > startDate && o.OrderDate < endDate)
                                    .Include(o => o.OrderDetails)
                                    .OrderByDescending(o => o.OrderDate)
                                    .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            try
            {
                var db = new FStoreDBAssignmentContext();
                order = db.Orders.Include(o => o.OrderDetails)
                                .SingleOrDefault(o => o.OrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void Create(Order order)
        {
            try
            {
                var ord = GetOrderById(order.OrderId);
                if (ord == null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This order already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                var ord = GetOrderById(order.OrderId);
                if (ord != null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Entry<Order>(order).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This order doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Order order)
        {
            try
            {
                var ord = GetOrderById(order.OrderId);
                if (ord != null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Orders.Remove(ord);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This order doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
