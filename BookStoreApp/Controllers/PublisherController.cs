using BookStoreApp.Models.Domain;
using BookStoreApp.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService service;

        public PublisherController(IPublisherService service)
        {
            this.service = service;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = service.Add(model);

            if (result)
            {
                TempData["msg"] = "Added successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "An error has occured on server side";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = service.Update(model);

            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "An error has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return View(data);
        }
    }
}
