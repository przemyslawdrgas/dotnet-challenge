using System;
using System.Collections.Generic;
using ZavenDotNetInterview.Data.Context;
using ZavenDotNetInterview.Data.Repositories;
using ZavenDotNetInterview.Entities.ViewModels;
using ZavenDotNetInterview.Resources;

namespace ZavenDotNetInterview.Services
{
    public class JobValidatorService : IJobValidatorService
    {
        private IZavenDotNetInterviewContext _ctx;
        private IJobsRepository _jobsRepository;

        public JobValidatorService(IZavenDotNetInterviewContext ctx, IJobsRepository jobsRepository)
        {
            _ctx = ctx;
            _jobsRepository = jobsRepository;
        }

        private bool NameIsValid(CreateJobViewModel model)
        {
            string name = model.Name;
            var job = _jobsRepository.GetJobByName(name);

            if (job != null)
                return false;
            else
                return true;

        }

        private bool DateIsValid(CreateJobViewModel model)
        {
            DateTime? date = model.DoAfter;

            if (date == null)
                return true;

            if (date >= DateTime.UtcNow)
                return true;
            else
                return false;
        }

        public Dictionary<string, string> ValidateJob(CreateJobViewModel model)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (!NameIsValid(model))
                errors.Add(nameof(CreateJobViewModel.Name), ErrorMessage.JobWithNameExists);
            if (!DateIsValid(model))
                errors.Add(nameof(CreateJobViewModel.DoAfter), ErrorMessage.DateTooSmall);

            return errors;
        }
    }
}