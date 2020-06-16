using System;
using System.ComponentModel.DataAnnotations;
using ZavenDotNetInterview.Resources;

namespace ZavenDotNetInterview.Entities.ViewModels
{
    public class CreateJobViewModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = nameof(ErrorMessage.NameInvalid))]
        [MaxLength(30, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = nameof(ErrorMessage.NameTooLong))]
        [Display(Name = nameof(Interface.Name), ResourceType = typeof(Interface))]
        public string Name { get; set; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = nameof(ErrorMessage.DateInputRequired))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = nameof(Interface.ProcessAfter), ResourceType = typeof(Interface))]
        public DateTime? DoAfter { get; set; }
    }
}