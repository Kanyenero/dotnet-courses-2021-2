using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using PersonsAndAwardsMVC.Models;
using Entities;

namespace PersonsAndAwardsMVC.Controllers
{
    public class AwardsController : Controller
    {
        private readonly IMySingletonService singletonService;

        public AwardsController(IMySingletonService singletonService)
        {
            this.singletonService = singletonService;
        }

        public IActionResult Awards()
        {
            return View(singletonService.AwardBL.GetList());
        }
        public IActionResult AddAwardForm()
        {
            return View(new Award());
        }
        [HttpPost]
        public IActionResult AddAwardForm(Award model)
        {
            if (!ModelState.IsValid) { return View(); }

            singletonService.AwardBL.Add(model);
            return RedirectToAction("Awards");
        }
        public IActionResult EditAwardForm(int id)
        {
            return View(singletonService.AwardBL.GetListItem(id));
        }
        [HttpPost]
        public IActionResult EditAwardForm(Award model)
        {
            if (!ModelState.IsValid) { return View(); }

            singletonService.AwardBL.SetData(model.ID, model.GetData());
            return RedirectToAction("Awards");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
