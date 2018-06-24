namespace Service.Implement.Implement
{
    using Core.ObjectModels.Entities;
    using Core.ObjectServices.Repositories;
    using Core.ApplicationServices.Services;
    using System.Collections.Generic;
    using System.Transactions;

    public class LabelService : _BaseService<Label>, ILabelService
    {
        public LabelService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AddRange(IEnumerable<Label> entities)
        {
            using(TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                foreach (var entity in entities)
                {
                    Label tmp = iRepository.Get(_ => _.Name == entity.Name);
                    if (tmp == null)
                    {
                        base.Create(entity);
                    }
                }
                scope.Complete();
            }
        }

        public IEnumerable<Label> GetAll()
        {
            return iRepository.GetAll();
        }
    }
}