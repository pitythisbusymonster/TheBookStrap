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
            controller.Agenda(sched);

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
                AgendaOwner = new AppUser() { Name = "Me" },
                MorningText = "If you haven't read it, I highly recommend it!",
                AfternoonText = "If you haven't read it, I highly recommend it!",
                EveningText = "If you haven't read it, I highly recommend it!",
                NotesText = "If you haven't read it, I highly recommend it!",
            };

            // Act
            controller.Agenda(sched);

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
