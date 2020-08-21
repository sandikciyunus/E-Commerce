using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderLineService
    {
        List<OrderLine> GetAll();
        OrderLine GetById(int id);
        void Add(OrderLine orderLine);
        void Update(OrderLine orderLine);
        void Delete(int id);
    }
}
