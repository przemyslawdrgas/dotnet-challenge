using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavenDotNetInterview.Data.Repositories;
using ZavenDotNetInterview.Data.Context;
using ZavenDotNetInterview.Entities.Models;
using ZavenDotNetInterview.Common.Extensions;

namespace ZavenDotNetInterview.Services
{
    public class JobProcessorService : IJobProcessorService
    {
        private IZavenDotNetInterviewContext _ctx;
        private readonly IJobLoggingService _jobLoggingService;
        private readonly IJobsRepository _jobsRepository;

        public JobProcessorService(IZavenDotNetInterviewContext ctx, IJobLoggingService jobLoggingService, IJobsRepository jobsRepository)
        {
            _ctx = ctx;
            _jobLoggingService = jobLoggingService;
            _jobsRepository = jobsRepository;
        }

        public async Task ProcessJobs()
        {
            var allJobs = _jobsRepository.GetAllJobs();
            var jobsToProcess = allJobs.Where(x => x.CanBeProcessed()).ToList();

            foreach (Job job in jobsToProcess)
            {
                ChangeJobStatus(job, JobStatus.InProgress);
                _jobLoggingService.Log(job, LogType.StatusChanged);
            }

            List<Task> tasks = new List<Task>();

            foreach (Job job in jobsToProcess)
            {
                tasks.Add(Task.Run(async () =>
                {
                    bool result = await this.ProcessJob(job).ConfigureAwait(false);
                    if (result)
                    {
                        ChangeJobStatus(job, JobStatus.Done);
                    }
                    else
                    {
                        job.Attempts += 1;

                        if (job.Attempts >= 5)
                            ChangeJobStatus(job, JobStatus.Closed);
                        else
                            ChangeJobStatus(job, JobStatus.Failed);
                    }
                }));
            };

            await Task.WhenAll(tasks);

            foreach (Job job in jobsToProcess)
            {
                _jobLoggingService.Log(job, LogType.StatusChanged);
            }

            _ctx.SaveChanges();
        }

        private void ChangeJobStatus(Job job, JobStatus status)
        {
            job.ChangeStatus(status);
        }

        private async Task<bool> ProcessJob(Job job)
        {
            Random rand = new Random();
            if (rand.Next(10) < 5)
            {
                await Task.Delay(2000);
                return false;
            }
            else
            {
                await Task.Delay(1000);
                return true;
            }
        }
    }
}