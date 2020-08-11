using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.Models
{
    public class Objekt
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Ime { get; set; }

        [Display(Name = "Квадратура")]
        public int Kvadratura { get; set; }

        [Display(Name = "Населба")]
        public string Lokacija { get; set; }

        [Display(Name = "Макс. посетители")]
        public int MaxClients { get; set; }

        [Display(Name = "Тип на вежбање")]
        public string TipVezbanje { get; set; }

        [Display(Name = "Отворено/Затворено")]
        public string OtvorZatvor { get; set; }


        public int? Coach1Id { get; set; }
        [Display(Name = "Тренер 1")]
        public Coach Coach1 { get; set; }

        public int? Coach2Id { get; set; }
        [Display(Name = "Тренер 2")]
        public Coach Coach2 { get; set; }

        public ICollection<Zaclenuvanje> Korisnici { get; set; }
    }
}
