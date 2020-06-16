using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Services
{
    public interface IJobLoggingService
    {
        Log Log(Job job, LogType type);
    }
}