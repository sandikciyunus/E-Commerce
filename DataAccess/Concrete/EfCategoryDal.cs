
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.Entity_Framework;
using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        private readonly ShopContext _context;
        public EfCategoryDal(ShopContext context):base(context)
        {
            _context = context;
        }
        public List<CategoryModel> GetAll2()
        {
            
                return _context.Categories.Select(x => new CategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Products.Count
                }).ToList();
            
        }
    }


}

