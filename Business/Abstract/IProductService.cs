using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllSearch(string aranacakKelime);
        List<Product> GetByCategoryId(int categoryId);
        List<Product> GetByCategoryId2(int categoryId);
        List<Product> GetAll2();
        List<Product> GetAllLastFive();
        Product GetById(int id);
        Product GetById2(int id);
        Product GetByCategory(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
