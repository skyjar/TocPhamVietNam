namespace Service.Implement.Implement
{
    using Core.ApplicationServices.Services;
    using Core.ObjectModels.Entities;
    using Core.ObjectServices.Repositories;

    public class ImageService : _BaseService<Photo>, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Photo Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
