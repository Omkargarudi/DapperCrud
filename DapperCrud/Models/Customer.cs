using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperCrud.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public decimal Balance { get; set; }
    }
}