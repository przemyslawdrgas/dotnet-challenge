using System;
using System.Data.Entity;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Data.Context
{
    public interface IZavenDotNetInterviewContext : IDisposable
    {
        DbSet<Job> Jobs { get; set; }
        DbSet<Log> Logs { get; set; }

        int SaveChanges();
    }
}