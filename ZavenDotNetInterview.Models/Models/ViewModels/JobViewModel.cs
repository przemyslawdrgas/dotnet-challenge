using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZavenDotNetInterview.Entities.Models;

namespace ZavenDotNetInterview.Entities.ViewModels
{
    public class JobViewModel
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name.")]
        public string Name { get; set; }
        public JobStatus Status { get; set; }

        [DataType(DataType.Date, ErrorMessage = "This field requires Date as an input")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DoAfter { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual List<LogViewModel> Logs { get; set; }
        public int Attempts { get; set; } = 0;

        public JobViewModel(Job job, List<LogViewModel> logs)
        {
            Id = job.Id;
            Name = job.Name;
            Status = job.Status;
            DoAfter = job.DoAfter;
            LastUpdatedAt = job.LastUpdatedAt;
            CreatedAt = job.CreatedAt;
            Logs = logs;
            Attempts = job.Attempts;
        }
    }
}