using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZavenDotNetInterview.Data.Context;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Data.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly IZavenDotNetInterviewContext _ctx;

        public LogsRepository(IZavenDotNetInterviewContext ctx)
        {
            _ctx = ctx;
        }

        public Log InsertLog(Log log)
        {
            Log created = _ctx.Logs.Add(log);
            _ctx.SaveChanges();
            return created;
        }
    }
}