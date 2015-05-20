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
    public class ProductsController : ApiController {
        public IHttpActionResult GetAllProducts() {
            using (var db = new SportsStoreDbContext()) {
                return Ok(db.Products
                    .Select(p => new {
                        id = p.Id,
                        name = p.Name,
                        description = p.Description,
                        category = p.Category,
                        price = p.Price,
                    }).ToList());
            }
        }

        public IHttpActionResult DeleteProduct(int id) {
            using (var db = new SportsStoreDbContext()) {
                var p = db.Products.Find(id);

                if (p == null) {
                    return NotFound();
                }
                db.Products.Remove(p);
                db.SaveChanges();

            }

            return Ok();
        }

        public IHttpActionResult PostProduct(ProductModel p) {
            using (var db = new SportsStoreDbContext()) {
                var product = db.Products.Find(p.Id);
                if (product == null) {
                    product = new Product {
                        Name = p.Name,
                        Description = p.Description,
                        Category = p.Category,
                        Price = p.Price
                    };

                    db.Products.Add(product);
                } else {
                    product.Name = p.Name;
                    product.Description = p.Description;
                    product.Category = p.Category;
                    product.Price = p.Price;
                }

                db.SaveChanges();

                return Ok(new {
                    id = product.Id,
                    name = product.Name,
                    description = product.Description,
                    price = product.Price
                });
            }
        }
    }
}
