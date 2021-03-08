using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBookStrap.Models;

namespace TheBookStrap.Repos
{
    public class FakeNotebookRepository : INotebookRepository
    {
        List<CommunityBoard> posts = new List<CommunityBoard>();
        List<Journal> entries = new List<Journal>();




        public IQueryable<CommunityBoard> Posts
        {
            get { return posts.AsQueryable<CommunityBoard>(); }
        }

        public void AddPost(CommunityBoard post)
        {
            post.PostID = posts.Count;
            posts.Add(post);
        }

        public void UpdatePost(CommunityBoard post)
        {
            //context.Posts.Update(post);
            //context.SaveChanges();
            throw new NotImplementedException();
        }




        public IQueryable<Journal> Entries
        {
            get { return entries.AsQueryable<Journal>(); }
        }

        public void AddEntry(Journal entry)
        {
            entry.JournalID = entries.Count;
            entries.Add(entry);
        }

        public void UpdateEntry(Journal entry)
        {
            //context.Posts.Update(post);
            //context.SaveChanges();
            throw new NotImplementedException();
        }


    }
}
