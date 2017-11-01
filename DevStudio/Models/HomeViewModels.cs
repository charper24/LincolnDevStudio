using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevStudio.Models
{
    public class IndexViewModels
    {
        [Required]  
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Url/Website")]
        public string Url { get; set; }

        [DisplayName("Description of Group")]
        public string GroupDescription { get; set; }

        [Required]
        [DisplayName("Description of Request")]
        public string RequestDescription { get; set; }

        [DisplayName("Request Timestamp")]
        public DateTime RequestTimestamp { get; set; }

        [DisplayName("Request Status")]
        public string RequestStatus { get; set; }

        [DisplayName("Request Notes")]
        public string RequestNotes { get; set; }

    }

    public class ViewSubmissionModel
    {
        public List<IndexViewModels> SubmissionModels { get; set; }
    }

}