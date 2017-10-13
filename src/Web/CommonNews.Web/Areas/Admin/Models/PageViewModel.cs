namespace CommonNews.Web.Areas.Admin.Models
{
    using System.Collections.Generic;
    using Common;

    public class PageViewModel<T>
        where T : class
    {
        public virtual IEnumerable<T> Items { get; set; }

        public virtual Pagination Pagination { get; set; }
    }
}