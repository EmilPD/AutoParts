namespace CommonNews.Data.Common
{
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        public Configuration()
        {
            //this.AutomaticMigrationsEnabled = false;
            //this.AutomaticMigrationDataLossAllowed = false;
        }
    }
}
