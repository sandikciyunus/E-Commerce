using Business.Abstract;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryService:ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int id)
        {
            var category = _categoryDal.Get(p => p.Id == id);
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public List<CategoryModel> GetAll2()
        {
            return _categoryDal.GetAll2();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(p => p.Id == id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
