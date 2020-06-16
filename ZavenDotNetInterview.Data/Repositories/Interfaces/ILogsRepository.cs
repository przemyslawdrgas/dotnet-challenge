using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Data.Repositories
{
    public interface ILogsRepository
    {
        Log InsertLog(Log log);
    }
}