using FitKitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.ViewModels
{
    public class CoachSearchViewModel
    {
        public IList<Coach> Coaches { get; set; }
        public string searchStringImeCoach { get; set; }
        public string searchStringPrezimeCoach { get; set; }
    }
}
