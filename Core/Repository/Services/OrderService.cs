
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class OrderService : IOrderService
    {

        MyEshopContext _context;

        public OrderService(MyEshopContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
           _context.Add(orderDetail);
            _context.SaveChanges();
        }

        public Order GetOrderByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId && o.IsFinal == false).SingleOrDefault();
        }

        public OrderDetail GetOrderDetail(int orderId, int productId)
        {
            return _context.OrderDetails.Where(o => o.OrderId == orderId && o.ProductId == productId).SingleOrDefault();
        }

        public OrderDetail GetOrderDetail(int orderDetailId)
        {

            return _context.OrderDetails.Find(orderDetailId);

        }

        public List<OrderDetail> GetUserOrderdetail(int orderId)
        {
            return _context.OrderDetails.Include(o => o.Product).Include(o => o.Order).ThenInclude(o => o.User).Where(o => o.OrderId == orderId).ToList();
        }

        public void RemoveItem(OrderDetail orderDetail)
        {
            _context.Remove(orderDetail);
            _context.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _context.Update(orderDetail);
            _context.SaveChanges();
        }
    }
}
