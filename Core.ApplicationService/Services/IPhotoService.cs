namespace Core.ApplicationServices.Services
{
    using Core.ObjectModels.Entities;

    public interface IPhotoService
    {
        void Create(Photo entity);

        void Delete(int keyValues);

        void ChangeBackgroundPhoto(int photoId);
        
    }
}
