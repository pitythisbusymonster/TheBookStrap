using System.Linq;
using TheBookStrap.Models;

namespace TheBookStrap.Repos
{
    public interface INotebookRepository
    {
        IQueryable<CommunityBoard> Posts { get; }    // Read (or retrieve) posts
        void AddPost(CommunityBoard posts);          // Create a post
        void UpdatePost(CommunityBoard posts);



        IQueryable<Journal> Entries { get; }    
        void AddEntry(Journal entries);         
        void UpdateEntry(Journal entries);

        //void MakeEntryPublic(Journal entries);



        IQueryable<Agenda> Schedule { get; }    
        void AddSchedule(Agenda entries);          
        void UpdateSchedule(Agenda entries);


    }
}
