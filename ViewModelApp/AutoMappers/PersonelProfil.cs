using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModelApp.Models;
using ViewModelApp.Models.ViewModels;

namespace ViewModelApp.AutoMappers
{
    public class PersonelProfil : Profile
    {
        public PersonelProfil()
        {
            CreateMap<Personel, PersonelCreateVM>();
            CreateMap<PersonelCreateVM,Personel>();
        }
    }
}
