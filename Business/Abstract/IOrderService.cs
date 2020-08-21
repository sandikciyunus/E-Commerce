using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        List<UserOrderModel> GetAllByUserName(string userName);
        Order GetById(int id);
        OrderDetails GetByOrderId(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
