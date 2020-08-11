using FitKitApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.ViewModels
{
    public class ObjektSeachViewModel
    {
        public IList<Objekt> Objekts { get; set; }

        public SelectList TipoviVezbanje { get; set; }

        public string searchStringImeObjekt { get; set; }

        public string searchStringTipVezbanje { get; set; }

    }
}
