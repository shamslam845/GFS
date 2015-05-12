using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GFS.Models
{
    public class Email
    {
        [Key, Required, ScaffoldColumn(false)]
        public int EmailID { get; set; }

        [Required, StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        public int SectionID { get; set; }
    }
}