using Core;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyEshop.Controllers
{
    [Authorize]
    public class OrderController : Controller

    {
        IOrderService _orderService;
        IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }


        public IActionResult AddToCart(int productId)
        {
            OrderDetail orderDetail = new OrderDetail();
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var product = _productService.GetProductById(productId);
            var order = _orderService.GetOrderByUserId(userId);

            if (order != null)
            {
                var orderdetail1 = _orderService.GetOrderDetail(order.OrderId, productId);

                if (orderdetail1 != null)
                {
                    orderdetail1.Count += 1;
                    _orderService.UpdateOrderDetail(orderdetail1);
                }

                else
                {
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.ProductId = productId;
                    orderDetail.Price = product.Price;
                    orderDetail.Count = 1;
                    _orderService.AddOrderDetail(orderDetail);
                }

            }

            else
            {
                Order neworder = new Order()
                {
                    UserId = userId,
                    IsFinal = false,
                    CreationDate = DateTime.Now
                };

                _orderService.AddOrder(neworder);
                orderDetail.OrderId = neworder.OrderId;
                orderDetail.ProductId = productId;
                orderDetail.Price = product.Price;
                orderDetail.Count = 1;
                _orderService.AddOrderDetail(orderDetail);

            }

            return RedirectToAction("ShowCart", "Order");
        }

        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

            var orderdetail = _orderService.GetUserOrderdetail(userId);

            return View(orderdetail);
        }


        public IActionResult RemoveItem(int orderDetailId)
        {
            var orderdetail = _orderService.GetOrderDetail(orderDetailId);

            orderdetail.Count -= 1;

            _orderService.UpdateOrderDetail(orderdetail);

            if (orderdetail.Count == 0)
            {
                _orderService.RemoveItem(orderdetail);
            }


            return RedirectToAction("ShowCart");
        }

        public IActionResult AddItem(int orderDetailId)
        {
            var orderdetail = _orderService.GetOrderDetail(orderDetailId);

            orderdetail.Count += 1;

            _orderService.UpdateOrderDetail(orderdetail);


            return RedirectToAction("ShowCart");
        }


    }

}
