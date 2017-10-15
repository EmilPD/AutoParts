namespace CommonNews.Data.Common.Contracts
{
    using System.Data.Entity;

    public interface IEntryState<T>
    {
        EntityState State { get; set; }
    }
}
