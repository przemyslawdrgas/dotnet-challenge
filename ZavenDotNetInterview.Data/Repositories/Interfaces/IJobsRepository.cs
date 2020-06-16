using System;
using System.Collections.Generic;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Data.Repositories
{
    public interface IJobsRepository
    {
        List<Job> GetAllJobs();
        Job GetJobByName(string name);
        Job GetJobById(Guid id);
    }
}