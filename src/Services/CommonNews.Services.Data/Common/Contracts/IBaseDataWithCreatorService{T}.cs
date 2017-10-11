namespace CommonNews.Services.Data.Common.Contracts
{
    using System.Linq;
    using CommonNews.Data.Models.Contracts;

    public interface IBaseDataWithCreatorService<T> : IBaseDataService<T>
        where T : class, IDeletableEntity, IAuditInfo, IEntityWithCreator
    {
        void Delete(object id, string userId);

        IQueryable<T> GetAllByUser(string userId);
    }
}
