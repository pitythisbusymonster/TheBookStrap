using System;
using System.Linq;
using TheBookStrap.Controllers;
using TheBookStrap.Models;
using TheBookStrap.Repos;
using Xunit;

namespace Tests
{
    public class JournalTests
    {
        [Fact]
        public void AddJournalTest()
        {

            // Arrange
            var fakeRepo = new FakeNotebookRepository();
            var controller = new JournalController(fakeRepo, null);
            var entry = new Journal()
            {
                Journalist = new AppUser() { Name = "Me" },
                EntryText = "This is a test",
                EntryStatus = false

            };

            // Actf
            controller.Entry(entry);

            // Assert
            // Ensure that the post was added to the repository
            var retrievedPost = fakeRepo.Entries.ToList()[0];
            Assert.Equal(0, System.DateTime.Now.Date.CompareTo(retrievedPost.EntryDate.Date));
            Assert.Equal(entry.Journalist, retrievedPost.Journalist);
            Assert.Equal(entry.EntryText, retrievedPost.EntryText);
            Assert.Equal(entry.EntryStatus, retrievedPost.EntryStatus);
            
        }



        [Fact]
        public void GetJournalTest()
        {

            // Arrange
            var fakeRepo = new FakeNotebookRepository();
            var controller = new JournalController(fakeRepo, null);
            var entry = new Journal()
            {
                Journalist = new AppUser() { Name = "Amber Turner" },
                EntryText = "Lorem ipsum dolor sit amet, " +
                    "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore " +
                    "magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi " +
                    "ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                    "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non " +
                    "proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                EntryStatus = false
            };

            // Act
            controller.Entry(entry);

            // Assert
            // Ensure that the post was added to the repository
            var retrievedPost = fakeRepo.Entries.ToList()[0];
            Assert.Equal(entry.EntryDate.Date, retrievedPost.EntryDate.Date);
            Assert.Equal(entry.Journalist, retrievedPost.Journalist);
            Assert.Equal(entry.EntryText, retrievedPost.EntryText);
            Assert.Equal(entry.EntryStatus, retrievedPost.EntryStatus);
        }
    }
}
