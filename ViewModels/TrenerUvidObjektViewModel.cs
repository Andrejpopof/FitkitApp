using FitKitApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.ViewModels
{
    public class TrenerUvidObjektViewModel
    {
        public IList<Zaclenuvanje> Termini { get; set; }

        public SelectList OdobrNeodobr { get; set; }

        public string searchStringImeObjekt { get; set;}

        public string searchStringOdobrNeodobr { get; set; }
    }
}
