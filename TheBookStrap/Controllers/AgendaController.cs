using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBookStrap.Repos;
using TheBookStrap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheBookStrap.Controllers
{
    public class AgendaController : Controller
    {
        INotebookRepository repo;
        UserManager<AppUser> userManager;


        public AgendaController(INotebookRepository r, UserManager<AppUser> u)
        {
            repo = r;
            userManager = u;
        }


        public async Task<IActionResult> Index()  //IActionResult Index()
        {
            List<AppUser> users = new List<AppUser>();
            foreach (AppUser user in userManager.Users)
            {
                user.Id = await userManager.GetUserIdAsync(user);//
                users.Add(user);
            }
            return View();
        }

        [Authorize]
        public IActionResult DayEntry()
        {
            /*
                if signed in userID == AgendaOwnerId
                   then show entries
                else
                    don't show entries
             */
            return View();
        }

        [HttpPost]
        public RedirectToActionResult DayEntry(Agenda m)
        {
            //m.AgendaOwner = userManager.GetUserAsync(User).Result;     //need to comment out before running test
            m.AgendaOwner.Name = m.AgendaOwner.UserName;
            m.AgendaDate = DateTime.Now;
            repo.AddSchedule(m);

            //return View(model);
            return RedirectToAction("Agenda");
        }

        [Authorize]
        public IActionResult Agenda(Agenda sched)
        {
            //get all posts in the db
            List<Agenda> entries = repo.Schedule.ToList();

            return View(entries);
        }

        [HttpPost]
        public IActionResult Agenda(string user)
        {
            List<Agenda> entries = null;

            if (user != null)
            {
                entries = (from r in repo.Schedule
                           where r.AgendaOwner.Name == user
                           select r).ToList();
            }

            return View(entries);
        }
  
    }
}
