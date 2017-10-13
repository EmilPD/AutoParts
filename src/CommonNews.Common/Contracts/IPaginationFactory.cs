namespace CommonNews.Common.Contracts
{
    public interface IPaginationFactory
    {
        Pagination CreatePagination(int totalItems, int? page, int pageSize = GlobalConstants.DefaultPageItems);
    }
}
