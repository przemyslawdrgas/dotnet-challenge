using System;
using System.Collections.Generic;
using ZavenDotNetInterview.Entities.Models;
using ZavenDotNetInterview.Entities.ViewModels;

namespace ZavenDotNetInterview.Services
{
    public interface IJobService
    {
        Job CreateJob(string name, DateTime? doAfter);
        List<Job> GetJobs();
        Job GetJob(Guid id);
        JobViewModel GetJobViewModel(Guid id);
        AllJobsViewModel GetJobsViewModel();
    }
}