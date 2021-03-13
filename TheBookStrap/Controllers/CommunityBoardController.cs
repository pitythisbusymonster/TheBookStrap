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
    public class CommunityBoardController : Controller
    {

        INotebookRepository repo;
        UserManager<AppUser> userManager;

        
        public CommunityBoardController(INotebookRepository r, UserManager<AppUser> u)
        {
            repo = r;
            userManager = u;
        }


        public IActionResult Index()
        {
            return View();
        }

        //create a post
        [Authorize]
        public IActionResult CommunityBoard()
        {
            return View();
        }

        //no aothorize, visitors can view posts, just not create or reply
        [HttpPost]
        public RedirectToActionResult CommunityBoard(CommunityBoard model)    
        {
            if (ModelState.IsValid)
            {
                model.PostCreator = userManager.GetUserAsync(User).Result;
                model.PostCreator.Name = model.PostCreator.UserName;
                model.PostDate = DateTime.Now;
                repo.AddPost(model);
            }
            else
            {
                return RedirectToAction("CommunityBoard");
            }
            return RedirectToAction("BoardPost");
        }

        //view posts
        public IActionResult BoardPost()
        {
            //get all posts in the db
            List<CommunityBoard> posts = repo.Posts.ToList<CommunityBoard>();

            return View(posts);
        }

        [HttpPost]
        public IActionResult BoardPost(string postTitle, string postCreator)
        {
            List<CommunityBoard> posts = null;

            if (postTitle != null)
            {
                posts = (from r in repo.Posts
                           where r.PostTitle == postTitle
                           select r).ToList();
            }
            else if (postCreator != null)
            {
                posts = (from r in repo.Posts
                           where r.PostCreator.Name == postCreator
                           select r).ToList();
            }

            return View(posts);
        }

        //open form for entering reply
        [Authorize] 
        public IActionResult Reply(int postId)
        {
            var replyVM = new ReplyVM { PostID = postId };
            return View(replyVM);
        }


        [HttpPost]
        public RedirectToActionResult Reply(ReplyVM replyVM)  
        {
            //Reply is the domain model
            var reply = new Reply { ReplyText = replyVM.ReplyText };            
            reply.Replier = userManager.GetUserAsync(User).Result;
            reply.ReplyDate = DateTime.Now;

            //retrieve the post replying to
            var post = (from r in repo.Posts
                        where r.PostID == replyVM.PostID
                        select r).First<CommunityBoard>();

            //store the reply with the post in the db
            post.Replies.Add(reply);
            repo.UpdatePost(post);

            //return View(reply);
            return RedirectToAction("BoardPost");
        }

       

    }
}
