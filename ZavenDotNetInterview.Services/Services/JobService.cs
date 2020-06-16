using System;
using System.Linq;
using System.Collections.Generic;
using ZavenDotNetInterview.Data.Context;
using ZavenDotNetInterview.Data.Repositories;
using ZavenDotNetInterview.Entities.Models;
using ZavenDotNetInterview.Entities.ViewModels;

namespace ZavenDotNetInterview.Services
{
    public class JobService : IJobService
    {
        private IZavenDotNetInterviewContext _ctx;
        private readonly IJobLoggingService _jobLoggingService;

        public JobService(IZavenDotNetInterviewContext ctx, IJobLoggingService jobLoggingService)
        {
            _ctx = ctx;
            _jobLoggingService = jobLoggingService;
        }

        public Job CreateJob(string name, DateTime? doAfter)
        {
            Job job = new Job() { Id = Guid.NewGuid(), DoAfter = doAfter, Name = name, Status = JobStatus.New, CreatedAt = DateTime.UtcNow };
            job = _ctx.Jobs.Add(job);
            _jobLoggingService.Log(job, LogType.Created);
            _ctx.SaveChanges();
            return job;
        }

        public List<Job> GetJobs()
        {
            JobsRepository jobsRepository = new JobsRepository(_ctx);
            List<Job> jobs = jobsRepository.GetAllJobs();
            return jobs;
        }

        public Job GetJob(Guid id)
        {
            JobsRepository jobsRepository = new JobsRepository(_ctx);
            Job job = jobsRepository.GetJobById(id);
            return job;
        }

        public JobViewModel GetJobViewModel(Guid id)
        {
            Job job = GetJob(id);
            List<LogViewModel> logs = new List<LogViewModel>();
            foreach (Log log in job.Logs)
            {
                logs.Add(new LogViewModel(log));
            }
            JobViewModel jobViewModel = new JobViewModel(job, logs.OrderByDescending(x => x.CreatedAt).ToList());
            return jobViewModel;
        }

        public AllJobsViewModel GetJobsViewModel()
        {
            AllJobsViewModel jobsViewModel = new AllJobsViewModel();
            List<LogViewModel> logs = new List<LogViewModel>();
            foreach (Job job in GetJobs().OrderByDescending(x => x.CreatedAt))
            {
                jobsViewModel.Jobs.Add(new JobViewModel(job, null));
            }
            return jobsViewModel;
        }
    }
}