namespace CommonNews.Data.Common
{
    using Bytes2you.Validation;
    using Contracts;

    public class SaveContext : ISaveContext
    {
        private readonly MsSqlDbContext context;

        public SaveContext(MsSqlDbContext context)
        {
            Guard.WhenArgument(context, "MsSqlDbContext").IsNull().Throw();

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
