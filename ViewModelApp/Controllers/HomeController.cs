using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ViewModelApp.Models;
using ViewModelApp.Models.ViewModels;

namespace ViewModelApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(PersonelCreateVM personelCreateviewModel)
        {

            var personel = _mapper.Map<Personel>(personelCreateviewModel);      //Burada bize personel entitisi verir.
            var personelCreateVM = _mapper.Map<PersonelCreateVM>(personel);     // Burada da PersonelCreateVM verir.


            //Personel p = new Personel()
            //{
            //    Adi = personelCreateviewModel.Adi,                                          //AMELEUS
            //    Soyadi = personelCreateviewModel.Soyadi
            //};


            // ilgili işlemleri veritabanına yolluyoruz.
            return View();
        }


        public IActionResult Listele()
        {
            List<PersonelListVM> personeller = new List<Personel>
            {
                new Personel{Adi = "Ahmet " , Soyadi = "Balçık"},
                new Personel{Adi = "Mehmet " , Soyadi = "Balçık"},
                new Personel{Adi = "Tuna " , Soyadi = "Balçık"},
                new Personel{Adi = "Zeki " , Soyadi = "Balçık"},
            }.Select(p => new PersonelListVM { 
                   Adi = p.Adi,
                   Soyadi = p.Soyadi
            }).ToList();

            return View(personeller);
        }

        public IActionResult Get()
        {
            //var nesne = (new Personel(), new Urun(), new Musteri());
            return View();
        }
    }
}
