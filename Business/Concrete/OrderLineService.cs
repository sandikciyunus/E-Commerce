using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderLineService : IOrderLineService
    {
        private IOrderLineDal _orderLineDal;
        public OrderLineService(IOrderLineDal orderLineDal)
        {
            _orderLineDal = orderLineDal;
        }
        public void Add(OrderLine orderLine)
        {
            _orderLineDal.Add(orderLine);
        }

        public void Delete(int id)
        {
            var orderLine = _orderLineDal.Get(p => p.Id == id);
            _orderLineDal.Delete(orderLine);
        }

        public List<OrderLine> GetAll()
        {
            return _orderLineDal.GetList();
        }

        public OrderLine GetById(int id)
        {
            return _orderLineDal.Get(p => p.Id == id);
        }

        public void Update(OrderLine orderLine)
        {
            _orderLineDal.Update(orderLine);
        }
    }
}
