using ProAngularJs.Api.Data;
using ProAngularJs.Api.Domain;
using ProAngularJs.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProAngularJs.Api.Controllers {
    [RoutePrefix("SportsStore")]
    public class SportsStoreController : ApiController {

        [Route("Products")]
        [HttpGet]
        public IHttpActionResult Products() {
            using (var db = new SportsStoreDbContext()) {
                return Ok(db
                    .Products
                    .Select(p => new {
                        id = p.Id,
                        name = p.Name,
                        description = p.Description,
                        category = p.Category,
                        price = p.Price
                    }).ToList());
            }
        }

        [Route("PlaceOrder")]
        [HttpPost]
        public IHttpActionResult PlaceOrder(PlaceOrderRequest request) {
            using (var db = new SportsStoreDbContext()) {
                var order = new Order {
                    Name = request.Name,
                    Street = request.Street,
                    City = request.City,
                    State = request.State,
                    Zip = request.Zip,
                    Country = request.Country,
                    GiftWrap = request.GiftWrap
                };

                foreach (var item in request.Products) {
                    var product = db.Products.Find(item.Id);
                    if (product == null) {
                        return BadRequest(string.Format("订单中商品[{0}]不存在", item.Id));
                    }

                    order.OrderProducts.Add(new OrderProduct { 
                        ProductId = product.Id,
                        Count = item.Count
                    });
                }

                db.Orders.Add(order);
                db.SaveChanges();

                return Ok(new { id = order.Id });
            }
        }

        [Route("Orders")]
        [HttpGet]
        public IHttpActionResult Orders() {
            using (var db = new SportsStoreDbContext()) {
                var orders = db.Orders
                    .Include("OrderProducts.Product")
                    .Select(o => new { 
                        id = o.Id, 
                        name = o.Name,  
                        street = o.Street,
                        city = o.City, 
                        state = o.State,
                        zip = o.Zip,
                        country = o.Country,
                        giftWrap = o.GiftWrap,
                        products = o.OrderProducts
                        .Select(p => new{ 
                            id = p.Product.Id, 
                            name = p.Product.Name, 
                            price = p.Product.Price,
                            count = p.Count
                        }).ToList()
                    }).ToList();


                return Ok(orders);
            }
        }
    }
}
