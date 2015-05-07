using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;

namespace GFS.Models
{
    public class FeedbackContainer
    {
        [Key, Required, ScaffoldColumn(false)]
        public int FeedbackContainerID { get; set; }

        [Required, Display(Name="DateTime")]
        public DateTime DateTimes { get; set; }

        [Required]
        public int FormContainerID { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}