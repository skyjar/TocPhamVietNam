namespace Service.Implement.Implement
{
    using Core.ApplicationServices.Services;
    using Core.ObjectModels.Entities;
    using Core.ObjectServices.Repositories;
    using System.Linq;
    using System.Transactions;

    public class PhotoService : _BaseService<Photo>, IPhotoService
    {
        public PhotoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void ChangeBackgroundPhoto(int photoId)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var currentBackground = iRepository.Get(_ => _.IsBackground);
                if (currentBackground != null) currentBackground.IsBackground = false;

                iRepository.Get(_ => _.Id == photoId).IsBackground = true;
                iUnitOfWork.Save();
                scope.Complete();
            }
        }

        public void Delete(int keyValues)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                base.Delete(iRepository.Get(_ => _.Id == keyValues));
                scope.Complete();
            }
        }


    }
}
