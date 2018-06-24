namespace Service.Implement.Implement
{
    using Core.ObjectModels.Entities;
    using Core.ObjectServices.Repositories;
    using Core.ApplicationServices.Services;

    public class CommentService : _BaseService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}