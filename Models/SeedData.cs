using FitKitApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitKitApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FitKitAppContext(serviceProvider.GetRequiredService<DbContextOptions<FitKitAppContext>>()))
            {

                if(context.Coach.Any() || context.User.Any() || context.Objekt.Any())
                {
                    return;
                }
               
                context.Objekt.AddRange(
                    new Objekt {/* Id = 1,*/ Ime = "Лајфстајл-Студио", Kvadratura = 300, Lokacija = "Карпош 3", MaxClients = 50, TipVezbanje = "Боди-билдинг", OtvorZatvor = "Затворено", Coach1Id = context.Coach.Single(d => d.Ime == "Бојан" && d.Prezime == "Илиевски").Id, Coach2Id = context.Coach.Single(d => d.Ime == "Игор" && d.Prezime == "Темелковски").Id },
                    new Objekt {/*Id=1, */Ime = "Кинетикс", Kvadratura = 120, Lokacija = "Дебар-Маало", MaxClients = 20, TipVezbanje = "Кардио/Функционален", OtvorZatvor = "Отворено", Coach1Id = context.Coach.Single(d => d.Ime == "Марко" && d.Prezime == "Мицевски").Id, Coach2Id = context.Coach.Single(d => d.Ime == "Дарко" && d.Prezime == "Порјазов").Id },
                    new Objekt {/*Id=1, */Ime = "Кросфит-Скопје", Kvadratura = 95, Lokacija = "Водно", MaxClients = 45, TipVezbanje = "Кросфит", OtvorZatvor = "Затворено", Coach1Id = context.Coach.Single(d => d.Ime == "Бојан" && d.Prezime == "Илиевски").Id, Coach2Id = context.Coach.Single(d => d.Ime == "Игор" && d.Prezime == "Темелковски").Id }
                   );
                context.SaveChanges();

                context.Coach.AddRange(
                    
                    new Coach {/*Id=1,*/Ime="Игор",Prezime="Темелковски",Visina=192,Tezina=95,BirthDate=DateTime.Parse("1983-2-15"),Plata=450,EducationLevel="IFBB academy" },
                    new Coach {/*Id=2,*/Ime = "Стефан", Prezime = "Саздовски", Visina = 183, Tezina = 86, BirthDate = DateTime.Parse("1992-5-12"), Plata = 600, EducationLevel = "Вишо образование" },
                    new Coach {/*Id=3,*/Ime = "Горан", Prezime = "Попов", Visina = 180, Tezina = 83, BirthDate = DateTime.Parse("1996-3-11"), Plata = 560, EducationLevel = "Вишо образование" },
                    new Coach {/*Id=4,*/Ime = "Бојан", Prezime = "Илиевски", Visina = 187, Tezina = 91, BirthDate = DateTime.Parse("1988-2-9"), Plata = 1200, EducationLevel = "Средно образование" },
                    new Coach {/*Id=5,*/Ime = "Марко", Prezime = "Мицевски", Visina = 190, Tezina = 85, BirthDate = DateTime.Parse("1997-7-6"), Plata = 400, EducationLevel = "IFBB academy" },
                    new Coach {/*Id=6,*/Ime = "Дарко", Prezime = "Порјазов", Visina = 178, Tezina = 86, BirthDate = DateTime.Parse("1993-5-4"), Plata = 600, EducationLevel = "Средно образование" }
                    );

                context.SaveChanges();


                context.User.AddRange(
                    new User {  /*Id = 1, */Ime = "Роб", Prezime = "Рејнер", BirthDate=DateTime.Parse("1999-4-3"),Visina=193,Tezina=105},
                    new User {  /*Id = 1, */Ime = "Мартин", Prezime = "Тасев", BirthDate = DateTime.Parse("1998-3-4"), Visina = 173, Tezina = 67, ObemGradi = 154, ObemLevBiceps = 31, ObemDesenBiceps = 31, ObemStruk=140,ObemDesenBut = 53, ObemLevBut = 52},
                    new User {  /*Id = 1, */Ime = "Кристијан", Prezime = "Христов", BirthDate = DateTime.Parse("1993-7-9"), Visina = 190, Tezina = 96, ObemGradi = 154, ObemLevBiceps = 31, ObemDesenBiceps = 31, ObemDesenBut = 53, ObemLevBut = 52, ObemStruk = 134 },
                    new User {  /*Id = 1, */Ime = "Андреј", Prezime = "Попов", BirthDate = DateTime.Parse("1999-3-14"), Visina = 180, Tezina = 87, ObemGradi = 154, ObemLevBiceps = 31, ObemDesenBiceps = 31, ObemDesenBut = 53, ObemLevBut = 52, ObemStruk = 134 },
                    new User {  /*Id = 1, */Ime = "Majk", Prezime = "Стивенсон", BirthDate = DateTime.Parse("1999-4-3"), Visina = 193, Tezina = 105, ObemGradi = 154, ObemLevBiceps = 31, ObemDesenBiceps = 31, ObemDesenBut = 53, ObemLevBut = 52, ObemStruk = 134 },
                    new User {  /*Id = 1, */Ime = "Митко", Prezime = "Мираковски", BirthDate = DateTime.Parse("1999-3-10"), Visina = 176, Tezina = 63, ObemGradi = 154, ObemLevBiceps = 31, ObemDesenBiceps = 31, ObemDesenBut = 53, ObemLevBut = 52, ObemStruk = 134 },
                    new User {  /*Id = 1, */Ime = "Гораст", Prezime = "Цветковски", BirthDate = DateTime.Parse("1993-5-2"), Visina = 193, Tezina = 105, ObemGradi = 154, ObemLevBiceps = 31, ObemDesenBiceps = 31, ObemDesenBut = 53, ObemLevBut = 52, ObemStruk = 134 }
                    );
                context.SaveChanges();

                context.Zaclenuvanje.AddRange(
                  new Zaclenuvanje { ObjektId = 1, UserId = 1 },
                  new Zaclenuvanje { ObjektId = 2, UserId = 4 },
                  new Zaclenuvanje { ObjektId = 3, UserId = 1 },
                  new Zaclenuvanje { ObjektId = 4, UserId = 6 },
                  new Zaclenuvanje { ObjektId = 4, UserId = 2 },
                  new Zaclenuvanje { ObjektId = 4, UserId = 7 },
                  new Zaclenuvanje { ObjektId = 4, UserId = 3 }
              );
                context.SaveChanges();

            }
        }
    }
}
