using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProAngularJs.Api.Models {
    public class PlaceOrderRequest {

        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public bool GiftWrap { get; set; }

        private IEnumerable<Product> m_products;

        public IEnumerable<Product> Products {
            get { return m_products ?? (m_products = new List<Product>());}
            set { m_products = value; }
        }

        public class Product {
            public int Id { get; set; }

            public int Count { get; set; }
        }
    }
}