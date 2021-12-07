using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonsAndAwardsMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using Entities;

namespace PersonsAndAwardsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMySingletonService singletonService;

        public HomeController(ILogger<HomeController> logger, IMySingletonService singletonService)
        {
            _logger = logger;
            this.singletonService = singletonService;
        }

        public IActionResult Persons()
        {
            List<PersonViewModel> personsModels = new List<PersonViewModel>();
            foreach (Person item in singletonService.PersonBL.GetList())
            {
                personsModels.Add(PersonViewModel.GetViewModel(item));
            }

            return View(personsModels);
        }
        public IActionResult PersonForm(string task, int id)
        {
            ViewData["AllAvailableAwards"] = singletonService.AwardBL.GetList();
            ViewData["task"] = task;

            if (task == "add")
            {
                return View(new PersonViewModel());
            }
            if (task == "edit")
            {
                return View(PersonViewModel.GetViewModel(singletonService.PersonBL.GetListItem(id)));
            }

            return View(new ErrorViewModel());
        }
        [HttpPost]
        public IActionResult PersonForm(PersonViewModel model, string task, List<int> choosedAwards)
        {
            Person person = model.ToPerson();

            if (task == "add")
            {
                int personID = singletonService.PersonBL.Add(person);
                foreach (int awardID in choosedAwards)
                {
                    singletonService.PersonBL.AddAward(
                        personID,
                        singletonService.AwardBL.GetListItem(awardID));
                }

            }
            if (task == "edit")
            {
                singletonService.PersonBL.SetData(person.ID, person.GetData());
                singletonService.PersonBL.ResetAwards(person.ID);
                foreach (int awardID in choosedAwards)
                {
                    singletonService.PersonBL.AddAward(
                        person.ID,
                        singletonService.AwardBL.GetListItem(awardID));
                }
            }

            return RedirectToAction("Persons");
        }


        public IActionResult Awards()
        {
            List<AwardViewModel> awardsModels = new List<AwardViewModel>();
            foreach (Award item in singletonService.AwardBL.GetList())
            {
                awardsModels.Add(AwardViewModel.GetViewModel(item));
            }

            return View(awardsModels);
        }
        public IActionResult AwardForm(string task, int id)
        {
            ViewData["task"] = task;

            if (task == "add")
            {
                return View(new AwardViewModel());
            }
            if (task == "edit")
            {
                return View(AwardViewModel.GetViewModel(singletonService.AwardBL.GetListItem(id)));
            }

            return View(new ErrorViewModel());
        }

        [HttpPost]
        public IActionResult AwardForm(AwardViewModel model, string task)
        {
            Award award = model.ToAward();

            if (task == "add")
            {
                singletonService.AwardBL.Add(award);
            }
            if (task == "edit")
            {
                singletonService.AwardBL.SetData(award.ID, award.GetData());
            }

            return RedirectToAction("Awards");
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

                return RedirectToAction("Persons");
            }
            if (type == "award")
            {
                foreach (var person in singletonService.PersonBL.GetList())
                {
                    singletonService.PersonBL.RemoveAward(person.ID, id);
                }
                singletonService.AwardBL.Remove(id);

                return RedirectToAction("Awards");
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
