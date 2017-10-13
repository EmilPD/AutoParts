namespace CommonNews.Services.Data
{
    using System;
    using System.Linq;
    using Bytes2you.Validation;
    using Common.Contracts;
    using CommonNews.Data.Common.Contracts;
    using CommonNews.Data.Models.Contracts;

    public class DataService<T> : IDataService<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        public DataService(IEfRepository<T> repo, ISaveContext context)
        {
            Guard.WhenArgument(repo, "IEfRepository").IsNull().Throw();
            Guard.WhenArgument(context, "ISaveContext").IsNull().Throw();

            this.Data = repo;
            this.Context = context;
        }

        protected IEfRepository<T> Data { get; set; }

        protected ISaveContext Context { get; set; }

        public virtual void Add(T item)
        {
            Guard.WhenArgument(item, "Add item").IsNull().Throw();

            this.Data.Add(item);
            this.Context.Commit();
        }

        public void Update(T item)
        {
            Guard.WhenArgument(item, "Update item").IsNull().Throw();

            this.Data.Update(item);
            this.Context.Commit();
        }

        public virtual void Delete(object id)
        {
            Guard.WhenArgument(id, "Delete object with id").IsNull().Throw();

            var entity = this.Data.GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException("No entity with provided id found.");
            }

            this.Data.Delete(entity);
            this.Context.Commit();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.Data.All();
        }

        public virtual IQueryable<T> Get(int count)
        {
            return this.Data.All().Take(count);
        }

        public virtual T GetById(object id)
        {
            Guard.WhenArgument(id, "GetById").IsNull().Throw();

            return this.Data.GetById(id);
        }

        public virtual void Save()
        {
            this.Context.Commit();
        }
    }
}
