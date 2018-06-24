namespace Core.ApplicationServices.Services
{
    using Core.ObjectModels.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ICategoryService
    {
        IEnumerable<Category> GetAll(params Expression<Func<Category, object>>[] includes);

        IEnumerable<Category> GetPublished();

        IEnumerable<Category> GetAllParent();

        Category Get(Func<Category, bool> predicated, params Expression<Func<Category, object>>[] includes);

        void Create(Category entity);

        void Update(Category entity);

        void Delete(int id);

        void UpdatePublish(int id);
        
    }
}