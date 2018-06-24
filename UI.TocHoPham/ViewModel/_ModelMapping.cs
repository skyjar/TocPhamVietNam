namespace UI.TocHoPham.ViewModel
{
    using Core.ObjectModels.Entities;
    using PagedList;
    using System.Collections.Generic;
    using System.Linq;

    public class _ModelMapping
    {
        #region Menu
        public ICollection<MenuViewModel> ConvertToViewModel(IEnumerable<Category> models)
        {
            ICollection<MenuViewModel> menus = new List<MenuViewModel>();
            foreach (var item in models.ToList())
            {
                menus.Add(ConvertToViewModel(item));
            }
            return menus;
        }

        public MenuViewModel ConvertToViewModel(Category model)
        {
            ICollection<MenuViewModel> children = new List<MenuViewModel>();
            foreach (var item in model.Childrens.ToList())
            {
                children.Add(new MenuViewModel {
                    Id = item.Id,
                    Name = item.Name,
                    Children = null
                });
            }

            return new MenuViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Children = children
            };
        }

        #endregion

        #region Category Of Post

        public CategoryViewModel ConvertToCategoryViewModel(Category model)
        {
            return new CategoryViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public ICollection<CategoryViewModel> ConvertToCategoryViewModel(IEnumerable<Category> models)
        {
            ICollection<CategoryViewModel> list = new List<CategoryViewModel>();
            foreach (var item in models)
            {
                list.Add(ConvertToCategoryViewModel(item));
            }
            return list;
        }

        #endregion

        #region Label
        public LabelViewModel ConvertToViewModel(Label model)
        {
            return new LabelViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public ICollection<LabelViewModel> ConvertToViewModel(IEnumerable<Label> models)
        {
            ICollection<LabelViewModel> list = new List<LabelViewModel>();
            models.ToList().ForEach(_ => list.Add(ConvertToViewModel(_)));
            return list;
        }
        #endregion

        #region Comment
        public CommentViewModel ConvertToViewModel(Comment model)
        {
            return new CommentViewModel
            {
                Author = model.Author,
                Content = model.Content,
                CreatedOn = model.CreatedOn
            };
        }

        public ICollection<CommentViewModel> ConvertToViewModel(IEnumerable<Comment> models)
        {
            ICollection<CommentViewModel> list = new List<CommentViewModel>();
            models.ToList().ForEach(_ => list.Add(ConvertToViewModel(_)));
            return list;
        }
        #endregion

        #region Post

        public PostDetailViewModel ConvertToPostDetailViewModel(Post model)
        {
            return new PostDetailViewModel {
                Id = model.Id,
                Title = model.Title,
                CreatedOn = model.CreatedOn,
                Author = model.Author,
                Body = model.Body,
                BodyHtml = model.BodyHtml,
                CoverPhoto = model.CoverPhoto,
                Categories = ConvertToCategoryViewModel(model.Categories),
                Comments = ConvertToViewModel(model.Comments),
                Labels = ConvertToViewModel(model.Labels)
            };
        }

        public BannerViewModel ConvertToBannerViewModel(Post model)
        {
            return new BannerViewModel
            {
                Id = model.Id,
                Title = model.Title,
                CoverPhoto = model.CoverPhoto,
                CreatedOn = model.CreatedOn
            };
        }

        public ICollection<BannerViewModel> ConvertToBannerViewModel(IEnumerable<Post> models)
        {
            ICollection<BannerViewModel> list = new List<BannerViewModel>();
            foreach (var item in models)
            {
                list.Add(ConvertToBannerViewModel(item));
            }
            return list;
        }

        public PostViewModel ConvertToViewModel(Post model)
        {
            return new PostViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Body = model.Body,
                CoverPhoto = model.CoverPhoto,
                CreatedOn = model.CreatedOn,
                NumberComment = model.Comments.Count(),
                Categories = ConvertToCategoryViewModel(model.Categories)
            };
        }

        public ICollection<PostViewModel> ConvertToViewModel(IEnumerable<Post> models)
        {
            ICollection<PostViewModel> list = new List<PostViewModel>();
            foreach (var item in models.ToList())
            {
                list.Add(ConvertToViewModel(item));
            }
            return list;
        }

        public IPagedList<PostViewModel> ConvertToPostPagedViewModel(IEnumerable<Post> models)
        {
            //IPagedList<PostViewModel> list = new PagedList<PostViewModel>();
            //foreach (var item in models.ToList())
            //{
            //    list.Add(ConvertToViewModel(item));
            //}
            //return list;
            //return list.ToPagedList();//list bt rồi return .ToPagedList() k đc hả
            return null;
        }

        #endregion

        #region Category Of Home

        public CategoryHomeViewModel ConvertToCHViewModel(Category model)
        {
            return new CategoryHomeViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Posts = ConvertToViewModel(model.Posts)
            };
        }

        public ICollection<CategoryHomeViewModel> ConvertToCHViewModel(IEnumerable<Category> models)
        {
            ICollection<CategoryHomeViewModel> list = new List<CategoryHomeViewModel>();
            foreach (var item in models)
            {
                list.Add(ConvertToCHViewModel(item));
            }
            return list;
        }

        public CategoryPagedViewModel ConvertToCatePagedVM(Category model)
        {
            return new CategoryPagedViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Posts = ConvertToPostPagedViewModel(model.Posts)
            };
        }

        public ICollection<CategoryPagedViewModel> ConvertToCatePagedVM(IEnumerable<Category> models)
        {
            ICollection<CategoryPagedViewModel> list = new List<CategoryPagedViewModel>();
            foreach (var item in models)
            {
                list.Add(ConvertToCatePagedVM(item));
            }
            return list;
        }

        #endregion
    }
}