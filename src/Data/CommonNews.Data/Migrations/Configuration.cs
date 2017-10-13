namespace CommonNews.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Bytes2you.Validation;
    using Common;

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            Guard.WhenArgument(context, "MsSqlDbContext").IsNull().Throw();
        }
    }
}
