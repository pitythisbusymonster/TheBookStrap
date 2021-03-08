
using System.Linq;
using TheBookStrap.Models;

namespace TheBookStrap.Repos
{
    public interface INotebookRepository
    {
        IQueryable<CommunityBoard> Posts { get; }    // Read (or retrieve) posts
        void AddPost(CommunityBoard posts);          // Create a post
        void UpdatePost(CommunityBoard posts);



        IQueryable<Journal> Entries { get; }    // Read (or retrieve) posts
        void AddEntry(Journal entries);          // Create a post
        void UpdateEntry(Journal entries);
    }
}
