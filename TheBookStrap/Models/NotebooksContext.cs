using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheBookStrap.Models
{
    public class NotebooksContext : IdentityDbContext 
    {
        public NotebooksContext(
            DbContextOptions<NotebooksContext> options) : base(options) { }
        public DbSet<CommunityBoard> Posts { get; set; } //represent tables, in the db

        public DbSet<Reply> Replies { get; set; }

        //Journal
        public DbSet<Journal> Entries { get; set; }

        //Agenda
        public DbSet<Agenda> Schedule { get; set; }
    }
}
