using System;
using System.Linq;
using TheBookStrap.Controllers;
using TheBookStrap.Models;
using TheBookStrap.Repos;
using Xunit;

namespace Tests
{
    public class AgendaTests
    {
        [Fact]
        public void AddAgendaTest()
        {

            // Arrange
            var fakeRepo = new FakeNotebookRepository();
            var controller = new AgendaController(fakeRepo, null);
            var sched = new Agenda()
            {
                AgendaOwner = new AppUser() { Name = "Me" },
                MorningText = "This is a test",
                AfternoonText = "This is a test",
                EveningText = "This is a test",
                NotesText = "This is a test",
            };

            // Actf
            controller.DayEntry(sched);

            // Assert
            // Ensure that the post was added to the repository
            var retrievedPost = fakeRepo.Schedule.ToList()[0];
            Assert.Equal(0, System.DateTime.Now.Date.CompareTo(retrievedPost.AgendaDate.Date));
            Assert.Equal(sched.MorningText, retrievedPost.MorningText);
            Assert.Equal(sched.AfternoonText, retrievedPost.AfternoonText);
            Assert.Equal(sched.EveningText, retrievedPost.EveningText);
            Assert.Equal(sched.NotesText, retrievedPost.NotesText);
        }



        [Fact]
        public void GetAgendaTest()
        {

            // Arrange
            var fakeRepo = new FakeNotebookRepository();
            var controller = new AgendaController(fakeRepo, null);
            var sched = new Agenda()
            {
                AgendaOwner = new AppUser() { Name = "Amber Turner" },
                MorningText = "Hike Goodman with Kellum",
                AfternoonText = "late lunch, meet with Jacob",
                EveningText = "Dinner date with Fletcher",
                NotesText = "Don't forget to fold the laundry!",
            };

            // Act
            controller.DayEntry(sched);

            // Assert
            // Ensure that the post was added to the repository
            var retrievedPost = fakeRepo.Schedule.ToList()[0];
            Assert.Equal(sched.AgendaDate.Date, retrievedPost.AgendaDate.Date);
            Assert.Equal(sched.AgendaOwner, retrievedPost.AgendaOwner);
            Assert.Equal(sched.MorningText, retrievedPost.MorningText);
            Assert.Equal(sched.AfternoonText, retrievedPost.AfternoonText);
            Assert.Equal(sched.EveningText, retrievedPost.EveningText);
            Assert.Equal(sched.NotesText, retrievedPost.NotesText);
        }
    }
}
