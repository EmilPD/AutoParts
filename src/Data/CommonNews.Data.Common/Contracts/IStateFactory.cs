namespace CommonNews.Data.Common.Contracts
{
    using System.Data.Entity.Infrastructure;

    public interface IStateFactory
    {
        IEntryState<T> CreateState<T>(DbEntityEntry<T> entry)
            where T : class;
    }
}
