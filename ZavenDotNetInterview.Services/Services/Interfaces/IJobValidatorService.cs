using System.Collections.Generic;
using ZavenDotNetInterview.Entities.ViewModels;

namespace ZavenDotNetInterview.Services
{
    public interface IJobValidatorService
    {
        Dictionary<string, string> ValidateJob(CreateJobViewModel model);
    }
}