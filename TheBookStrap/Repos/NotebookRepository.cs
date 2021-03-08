
using System.Linq;
using TheBookStrap.Models;
using Microsoft.EntityFrameworkCore;

namespace TheBookStrap.Repos
{
    public class NotebookRepository : INotebookRepository
    {
        private NotebooksContext context;

        //constructor
        public NotebookRepository(NotebooksContext c)
        {
            context = c;
        }



        public IQueryable<CommunityBoard> Posts
        {
            get
            {
                return context.Posts.Include(post => post.PostCreator)
                                    .Include(post => post.Replies)
                                    .ThenInclude(reply => reply.Replier);
            }
        }
        public void AddPost(CommunityBoard post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public void UpdatePost(CommunityBoard post)
        {
            context.Posts.Update(post);
            context.SaveChanges();
        }




        public IQueryable<Journal> Entries
        {
            get
            {
                return context.Entries.Include(entry => entry.Journalist);
            }
        }
        public void AddEntry(Journal entry)
        {
            context.Entries.Add(entry);
            context.SaveChanges();
        }

        public void UpdateEntry(Journal entry)
        {
            context.Entries.Update(entry);
            context.SaveChanges();
        }


    }
}
