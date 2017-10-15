namespace CommonNews.Web.App_Start
{
    using System.Data.Entity;
    using Data.Common;

    public static class DatabaseConfig
    {
        public static void Config()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlDbContext, Configuration>());
        }
    }
}
