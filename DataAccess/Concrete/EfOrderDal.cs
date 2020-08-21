using DataAccess.Concrete.Entity_Framework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.ComplexTypes;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete
{
    public class EfOrderDal : EfEntityRepositoryBase<Order>, IOrderDal
    {
        private readonly ShopContext _context;
        public EfOrderDal(ShopContext context) : base(context)
        {
            _context = context;
        }
        public List<UserOrderModel> GetAllByUserName(string userName)
        {
            
                return _context.Orders.Where(p => p.UserName == userName).
                    Select(p => new UserOrderModel()
                    {
                        Id = p.Id,
                        OrderNumber = p.OrderNumber,
                        OrderDate = p.OrderDate,
                        OrderState = p.OrderState,
                        Total = p.Total,
                    }).OrderByDescending(p => p.OrderDate).ToList();
                
            
        }

        public OrderDetails GetByOrderId(int id)
        {
           
                return _context.Orders.Where(p => p.Id == id).Select(p => new OrderDetails()
                {
                    OrderId = p.Id,
                    OrderNumber = p.OrderNumber,
                    Total = p.Total,
                    OrderDate = p.OrderDate,
                    OrderState = p.OrderState,
                    Address = p.Addres,
                    City = p.City,
                    District = p.District,
                    Parish = p.Parish,
                    PostCode = p.PostCode,
                    OrderLineModels = p.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();
            
        }
    }
}
