using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ComplexTypes
{
    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
