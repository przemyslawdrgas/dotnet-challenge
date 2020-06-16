using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Data.Context
{
    public class ZavenDotNetInterviewContext : DbContext, IZavenDotNetInterviewContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Log> Logs { get; set; }

        public ZavenDotNetInterviewContext() : base("name=ZavenDotNetInterview")
        {
        }
    }
}