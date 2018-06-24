namespace Core.ApplicationServices.Services
{
    using Core.ObjectModels.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IPostService
    {
        Post Get(int id);

        IEnumerable<Post> GetPostByCategory(int categoryId);

        void Create(Post entity);

        void Update(Post entity);

        void Delete(int id);

        IEnumerable<Post> GetAll(params Expression<Func<Post, object>>[] includes);

        IEnumerable<Post> GetAllBanner();

        void UpdateBanner(int id);

        IEnumerable<Post> GetRelatedPost(int id);
        
    }
}