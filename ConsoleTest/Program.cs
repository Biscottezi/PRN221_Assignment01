using System;
using DataAccess;
using DataAccess.Repository;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = OrderDAO.Instance.GetOrderById(4665);
            var od = OrderDetailDAO.Instance.GetOrderDetailsByOrderId(4665);
            var enu = od.GetEnumerator();
            enu.MoveNext();
            Console.WriteLine($"OrderID: {order.OrderId}, OrderDetailCount: {enu.Current.Product.ProductName}");
        }
    }
}
