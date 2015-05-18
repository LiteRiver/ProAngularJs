﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProAngularJs.Api.Domain {
    public class Order {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public bool GiftWrap { get; set; }

        private ICollection<OrderProduct> m_products;
        public virtual ICollection<OrderProduct> Products {
            get { return m_products ?? (m_products = new List<OrderProduct>()); }
            set { m_products = value; }
        }
    }
}