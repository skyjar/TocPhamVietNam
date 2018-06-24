namespace Service.Implement.Implement
{
    using Core.ApplicationServices.Services;
    using Core.ObjectModels.Entities;
    using Core.ObjectServices.Repositories;
    using System.Linq;
    using System.Transactions;

    public class AboutUsService : _BaseService<AboutUs>, IAboutUsService
    {
        public AboutUsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public AboutUs Get()
        {
            return iRepository.GetAll().FirstOrDefault();
        }

        public override void Update(AboutUs entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var currentEntity = iRepository.GetAll().FirstOrDefault();
                if (currentEntity == null)
                {
                    base.Create(entity);
                }
                else
                {
                    currentEntity.BodyHtml = entity.BodyHtml;
                    currentEntity.CoverPhoto = entity.CoverPhoto;
                    currentEntity.Title = entity.Title;
                    base.Update(currentEntity);
                }
                scope.Complete();
            }
        }
    }
}
