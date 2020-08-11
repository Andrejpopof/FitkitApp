using FitKitApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.ViewModels
{
    public class TerminSearchViewModel
    {
        public IList<Zaclenuvanje> Termini { get; set; }

        public SelectList Status { get; set; }

        public string searchStringImeKorisnik { get; set; }

        public string searchStringImeObjekt { get; set; }

        public string searchStringStatus { get; set; }

    }
}
