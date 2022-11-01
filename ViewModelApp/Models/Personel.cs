using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModelApp.Models.ViewModels;

namespace ViewModelApp.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Pozisyon { get; set; }
        public int Maas { get; set; }
        public bool MedeniHal { get; set; }

    }
}
