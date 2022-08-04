using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBL(Category entity)
        //{
        //    if (entity.CategoryName == "" || entity.CategoryName.Length <= 3 ||
        //        entity.CategoryDescription == "" || entity.CategoryName.Length >= 51)
        //    {
        //        //error message
        //    }
        //    else
        //    {
        //        repo.Insert(entity);
        //    }

        //    //repo.Insert(entity);
        //}

        ICategoryDal _categoryDal;



        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }



        //public void CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryStatus == false ||
        //        p.CategoryName.Length <= 2)
        //    {
        //        //error message
        //    }
        //    else
        //    {
        //        _categoryDal.Insert(p);
        //    }
        //}
    }
}
