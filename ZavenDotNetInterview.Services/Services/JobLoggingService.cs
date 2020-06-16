using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZavenDotNetInterview.Data.Context;
using ZavenDotNetInterview.Data.Repositories;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Services
{
    public class JobLoggingService : IJobLoggingService
    {
        private LogsRepository _logsRepository;

        public JobLoggingService(IZavenDotNetInterviewContext ctx, LogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public Log Log(Job job, LogType type)
        {
            Log log = new Log() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, JobId = job.Id, Description = GetDescription(job, type) };

            return _logsRepository.InsertLog(log);
        }

        private string GetDescription(Job job, LogType type)
        {
            string result = string.Empty;

            switch (type)
            {
                case LogType.StatusChanged:
                    result = String.Format("Status changed to {0}", job.Status.ToString());
                    break;
                case LogType.Created:
                    result = String.Format("Job has been created");
                    break;
                default:
                    break;
            }

            return result;
        }
    }

    public enum LogType
    {
        StatusChanged,
        Created
    }
}