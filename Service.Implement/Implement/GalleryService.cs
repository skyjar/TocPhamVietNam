namespace Service.Implement.Implement
{
    using System.Collections.Generic;
    using System.Transactions;
    using Core.ApplicationServices.Services;
    using Core.ObjectModels.Entities;
    using Core.ObjectServices.Repositories;

    public class GalleryService : _BaseService<Gallery>, IGalleryService
    {
        public GalleryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Gallery Get(int id)
        {
            return iRepository.Get(_ => _.Id == id, _ => _.Photos);
        }

        public IEnumerable<Gallery> GetAll()
        {
            return iRepository.GetAll(_ => _.Photos);
        }
        
        public void Delete(int id)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                base.Delete(iRepository.Get(_ => _.Id == id));
                scope.Complete();
            }
        }

    }
}
