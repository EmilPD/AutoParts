namespace CommonNews.Data.Tests.Mock
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Moq;

    public class QueryableDbSetMock
    {
        public static DbSet<T> GetQueryableMockDbSet<T>(IEnumerable<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            dbSet.Setup(s => s.Find(It.IsAny<Guid>())).Returns(sourceList.FirstOrDefault());
            dbSet.Setup(s => s.Add(It.IsAny<T>())).Throws(new ArgumentNullException("verify add call"));
            dbSet.Setup(s => s.Remove(It.IsAny<T>())).Throws(new ArgumentNullException("verify remove call"));
            dbSet.Setup(s => s.Attach(It.IsAny<T>())).Throws(new ArgumentNullException("verify attach call"));

            return dbSet.Object;
        }
    }
}
