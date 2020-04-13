using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IGenericRepository<Product> _ProductRepo;
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork __unitOfWork;
        public OrderService(IBasketRepository basketRepo, IUnitOfWork _unitOfWork)
        {
            __unitOfWork = _unitOfWork;
            _basketRepo = basketRepo;

        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress, decimal dortadim)
        {
            // Basketeki ürünleri repodan çekiyoruz.
            var basket = await _basketRepo.GetBasketAsync(basketId);
            //  basketteki  itemleri product repodan çekiyoruz
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                // Product itemleri buradan  Ordered Item set etiriyoruz.
                var productItem = await _ProductRepo.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            // gönderim tipini repon geliyor.
            var deliveryMethod = await _dmRepo.GetByIdAsync(deliveryMethodId);
            //  cupon codu repodan gleiyor
            // var couponCode  = await _couponRepo.GetCopunCode(couponCode);
            // kampana  tipini repoddan geliyoe
            // var couponCode  = await _couponRepo.GetCopunCode(couponCode);
            // calc subtotal 
            var subTotal = items.Sum(item => item.Price * item.Quantity);


            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subTotal, dortadim);

            // create order  TODO

            // Return Order
            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }



    }
}