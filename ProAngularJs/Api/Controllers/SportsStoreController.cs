using ProAngularJs.Api.Data;
using ProAngularJs.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProAngularJs.Api.Controllers {
    public class SportsStoreController : ApiController {
        public IHttpActionResult GetProducts() {
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
    }
}
