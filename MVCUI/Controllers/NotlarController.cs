using BusinessLayer;
using DataAccessLayer;
using EntityLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCUI.Models;
using System.Diagnostics;

namespace MVCUI.Controllers
{
    public class NotlarController : Controller
    {
        private NotService notService;
        private OgrenciContext context;

        public NotlarController(NotService notService, OgrenciContext context)
        {
            this.notService = notService;
            this.context = context;
        }




        [HttpGet]
        public IActionResult Index()
        {
            var notlar = notService.NotlariGetir();

            var dersler = context.TBLDERS.Select(d => new SelectListItem
            {
                Text = d.DERSAD,
                Value = d.DERSID.ToString()
            }).ToList();

            ViewBag.Dersler = dersler;

            var model = new NotlarViewModel
            {
                Notlar = notlar,
                Dersler = dersler
            };

            
            return View(model);
        }

        [HttpPost]
        public IActionResult NotEkle(NotEkleViewModel model)
        {

            if(ModelState.IsValid)
            {
                // veri girişi olmamış demektir biz yine dersler dropdownunu doldurup aynı sayfaya dönüyoruz
                var viewModel = new NotlarViewModel
                {
                    Dersler = context.TBLDERS.Select(d => new SelectListItem
                    {
                        Text = d.DERSAD,
                        Value = d.DERSID.ToString()
                    }).ToList(),
                    EkleModel = model,
                    Notlar = notService.NotlariGetir()
                };

                
                return View("Index", viewModel);
            }







            if (Request.Form["islem"] == "guncelle")
            {
                Debug.WriteLine("NotId: " + Request.Form["NotId"]);
                Debug.WriteLine("OgrId: " + Request.Form["OgrId"]);

                if (int.TryParse(Request.Form["NotId"], out int notId) &&
                    int.TryParse(Request.Form["OgrId"], out int ogrId))
                {
                    var uptNot = context.TBLNOTLAR.FirstOrDefault(n => n.NotId == notId && n.Ogr == ogrId);

                    

                    if (uptNot != null)
                    {
                        uptNot.Sinav1 = model.Sinav1;
                        uptNot.Sinav2 = model.Sinav2;

                        var vize = uptNot.Sinav1;
                        var final = uptNot.Sinav2;
                        decimal ortalamaYeni = Convert.ToDecimal(vize * 0.4 + final * 0.6);
                        bool durumYeni = ortalamaYeni >= 60;

                        uptNot.Ders = model.DersId;
                        uptNot.Ortalama = ortalamaYeni;
                        uptNot.Durum = durumYeni;
                        context.SaveChanges();
                    }

                    var uptOgr = context.TBLOGRENCI.FirstOrDefault(o => o.ID == ogrId);

                    if (uptOgr != null)
                    {
                        uptOgr.Ad = model.Ad;
                        uptOgr.Soyad = model.Soyad;
                        uptOgr.OkulNo = model.OkulNo;

                        context.SaveChanges();
                    }
                    Console.WriteLine(ogrId + " " + notId);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Mesaj"] = "Güncellemek için önce bir satır seçmelisiniz.";
                    
                    return RedirectToAction("Index");
                }

                


            }





            var ogrenci = new TBLOGRENCI
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                OkulNo = model.OkulNo
            };
            context.TBLOGRENCI.Add(ogrenci);
            context.SaveChanges();

            decimal ortalama = Convert.ToDecimal(model.Sinav1 * 0.4 + model.Sinav2 * 0.6);
            bool durum = ortalama >= 60;

            var not = new TBLNOTLAR
            {
                Ders = model.DersId,
                Ogr = ogrenci.ID,
                Sinav1 = model.Sinav1,
                Sinav2 = model.Sinav2,
                Ortalama = ortalama,
                Durum = durum
            };

            context.TBLNOTLAR.Add(not);
            context.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult NotKayitSil(int NotId, int OgrId)
        {
            var not = context.TBLNOTLAR.FirstOrDefault(n => n.NotId == NotId && n.Ogr == OgrId);
            if (not != null)
            {
                context.TBLNOTLAR.Remove(not);
                context.SaveChanges();
            }
            else
            {
                TempData["Mesaj"] = "Lütfen silmek için bir kayıt seçiniz.";
            }
            return RedirectToAction("Index");
        }


    }
}
