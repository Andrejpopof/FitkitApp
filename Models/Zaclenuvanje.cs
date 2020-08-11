using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.Models
{
    public class Zaclenuvanje
    {
        public int Id { get; set; }
        public int ObjektId { get; set; }

        [Display(Name = "Објект")]
        public Objekt Objekt { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Корисник")]
        public User User { get; set; }

        [Display(Name = "Термин")]
        public DateTime Termin { get; set; }

        [Display(Name = "Одобрен/Неодобрен")]
        public string OdobrenNeodobren { get; set; }
    }
}
