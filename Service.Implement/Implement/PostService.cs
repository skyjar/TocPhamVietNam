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

    public class PostService : _BaseService<Post>, IPostService
    {
        private readonly IRepository<Label> _labelRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly ILabelService _labelService;

        public PostService(IUnitOfWork unitOfWork, ILabelService labelService) : base(unitOfWork)
        {
            this._labelRepository = unitOfWork.GetRepository<Label>();
            this._categoryRepository = unitOfWork.GetRepository<Category>();
            this._labelService = labelService;
        }

        public IEnumerable<Post> GetAll(params Expression<Func<Post, object>>[] includes)
        {
            return iRepository.GetAll(includes).OrderByDescending(_ => _.CreatedOn);
        }



        public override void Create(Post entity)
        {
            #region CreateLabels
            _labelService.AddRange(entity.Labels);
            #endregion

            #region GetLabels + GetCategories + Create entity
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                List<Label> labels = new List<Label>();
                foreach (var item in entity.Labels)
                {
                    labels.Add(_labelRepository.Get(_ => _.Name == item.Name));
                }
                entity.Labels = labels;

                List<Category> categories = new List<Category>();
                foreach (var item in entity.Categories)
                {
                    categories.Add(_categoryRepository.Get(_ => _.Id == item.Id));
                }
                entity.Categories = categories;

                base.Create(entity);
                scope.Complete();
            }
            #endregion
        }

        public override void Update(Post entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                //Add new labels
                _labelService.AddRange(entity.Labels);

                Post realEntity = iRepository.Get(_ => _.Id == entity.Id, _ => _.Labels, _ => _.Categories);

                //Get labels
                if (entity.Labels != null)
                {
                    List<Label> labels = new List<Label>();
                    entity.Labels.ToList()
                        .ForEach(_ => labels.Add(_labelRepository.Get(__ => __.Name == _.Name)));
                    realEntity.Labels = labels;
                }
                else realEntity.Labels = null;

                //Get categories
                if (entity.Categories != null)
                {
                    List<Category> categories = new List<Category>();
                    entity.Categories.ToList()
                        .ForEach(_ => categories.Add(_categoryRepository.Get(__ => __.Id == _.Id)));
                    realEntity.Categories = categories;
                }
                else realEntity.Categories = null;

                //Update others info
                realEntity.BodyHtml = entity.BodyHtml;
                realEntity.Body = entity.Body;
                realEntity.Title = entity.Title;
                realEntity.Author = entity.Author;
                realEntity.CoverPhoto = entity.CoverPhoto;

                base.Update(realEntity);

                scope.Complete();
            }
        }

        public void Delete(int id)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                base.Delete(iRepository.Get(_ => _.Id == id));
                scope.Complete();
            }
        }

        

        public Post Get(int id)
        {
            return iRepository.Get(_ => _.Id == id, _ => _.Labels, _ => _.Categories, _ => _.Comments);
        }

        public IEnumerable<Post> GetAllBanner()
        {
            return iRepository.Search(_ => _.IsBanner, _ => _.Categories);
        }

        public void UpdateBanner(int id)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                Post banner = iRepository.Get(_ => _.Id == id);
                banner.IsBanner = !banner.IsBanner;
                base.Update(banner);
                scope.Complete();
            }
        }

        public IEnumerable<Post> GetPostByCategory(int categoryId)
        {
            return iRepository.Search(_ => _.Categories.FirstOrDefault(__ => __.Id == categoryId) != null, 
                _ => _.Comments, _ => _.Categories);
        }

        public IEnumerable<Post> GetRelatedPost(int id)
        {
            Post model = iRepository.Get(_ => _.Id == id, _ => _.Labels);
            ICollection<Post> related = new List<Post>();

            return related;
        }
    }
}