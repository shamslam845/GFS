using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GFS.Models
{
    public class FormContainer
    {
        [Key, Required, ScaffoldColumn(false)]
        public int FormContainerID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }

        [Required, StringLength(128)]
        public string UserID { get; set; }

        public virtual ICollection<Form> Forms { get; set; }
    }
}