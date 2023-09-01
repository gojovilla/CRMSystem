using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Models
{
    public class Criminal
    {
        //enter field  change

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        //[Range(1, 100, ErrorMessage = "Emaid Id should be  between 1 & 100")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        // [Range(1, 15, ErrorMessage = "Password should be  between 1 & 15")]
        public string? LastName  { get; set; }

        [Required]
        [DisplayName("Age")]
        //[Range(1, 15, ErrorMessage = "User Name should be between 1 & 15")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Address")]
        public string? Address { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        public string? ContactNumber { get; set; }

        [Required]
        [DisplayName("Location Of Incident")]
        public string? LocationOfIncident { get; set; }
        [Required]
        [DisplayName("Type Of Incident")]
        public string? TypeOfIncident { get; set; }

        [Required]
        [DisplayName("Date Time Of Incident")]
        public string? IncidentDateTime { get; set; } 

        [Required]
        [DisplayName("Date Time Reported")]
        public string? DateTimeReported { get; set; }

        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
    }
}
