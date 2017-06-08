using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleManager.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Sample> Samples { get; set; }
    }
}
