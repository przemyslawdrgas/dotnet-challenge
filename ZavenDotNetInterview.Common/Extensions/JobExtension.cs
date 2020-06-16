using System;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Common.Extensions
{
    public static class JobExtension
    {
        public static void ChangeStatus(this Job job, JobStatus newStatus)
        {
            job.Status = newStatus;
            job.LastUpdatedAt = DateTime.UtcNow;
        }

        public static bool CanBeProcessed(this Job job)
        {
            var properStatus = (job.Status == JobStatus.New || job.Status == JobStatus.Failed);
            var properDate = job.DoAfter < DateTime.UtcNow || job.DoAfter == null;
            return properStatus && properDate;
        }
    }
}