using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ComplexTypes
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState OrderState { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Parish { get; set; }
        public string PostCode { get; set; }
        public List<OrderLineModel> OrderLineModels { get; set; }
    }
}
