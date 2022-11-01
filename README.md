# ViewModel-Example
ViewModeli ve dönüştürülmesini daha iyi pekiştirmek amacıyla çalıştığım bir repo. 

![1](https://user-images.githubusercontent.com/68101192/199297041-62f168e0-88fa-4d79-acf3-e2a43cd51e7b.png)
![2](https://user-images.githubusercontent.com/68101192/199297093-14375b67-2ffa-4664-8fe2-6d28af5b4fcc.png)
![3](https://user-images.githubusercontent.com/68101192/199297125-e3fe2524-881c-4df9-89f3-80c46ba8b7ed.png)


# ViewModeli Entity'e Dönüştürme #

## 1.Yöntem ##
            Personel p = new Personel()
            {
               Adi = personelCreateviewModel.Adi,                                          //AMELEUS
                Soyadi = personelCreateviewModel.Soyadi
            };
            
            
            //Personel
             public static implicit operator PersonelCreateVM(Personel model)
            {
                return new PersonelCreateVM 
                {                                                                         // İmplicit/Gizli / Bilinçsiz - Personeli PersonelCreateVM e dönüştürme
                    Adi = model.Adi,                                                      // Bu işlem Personel sınıfında yapılmaktadır.
                    Soyadi = model.Soyadi
                };
            }
            
            // PersonelCreateVM
            public static implicit operator Personel(PersonelCreateVM model)
            {
                return new Personel                                                       // PersonelCreateVMi Personele  dönüştürme (Bu işlem PersonelCreateVM de yapılmaktadır)
                {
                    Adi = model.Adi,
                    Soyadi = model.Soyadi
                };
            }
           
           //HomeController
            Personel personel = personelCreateviewModel;
            PersonelCreateVM vm = personel;


## Ve ViewModel ve Dtoları entitlere dönüştürmek için son metodumuz da Automapper kütüphanesi ##

1. AutoMapper kütüphanesini ekliyoruz projemize 
2. AutoMappers klasörü Profil sınıflarımızı oluşturuyoruz.

              public class PersonelProfil : Profile
              {
                  public PersonelProfil()
                  {
                      CreateMap<Personel, PersonelCreateVM>();
                      CreateMap<PersonelCreateVM,Personel>();
                  }
              }
              
3.Startup.cs içerisinde 

                 public void ConfigureServices(IServiceCollection services)
                  {
                      services.AddControllersWithViews();
                      services.AddAutoMapper(typeof(PersonelProfil));   //DependencyInjection Kütüphanesini ekliyoruz. internette bulduk.
                  }

4. Controllerımız içerisinde  dönüştürme işlemlerini yapıyoruz 

                  [HttpPost]
                  public IActionResult Index(PersonelCreateVM personelCreateviewModel)
                  {
                      var personel = _mapper.Map<Personel>(personelCreateviewModel);      //Burada bize personel entitisi verir.
                      var personelCreateVM = _mapper.Map<PersonelCreateVM>(personel);     // Burada da PersonelCreateVM verir.
                  }
                  
                  


![4](https://user-images.githubusercontent.com/68101192/199297436-c08e4880-3e9e-4667-b7ec-87db45098073.png)




