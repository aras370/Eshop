using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IOrderService
    {
        Order GetOrderByUserId(int userId);

        void AddOrder(Order order);

        void AddOrderDetail(OrderDetail orderDetail);

        List<OrderDetail> GetUserOrderdetail(int userId);

        OrderDetail GetOrderDetail(int orderId, int productId);

        OrderDetail GetOrderDetail(int orderDetailId);

        void UpdateOrderDetail(OrderDetail orderDetail);

        void RemoveItem(OrderDetail orderDetail);
    }
}
