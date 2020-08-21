using DataAccess.Concrete.Entity_Framework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCommentDal:EfEntityRepositoryBase<Comment>,ICommentDal
    {
        private readonly ShopContext _context;
        public EfCommentDal(ShopContext context) : base(context)
        {
            _context = context;
        }
    }
}
