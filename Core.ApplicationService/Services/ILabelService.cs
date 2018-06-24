namespace Core.ApplicationServices.Services
{
    using Core.ObjectModels.Entities;
    using System.Collections.Generic;

    public interface ILabelService
    {
        IEnumerable<Label> GetAll();

        void AddRange(IEnumerable<Label> entities);
    }
}