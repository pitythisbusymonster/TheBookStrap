using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TheBookStrap.Repos;
using TheBookStrap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TheBookStrap.Controllers
{
    public class JournalController : Controller
    {
        INotebookRepository repo;
        UserManager<AppUser> userManager;


        public JournalController(INotebookRepository r, UserManager<AppUser> u)
        {
            repo = r;
            userManager = u;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]                     
        public IActionResult Entry() 
        {
            /*
                if signed in userID == journalistID
                   then show entries
                else
                    don't show entries
             */
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Entry(Journal model) 
        {
            model.Journalist = userManager.GetUserAsync(User).Result;
            model.Journalist.Name = model.Journalist.UserName;
            model.EntryDate = DateTime.Now;
            repo.AddEntry(model);

            //return View(model);
            return RedirectToAction("Journal");
        }

        [Authorize]
        public IActionResult Journal() 
        {
            //get all posts in the db
            List<Journal> entries = repo.Entries.ToList();  

            return View(entries);
        }

        [HttpPost]
        public IActionResult Journal(string journalist) 
        {
            List<Journal> entries = null;

            if (journalist != null)
            {
                entries = (from r in repo.Entries
                         where r.Journalist.Name == journalist
                         select r).ToList();
            }

            return View(entries);
        }
    }
}
