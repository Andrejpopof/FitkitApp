using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.Models
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Име")]
        [StringLength(30)]

        public string Ime { get; set; }

        [Display(Name = "Презиме")]
        [StringLength(30)]

        public string Prezime { get; set; }


        [Display(Name = "Висина(cm)")]
        public float Visina { get; set; }

        [Display(Name = "Тежина(kg)")]
        public float Tezina { get; set; }


        [Display(Name = "Дата на раѓање")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [DataType(DataType.Currency)]
        [Display(Name = "Плата")]
        public float Plata { get; set; }

        public string Profilna { get; set; }

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

        [Display(Name = "Ниво на едукација")]
        public string EducationLevel { get; set; }

        public ICollection<Objekt> Objekti1 { get; set; }

        public ICollection<Objekt> Objekti2 { get; set; }
    }
}
