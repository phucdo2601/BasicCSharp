using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Dtos.Conversions
{
    public static class OrderConversion
    {
        public static Order ToEntity(OrderDto order) => new Order()
        {
            Id = order.Id,
            ClientId = order.ClientId,
            ProductId = order.ProductId,
            OrderedDate = order.OrderedDate,
            PurchaseQuantity = order.PurchaseQuantity
        };

        public static (OrderDto?, IEnumerable<OrderDto>?) FromEntity(Order? order, IEnumerable<Order> orderList)
        {
            // return single
            if (order is not null || orderList is null)
            {
                var singleOrder = new OrderDto(
                    order!.Id,
                    order.ClientId,
                    order.ProductId,
                    order.PurchaseQuantity,
                    order.OrderedDate
                    );

                return (singleOrder, null);
            }

            if (orderList is not null || order is null)
            {
                var _orders = orderList!.Select(o => new OrderDto(
                    o.Id,
                    o.ClientId,
                    o.ProductId,
                    o.PurchaseQuantity,
                    o.OrderedDate
                    ));

                return (null, _orders);
            }

            return (null, null);
        }
    }
}
