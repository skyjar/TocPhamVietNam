namespace Service.Implement.Implement
{
    using Core.ObjectModels.Entities;
    using Core.ObjectServices.Repositories;
    using Core.ApplicationServices.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    using System.Linq.Expressions;
    using System;

    public class CategoryService : _BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override void Create(Category entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                if (entity.HasParent)
                {
                    Category parent = base.iRepository.Get(_ => _.Id == entity.ParentId);
                    entity.CategoryPath = $"{parent.CategoryPath} > {entity.Name}";
                }
                else
                {
                    entity.CategoryPath = $"{entity.Name}";
                }
                base.Create(entity);
                scope.Complete();
            }
        }

        public IEnumerable<Category> GetAllParent()
        {
            return iRepository.Search(_ => !_.HasParent, _ => _.Childrens);
        }

        public IEnumerable<Category> GetAll(params Expression<Func<Category, object>>[] includes)
        {
            return iRepository.GetAll(includes);
        }

        public override void Update(Category entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                Category currentEntity = iRepository.Get(_ => _.Id == entity.Id, _ => _.Childrens);
                currentEntity.Name = entity.Name;
                if (currentEntity.HasParent)
                {
                    Category parent = base.iRepository.Get(_ => _.Id == currentEntity.ParentId);
                    currentEntity.CategoryPath = $"{parent.CategoryPath} > {currentEntity.Name}";
                }
                else
                {
                    currentEntity.CategoryPath = $"{currentEntity.Name}";
                }
                if (currentEntity.HaveChildrens)
                {
                    ICollection<Category> childs = currentEntity.Childrens;
                    foreach (var item in childs)
                    {
                        item.CategoryPath = $"{currentEntity.CategoryPath} > {item.Name}";
                        base.Update(item);
                    }
                }
                base.Update(currentEntity);
                scope.Complete();
            }
        }

        public void Delete(int id)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                Category currentEntity = iRepository.Get(_ => _.Id == id, _ => _.Childrens);
                if (currentEntity.HaveChildrens)
                {
                    ICollection<Category> childs = currentEntity.Childrens;
                    foreach (var item in childs.ToList())
                    {
                        base.Delete(item);//yield
                    }
                }
                base.Delete(currentEntity);
                scope.Complete();
            }
        }

        public void UpdatePublish(int id)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                Category currentEntity = iRepository.Get(_ => _.Id == id);
                currentEntity.IsPublished = !currentEntity.IsPublished;
                
                base.Update(currentEntity);
                scope.Complete();
            }
        }

        

        public IEnumerable<Category> GetPublished()
        {
            return iRepository.Search(_ => _.IsPublished);
        }

        public Category Get(Func<Category, bool> predicated, params Expression<Func<Category, object>>[] includes)
        {
            return iRepository.Get(predicated, includes);
        }
    }
}