using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GFS.Models
{
    public class Form
    {
        [Key, Required, ScaffoldColumn(false)]
        public int FormID { get; set; }

        [Required,StringLength(200)]
        public string Title { get; set; }

        [Required]
        public int? FormType { get; set; }

        [Required]
        public int FormContainerID { get; set; }

        public virtual FormContainer FormContainer { get; set; }
    }
}