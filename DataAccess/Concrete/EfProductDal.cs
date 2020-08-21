using DataAccess.Concrete.Entity_Framework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        private readonly ShopContext _context;
        public EfProductDal(ShopContext context) : base(context)
        {
            _context = context;
        }
        public List<Product> GetAll2()
        {
            
                return _context.Products.Include(p => p.Category).OrderByDescending(p=>p.Id).ToList();
            
        }

        public List<Product> GetAllLastFive()
        {
          
                return _context.Products.Include(p => p.Category).Take(5).OrderByDescending(p=>p.Id).ToList();
            
        }

        public List<Product> GetAllSearch(string aranacakKelime)
        {
         
                if (!string.IsNullOrWhiteSpace(aranacakKelime))
                {
                   return _context.Products.Include(p => p.Category).Where(p => p.Name.ToLower().Contains(aranacakKelime.ToLower())).ToList();
                }
                return null;
            
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
           
                return _context.Products.Include(p => p.Category).Take(5).OrderByDescending(p=>p.Id).Where(p => p.CategoryId==categoryId).ToList();
            
        }

        public List<Product> GetByCategoryId2(int categoryId)
        {
           
                return _context.Products.Include(p=>p.Category).Where(p => p.CategoryId == categoryId).ToList();
            
        }


        public Product GetById(int id)
        {
            
                return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            
        }
    }
}
