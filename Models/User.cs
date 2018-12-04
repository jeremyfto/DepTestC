using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamCRetake.Models
{
    public class User{
        [Key]
        public int userId { get; set;}
        [Required(ErrorMessage="First Name is required")]
        [MinLength(2)]
        public string FirstName { get; set;}
        [Required]
        [MinLength(2)]
        public string LastName { get; set;}
        [EmailAddress]
        [Required]
        public string Email { get; set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set;}
        [Required]
        [NotMapped]
        public string ConfirmPass { get; set; }
        public List<JoinAct> JoinedAct { get; set; }
        public DateTime stamp_created { get; set;}
        public DateTime stamp_updated { get; set;}
        public User(){
            stamp_created = DateTime.Now;
            stamp_updated = DateTime.Now;
            JoinedAct = new List<JoinAct>();
        }
    }
}