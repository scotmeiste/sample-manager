using System;
using System.ComponentModel.DataAnnotations;

namespace SampleManager.Core.ViewModels
{
    public class SampleViewModel
    {
        public int SampleId { get; set; }
        public string Status { get; set; }

        [Required]
        public string Barcode { get; set; }

        public DateTime CreatedAt { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}
