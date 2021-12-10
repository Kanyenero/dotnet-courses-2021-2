using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using PersonsAndAwardsMVC.Models;
using Entities;

namespace PersonsAndAwardsMVC.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IMySingletonService singletonService;

        public PersonsController(IMySingletonService singletonService)
        {
            this.singletonService = singletonService;
        }

        public IActionResult Persons()
        {
            return View(singletonService.PersonBL.GetList());
        }
        public IActionResult AddPersonForm()
        {
            return View(new PersonAndAwardsViewModel(
                singletonService.AwardBL.GetList()));
        }
        [HttpPost]
        public IActionResult AddPersonForm(PersonAndAwardsViewModel model, List<int> choosedAwards)
        {
            if (!ModelState.IsValid) { return View(new PersonAndAwardsViewModel(model.person, singletonService.AwardBL.GetList())); }

            int personID = singletonService.PersonBL.Add(model.person);
            foreach (int awardID in choosedAwards)
            {
                singletonService.PersonBL.AddAward(
                    personID,
                    singletonService.AwardBL.GetListItem(awardID));
            }

            return RedirectToAction("Persons");
        }
        public IActionResult EditPersonForm(int id)
        {
            return View(new PersonAndAwardsViewModel(
                singletonService.PersonBL.GetListItem(id),
                singletonService.AwardBL.GetList()));
        }
        [HttpPost]
        public IActionResult EditPersonForm(PersonAndAwardsViewModel model, List<int> choosedAwards)
        {
            if (!ModelState.IsValid) { return View(new PersonAndAwardsViewModel(model.person, singletonService.AwardBL.GetList())); }

            singletonService.PersonBL.SetData(model.person.ID, model.person.GetData());
            singletonService.PersonBL.ResetAwards(model.person.ID);
            foreach (int awardID in choosedAwards)
            {
                singletonService.PersonBL.AddAward(
                    model.person.ID,
                    singletonService.AwardBL.GetListItem(awardID));
            }

            return RedirectToAction("Persons");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
