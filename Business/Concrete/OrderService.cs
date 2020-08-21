using Business.Abstract;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderService : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public void Add(Order order)
        {
            _orderDal.Add(order);
        }

        public void Delete(int id)
        {
            var order = _orderDal.Get(p => p.Id == id);
            _orderDal.Delete(order);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetList();
        }

        public List<UserOrderModel> GetAllByUserName(string userName)
        {
            return _orderDal.GetAllByUserName(userName);
        }

        public Order GetById(int id)
        {
            return _orderDal.Get(p => p.Id == id);
        }

        public OrderDetails GetByOrderId(int id)
        {
            return _orderDal.GetByOrderId(id);
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
