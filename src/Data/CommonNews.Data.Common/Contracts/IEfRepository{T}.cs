namespace CommonNews.Data.Common.Contracts
{
    using System.Linq;

    using Models.Contracts;

    public interface IEfRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
