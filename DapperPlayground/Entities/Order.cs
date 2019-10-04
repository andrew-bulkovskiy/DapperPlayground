using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPlayground.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime DateOrdered { get; set; }
        public string Comment { get; set; }
    }
}
