namespace Core.ApplicationServices.Services
{
    using Core.ObjectModels.Entities;
    using System.Collections.Generic;

    public interface IGalleryService
    {
        void Create(Gallery entity);

        IEnumerable<Gallery> GetAll();

        Gallery Get(int id);

        void Update(Gallery entity);

        void Delete(int id);
    }
}
