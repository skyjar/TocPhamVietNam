namespace Core.ApplicationServices.Services
{
    using Core.ObjectModels.Entities;

    public interface IImageService
    {
        Photo Get(int id);

        void Create(Photo entity);

        void Update(Photo entity);

        void Delete(Photo entity);
    }
}
