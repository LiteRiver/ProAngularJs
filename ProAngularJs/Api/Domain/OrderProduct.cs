﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProAngularJs.Api.Domain {
    public class OrderProduct {

        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }        
    }
}