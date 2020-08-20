using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Улога")]
        public string Role { get; set; }
        public int? CoachId { get; set; }
        [Display(Name = "Тренер")]
        [ForeignKey("CoachId")]
        public Coach Coach { get; set; }
        public int? UserId { get; set; }
        [Display(Name = "Корисник")]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
