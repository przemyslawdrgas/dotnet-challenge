using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZavenDotNetInterview.Entities.Models
{
    public class Job
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public JobStatus Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DoAfter { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual List<Log> Logs { get; set; }
        public int Attempts { get; set; } = 0;
    }

    public enum JobStatus
    {
        Closed = -2,
        Failed = -1,
        New = 0,
        InProgress = 1,
        Done = 2
    }
}