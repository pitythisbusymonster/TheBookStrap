using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBookStrap.Repos;
using TheBookStrap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TheBookStrap.Controllers
{
    //[Authorize(Policy = "JournalistOnly")]
    public class JournalController : Controller
    {
        INotebookRepository repo;
        UserManager<AppUser> userManager;


        public JournalController(INotebookRepository r, UserManager<AppUser> u)
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

            //this is an initilization list
            //AdminVM model = new AdminVM
            //{
                //Users = users,              //list of AppUsers
                //Roles = roleManager.Roles
            //};
            //return View(model);
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

            if (model.EntryStatus == true)
            {
                //repo.MakeEntryPublic(model);
            }

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
