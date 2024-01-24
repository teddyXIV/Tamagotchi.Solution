using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
    public class PetsController : Controller
    {
        [HttpGet("/pets")]
        public ActionResult Index()
        {
            List<Pet> allPets = Pet.GetAll();
            return View(allPets);
        }

        [HttpGet("pets/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/pets")]
        public ActionResult Create(string name)
        {
            _ = new Pet(name, 10, 50, 10);
            return RedirectToAction("Index");
        }
        [HttpGet("/pets/{id}")]
        public ActionResult Show(int id)
        {
            Pet found = Pet.GetPetById(id);
            found.GetNeglect();
            found.LastChecked = DateTime.Now;
            return View(found);
        }

        [HttpPost("pets/{id}/play")]
        public ActionResult Update(int id)
        {
            Pet found = Pet.GetPetById(id);
            found.Play(2);
            return RedirectToAction("Index");
        }

        [HttpPost("pets/{id}/sleep")]
        public ActionResult Sleep(int id)
        {
            Pet found = Pet.GetPetById(id);
            found.Sleep(2);
            return RedirectToAction("Index");
        }

        [HttpPost("pets/{id}/feed")]
        public ActionResult Feed(int id)
        {
            Pet found = Pet.GetPetById(id);
            found.Feed();
            return RedirectToAction("Index");
        }

        [HttpPost("pets/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Pet.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet("pets/{id}/funeral-procession")]
        public ActionResult FuneralProcession(int id)
        {
            Pet found = Pet.GetPetById(id);
            if (found.Alive)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(found);
            }
        }

        [HttpPost("pets/{id}/kill")]
        public ActionResult Kill(int id)
        {
            Pet found = Pet.GetPetById(id);
            found.Hunger += 100;
            return RedirectToAction("Index");
        }
    }
}