using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;

namespace GFS.Models
{
    public class Feedback
    {
        [Key, Required, ScaffoldColumn(false)]
        public int FeedbackID { get; set; }

        [Required, StringLength(500), Display(Name = "Message")]
        public string Message { get; set; }

        [Required, StringLength(128), Display(Name = "UserID")]
        public string UserID { get; set; }

        [Required]
        public int FeedbackContainerID { get; set; }

        [Required]
        public int SectionID { get; set; }

        public virtual FeedbackContainer FeedbackContainer { get; set; }
    }
}