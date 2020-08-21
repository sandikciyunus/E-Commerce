
using DataAccess.Concrete;
using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        List<UserOrderModel> GetAllByUserName(string userName);
        OrderDetails GetByOrderId(int id);
    }
}
