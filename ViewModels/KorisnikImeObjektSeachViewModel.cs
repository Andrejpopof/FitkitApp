using FitKitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.ViewModels
{
    public class KorisnikImeObjektSeachViewModel
    {
        public IList<Zaclenuvanje> Zaclenuvanjes { get; set; }

        public string searchStringImeObjekt { get; set; }
    }
}
