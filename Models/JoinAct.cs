using System;
using System.ComponentModel.DataAnnotations;

namespace ExamCRetake.Models
{
    public class JoinAct
    {
        [Key]
        public int joinactId {get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public int activityId { get; set; }

        public User User { get; set; }
        public Activitys Activities { get; set; }

    }
}