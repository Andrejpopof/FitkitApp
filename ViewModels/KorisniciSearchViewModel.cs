using FitKitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.ViewModels
{
    public class KorisniciSearchViewModel
    {
        public  IList<User> Users { get; set; }

        public string  searchStringImeKorisnik { get; set; }

        public string  searchStringPrezimeKorisnik { get; set; }

    }
}
