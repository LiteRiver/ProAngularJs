using System;
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

        private ICollection<OrderProduct> m_orderProducts;
        public virtual ICollection<OrderProduct> OrderProducts {
            get { return m_orderProducts ?? (m_orderProducts = new List<OrderProduct>()); }
            set { m_orderProducts = value; }
        }
    }
}