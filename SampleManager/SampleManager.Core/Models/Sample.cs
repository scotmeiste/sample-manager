using System;
using System.ComponentModel.DataAnnotations;

namespace SampleManager.Core.Models
{
    public class Sample
    {
        [Key]
        public int SampleId { get; set; }

        [Required]
        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        public int StatusId { get; set; }
        public Status Status { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
