using DataAccess.Concrete.Entity_Framework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfOrderLineDal:EfEntityRepositoryBase<OrderLine>,IOrderLineDal
    {
        private readonly ShopContext _context;
        public EfOrderLineDal(ShopContext context) : base(context)
        {
            _context = context;
        }
    }
}
