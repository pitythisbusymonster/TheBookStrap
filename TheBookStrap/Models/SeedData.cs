using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TheBookStrap.Models
{
    public class SeedData
    {



        public static void Seed(NotebooksContext context, UserManager<AppUser> userManager,
                            RoleManager<IdentityRole> roleManager)
        {
            if (!context.Posts.Any())
            {
                var result = roleManager.CreateAsync(new IdentityRole("Member")).Result;
                result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;

                //seeding default admin. they will need to change password after logging in
                AppUser siteadmin = new AppUser
                {
                    UserName = "SiteAdmin",
                    Name = "Site Admin"
                };
                userManager.CreateAsync(siteadmin, "Password-01").Wait();
                IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
                userManager.AddToRoleAsync(siteadmin, adminRole.Name);



                //seed community board

                AppUser sillySally = new AppUser
                {
                    UserName = "SillySally",
                    Name = "Sally Echolls"
                };
                context.Users.Add(sillySally);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                CommunityBoard post = new CommunityBoard
                {
                    PostCreator = sillySally,
                    PostTitle = "Habit or Hobby",
                    PostText = "What is the difference between a habit and a hobby?",
                    PostDate = DateTime.Parse("11/1/2020")
                };

                context.Posts.Add(post);




                AppUser kitchenGod = new AppUser
                {
                    UserName = "KitchenGod",
                    Name = "Seth Farr"
                };
                context.Users.Add(kitchenGod);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                post = new CommunityBoard
                {
                    PostCreator = kitchenGod,
                    PostTitle = "Dedication",
                    PostText = "Are you a casual journalist, or do you visit every day?",
                    PostDate = DateTime.Parse("11/15/2020")
                };

                context.Posts.Add(post);


                context.SaveChanges();
            }




            //seed journal entry
            if (!context.Entries.Any())
            {

                AppUser mySelf = new AppUser
                {
                    UserName = "ignoreMePlease",
                    Name = "Amber Turner"
                };
                context.Users.Add(mySelf);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                Journal post = new Journal
                {
                    Journalist = mySelf,
                    EntryText = "Lorem ipsum dolor sit amet, " +
                    "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore " +
                    "magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi " +
                    "ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                    "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non " +
                    "proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    EntryDate = DateTime.Parse("11/1/2020"),
                    EntryStatus = false
                };

                context.Entries.Add(post);


                context.SaveChanges();
            }



        }
    }
}
