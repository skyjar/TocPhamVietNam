namespace UI.TocHoPham.Areas.Admin.ViewModels
{
    using Core.ObjectModels.Entities;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class _ModelMapping
    {
        #region AboutUs

        public AboutUsViewModel ConvertToViewModel(AboutUs entity)
        {
            if (entity == null) return new AboutUsViewModel();
            else
            return new AboutUsViewModel
            {
                BodyHtml = entity.BodyHtml,
                CoverPhoto = entity.CoverPhoto,
                Title = entity.Title
            };
        }

        public AboutUs ConvertToModel(AboutUsViewModel viewModel)
        {
            return new AboutUs
            {
                BodyHtml = viewModel.BodyHtml,
                CoverPhoto = viewModel.CoverPhoto,
                Title = viewModel.Title
            };
        }

        #endregion

        #region Photo
        public Photo ConvertToModel(AddPhotoViewModel viewModel)
        {
            return new Photo
            {
                IsPhoto = viewModel.PhotoFile == null? false : true,
                Url = viewModel.Url,
                Alternative = viewModel.Alternative,
                GalleryId = viewModel.GalleryId,
                IsBackground = false
            };
        }

        #endregion

        #region Gallery
        public Gallery ConvertToModel(UpdateGalleryViewModel viewModel)
        {
            return new Gallery
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description
            };
        }

        public Gallery ConvertToModel(AddGalleryViewModel viewModel)
        {
            return new Gallery
            {
                Name = viewModel.Name,
                CreatedOn = DateTime.Now,
                Description = viewModel.Description,
            };
        }

        public ICollection<GetGalleryViewModel> ConvertToGetViewModel(IEnumerable<Gallery> list)
        {
            ICollection<GetGalleryViewModel> result = new List<GetGalleryViewModel>();
            list.ToList().ForEach(_ => result.Add(ConvertToGetViewModel(_)));
            return result;
        }

        public GetGalleryViewModel ConvertToGetViewModel(Gallery entity)
        {
            return new GetGalleryViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                SummaryPhotoUrl = entity.Photos.ToList().FirstOrDefault()?.Url
                ?? "https://increasify.com.au/wp-content/uploads/2016/08/default-image.png",
                PhotoNumber = entity.Photos.Count
            };
        }
        #endregion

        #region Label

        public ICollection<LabelViewModel> ConvertToViewModel(IEnumerable<Label> list)
        {
            ICollection<LabelViewModel> result = new List<LabelViewModel>();
            foreach (var item in list)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }

        public LabelViewModel ConvertToViewModel(Label item)
        {
            return new LabelViewModel
            {
                Id = item.Id,
                Name = item.Name
            };
        }
        #endregion

        #region Banner

        public ICollection<BannerViewModel> ConvertToBanner(IEnumerable<Post> list)
        {
            ICollection<BannerViewModel> viewModels = new List<BannerViewModel>();
            list.ToList().ForEach(_ => viewModels.Add(ConvertToBanner(_)));
            return viewModels;
        }

        public BannerViewModel ConvertToBanner(Post post)
        {
            return new BannerViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Categories = post.Categories,
                CoverPhoto = post.CoverPhoto,
                CreatedOn = post.CreatedOn,
                IsBanner = post.IsBanner
            };
        }
        #endregion

        #region Post

        public Post ConvertToModel(UpdatePostViewModel viewModel)
        {
            List<Label> labels = null;
            if (viewModel.Labels != null)
            {
                labels = new List<Label>();
                viewModel.Labels.ToList().ForEach(_ => labels.Add(new Label { Name = _ }));
            }

            List<Category> categories = null;
            if (viewModel.Categories != null)
            {
                categories = new List<Category>();
                viewModel.Categories.ToList().ForEach(_ => categories.Add(new Category { Id = _ }));
            }
            return new Post
            {
                Author = viewModel.Author,
                BodyHtml = viewModel.BodyHtml,
                Body = viewModel.Body,
                CoverPhoto = viewModel.CoverPhoto,
                Categories = categories,
                Labels = labels,
                Title = viewModel.Title,
                Id = viewModel.Id
            };
        }

        public UpdatePostViewModel ConvertToUpdatePostViewModel(Post model)
        {
            return new UpdatePostViewModel
            {
                Id = model.Id,
                Author = model.Author,
                Categories = model.Categories.Select(_ => _.Id),
                CreatedOn = model.CreatedOn,
                Title = model.Title,
                Body = model.Body,
                BodyHtml = model.BodyHtml,
                CoverPhoto = model.CoverPhoto,
                Labels = model.Labels.Select(_ => _.Name)
            };
        }

        public ICollection<GetPostViewModel> ConvertToViewModel(IEnumerable<Post> list)
        {
            ICollection<GetPostViewModel> result = new List<GetPostViewModel>();
            foreach (var item in list)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }

        public GetPostViewModel ConvertToViewModel(Post model)
        {
            return new GetPostViewModel
            {
                Id = model.Id,
                Author = model.Author,
                Categories = model.Categories,
                CreatedOn = model.CreatedOn,
                Title = model.Title
            };
        }

        public Post ConvertToModel(AddPostViewModel viewModel)
        {
            List<Label> labels = new List<Label>();
            foreach (var item in viewModel.Labels)
            {
                labels.Add(new Label { Name = item });
            }
            List<Category> categories = new List<Category>();
            foreach (var item in viewModel.Categories)
            {
                categories.Add(new Category { Id = item });
            }
            return new Post
            {
                Title = viewModel.Title,
                Author = viewModel.Author,
                Body = viewModel.Body,
                BodyHtml = viewModel.BodyHtml,
                CoverPhoto = viewModel.CoverPhoto,
                Labels = labels,
                Categories = categories,
                CreatedOn = DateTime.Now,
            };
        }
        #endregion

        #region Category

        public ICollection<GetCategoryViewModel> ConvertToViewModel(IEnumerable<Category> list)
        {
            ICollection<GetCategoryViewModel> result = new List<GetCategoryViewModel>();
            foreach (var item in list)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }

        public ICollection<GetCategoryViewModel> ConvertToViewModel(IEnumerable<Category> list, bool IsWithoutChild)
        {
            ICollection<GetCategoryViewModel> result = new List<GetCategoryViewModel>();
            foreach (var item in list)
            {
                result.Add(ConvertToViewModel(item, IsWithoutChild));
            }
            return result;
        }

        public Category ConvertToModel(CreateCategoryViewModel viewModel)
        {
            return new Category
            {
                Name = viewModel.Name,
                ParentId = viewModel.ParentId
            };
        }

        public Category ConvertToModel(UpdateCategoryViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
        }

        public GetCategoryViewModel ConvertToViewModel(Category model, bool IsWithoutChild)
        {
            return new GetCategoryViewModel
            {
                Id = model.Id,
                Name = model.Name,
                CategoryPath = model.CategoryPath,
                ParentId = model.ParentId,
                Childrens = null
            };
        }

        public GetCategoryViewModel ConvertToViewModel(Category model)
        {
            ICollection<GetCategoryViewModel> childrenList = new List<GetCategoryViewModel>();
            foreach (var child in model.Childrens)
            {
                childrenList.Add(new GetCategoryViewModel() {
                    Id = child.Id,
                    Name = child.Name,
                    CategoryPath = child.CategoryPath,
                    ParentId = child.ParentId,
                });
            }
            return new GetCategoryViewModel
            {
                Id = model.Id,
                Name = model.Name,
                CategoryPath = model.CategoryPath,
                ParentId = model.ParentId,
                Childrens = childrenList
            };
        }

        #endregion
    }
}