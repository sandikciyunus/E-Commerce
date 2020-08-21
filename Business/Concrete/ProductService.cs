using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductService:IProductService
    {
        private IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            var product = _productDal.Get(p => p.Id == id);
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetAll2()
        {
            return _productDal.GetAll2();
        }

        public List<Product> GetAllLastFive()
        {
            return _productDal.GetAllLastFive();
        }

        public List<Product> GetAllSearch(string aranacakKelime)
        {
            return _productDal.GetAllSearch(aranacakKelime);
        }

        public Product GetByCategory(int id)
        {
            return _productDal.Get(p => p.CategoryId == id);
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _productDal.GetByCategoryId(categoryId);
        }

        public List<Product> GetByCategoryId2(int categoryId)
        {
            return _productDal.GetByCategoryId2(categoryId);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetById2(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        
    }
}
