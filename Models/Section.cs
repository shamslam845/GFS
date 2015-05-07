using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace GFS.Models
{
    public class Section
    {
        [Key, Required, ScaffoldColumn(false)]
        public int SectionID { get; set; }

        [Required]
        public int SectionNumber { get; set; }

        [Required, StringLength(20), Display(Name = "CourseName")]
        public string CourseName { get; set; }

        [Required, StringLength(128), Display(Name = "UserID")]
        public string UserID { get; set; }

        [Required]
        public int FormContainerID { get; set; }
    }
}