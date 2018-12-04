using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ExamCRetake.Models;
namespace ExamCRetake.Models
{
    public class Activitys{
        [Key]
        public int activityId { get; set;}
        [MinLength(2)]
        public string activityName { get; set;}
        public string duration { get; set;}
        [NotMapped]
        public string timemeasure { get; set; }
        public DateTime setdate { get; set;}
        public DateTime settime { get; set;}
        public string desc { get; set;}
        public int userId {get; set;}
        public List<JoinAct> Roster { get; set; }
        public User User { get; set; }
        public DateTime stamp_created { get; set;}
        public DateTime stamp_updated { get; set;}
        public Activitys(){
            Roster = new List<JoinAct>();
            stamp_created = DateTime.Now;
            stamp_updated = DateTime.Now;
        }
    }
}