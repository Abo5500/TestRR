﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PriceItem
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Number { get; set; }
        public string SearchVendor { get; set; }
        public string SearchNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
