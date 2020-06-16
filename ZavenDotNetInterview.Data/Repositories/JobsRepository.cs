using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZavenDotNetInterview.Data.Context;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Data.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly IZavenDotNetInterviewContext _ctx;

        public JobsRepository(IZavenDotNetInterviewContext ctx)
        {
            _ctx = ctx;
        }

        public List<Job> GetAllJobs()
        {
            List<Job> jobs = _ctx.Jobs.ToList();
            return jobs;
        }

        public Job GetJobById(Guid id)
        {
            return GetAllJobs().Where(x => x.Id == id).FirstOrDefault();
        }

        public Job GetJobByName(string name)
        {
            return GetAllJobs().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}