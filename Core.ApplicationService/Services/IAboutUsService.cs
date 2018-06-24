namespace Core.ApplicationServices.Services
{
    using Core.ObjectModels.Entities;

    public interface IAboutUsService
    {
        void Update(AboutUs entity);

        AboutUs Get();
    }
}
