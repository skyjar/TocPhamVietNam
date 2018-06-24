namespace DependencyResolver.Modules
{
    using Core.ApplicationServices.IdentityServices;
    using Core.ApplicationServices.Services;
    using Infrastructure.Identity.Adapter;
    using Ninject.Modules;
    using Service.Implement.Implement;

    public class ServiceModules : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<IPostService>().To<PostService>();
            Bind<ILabelService>().To<LabelService>();
            Bind<IGalleryService>().To<GalleryService>();
            Bind<IPhotoService>().To<PhotoService>();
            Bind<IAboutUsService>().To<AboutUsService>();
            Bind<IIdentityService>().To<IdentityAdapter>();
        }
    }
}