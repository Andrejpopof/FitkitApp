using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Име")]
        [StringLength(30)]
        [Required]
        public string Ime { get; set; }


        [Display(Name = "Презиме")]
        [StringLength(30)]
        [Required]
        public string Prezime { get; set; }

        [Display(Name = "Дата на раѓање")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                TimeSpan span = DateTime.Now - BirthDate;
                double years = (double)span.TotalDays / 365.2425;
                return (int)years;
            }
        }

        [Display(Name = "Име и Презиме")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", Ime, Prezime);
            }
        }

        public string ProfilePic { get; set; }

        [Display(Name = "Висина(cm)")]
        [Required]
        public int Visina { get; set; }

        [Display(Name = "Тежина(kg)")]
        [Required]
        public float Tezina { get; set; }

        [Display(Name = "Обем на гради(cm)")]
        public int ObemGradi { get; set; }


        [Display(Name = "Обем на лев бицепс(cm)")]
        public int ObemLevBiceps { get; set; }


        [Display(Name = "Обем на десен бицепс(cm)")]
        public int ObemDesenBiceps { get; set; }


        [Display(Name = "Обем на струк(cm)")]
        public int ObemStruk { get; set; }


        [Display(Name = "Обем на лев бут(cm)")]
        public int ObemLevBut { get; set; }


        [Display(Name = "Обем на десен бут(cm)")]
        public int ObemDesenBut { get; set; }


        
        public ICollection<Zaclenuvanje> Objekti { get; set; }
    }
}
