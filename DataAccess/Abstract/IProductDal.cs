using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<Product> GetAllLastFive();
        List<Product> GetByCategoryId(int categoryId);
        List<Product> GetByCategoryId2(int categoryId);
        List<Product> GetAll2();
        List<Product> GetAllSearch(string aranacakKelime);
        Product GetById(int id);
    }
}
