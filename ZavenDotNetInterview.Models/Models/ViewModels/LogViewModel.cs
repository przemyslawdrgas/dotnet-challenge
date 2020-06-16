using System;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Entities.ViewModels
{
    public class LogViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public LogViewModel(Log log)
        {
            Id = log.Id;
            Description = log.Description;
            CreatedAt = log.CreatedAt;
        }
    }
}