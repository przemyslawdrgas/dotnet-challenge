namespace ZavenDotNetInterview.App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZavenDotNetInterview.Data.Context;

    internal sealed class Configuration : DbMigrationsConfiguration<ZavenDotNetInterviewContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZavenDotNetInterviewContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
