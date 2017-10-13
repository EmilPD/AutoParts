namespace CommonNews.Services.Data.Common.Contracts
{
    using System;
    using System.Linq;
    using CommonNews.Data.Models.Contracts;

    public interface IDataService<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        void Add(T item);

        void Update(T item);

        void Delete(object id);

        IQueryable<T> GetAll();

        IQueryable<T> Get(int count);

        T GetById(object id);

        void Save();
    }
}
