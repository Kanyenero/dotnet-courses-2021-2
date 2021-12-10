using Microsoft.AspNetCore.Mvc;
using PersonsAndAwardsMVC.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace PersonsAndAwardsMVC.Controllers
{
    public class CommonController : Controller
    {
        private readonly IMySingletonService singletonService;

        public CommonController(IMySingletonService singletonService)
        {
            this.singletonService = singletonService;
        }

        public IActionResult RemoveConfirmationForm(string type, int id)
        {
            ViewData["type"] = type;
            ViewData["id"] = id;

            return View();
        }
        public IActionResult RemoveConfirmed(string type, int id)
        {
            if (type == "person")
            {
                singletonService.PersonBL.Remove(id);

                return RedirectToAction("Persons", "Persons");
            }
            if (type == "award")
            {
                foreach (var person in singletonService.PersonBL.GetList())
                {
                    singletonService.PersonBL.RemoveAward(person.ID, id);
                }
                singletonService.AwardBL.Remove(id);

                return RedirectToAction("Awards", "Awards");
            }

            return View(new ErrorViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
