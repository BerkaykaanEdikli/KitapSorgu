using KitapSorgu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace KitapSorgu.Controllers
{
    public class KitapController : Controller
    {
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                using (var db = new KutuphaneDbContext())
                {
                    db.Add(kitap);
                    db.SaveChanges();
                    return Content("Kitap Başarıyla Kaydedildi");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Listele()
        {
            using (var db = new KutuphaneDbContext())
            {
                var liste = db.Kitaplar.ToList();
                return View(liste);
            }
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            using (var db = new KutuphaneDbContext())
            {
                var kitap = db.Kitaplar.Find(id);
                return View(kitap);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Guncelle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                using (var db = new KutuphaneDbContext())
                {
                    db.Update(kitap);
                    db.SaveChanges();
                    return RedirectToAction("Listele");
                }
            }
            return View(kitap);
        }

        [HttpGet]
        public IActionResult Sil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (var db = new KutuphaneDbContext())
            {
                var kitap = db.Kitaplar.Find(id);
                if (kitap == null)
                {
                    return NotFound();
                }
                return View(kitap);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SilOnay(int id)
        {
            using (var db = new KutuphaneDbContext())
            {
                var kitap = db.Kitaplar.Find(id);
                db.Remove(kitap);
                db.SaveChanges();
                return RedirectToAction("Listele");
            }
        }
    }
}
