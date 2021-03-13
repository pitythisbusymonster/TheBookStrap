using System;
using System.Linq;
using TheBookStrap.Controllers;
using TheBookStrap.Models;
using TheBookStrap.Repos;
using Xunit;

namespace Tests
{
    public class BoardTests
    {
        [Fact]
        public void AddCommunityBoardTest()
        {

            // Arrange
            var fakeRepo = new FakeNotebookRepository();
            var controller = new CommunityBoardController(fakeRepo, null);
            var post = new CommunityBoard()
            {
                PostTitle = "Test1 Adding",
                PostCreator = new AppUser() { Name = "Me" },
                PostText = "This is a test"
            };

            // Act
            controller.CommunityBoard(post);

            // Assert
            // Ensure that the post was added to the repository
            var retrievedPost = fakeRepo.Posts.ToList()[0];
            Assert.Equal(0, System.DateTime.Now.Date.CompareTo(retrievedPost.PostDate.Date));
            Assert.Equal(post.PostTitle, retrievedPost.PostTitle);   //          
        }



        [Fact]
        public void GetCommunityBoardTest()
        {

            // Arrange
            var fakeRepo = new FakeNotebookRepository();
            var controller = new CommunityBoardController(fakeRepo, null);
            var post = new CommunityBoard()
            {
                PostTitle = "The Willows",
                PostCreator = new AppUser() { Name = "Me" },
                PostText = "If you haven't read it, I highly recommend it!"
            };

            // Act
            controller.CommunityBoard(post);

            // Assert
            // Ensure that the post was added to the repository
            var retrievedPost = fakeRepo.Posts.ToList()[0];
            Assert.Equal(post.PostDate.Date, retrievedPost.PostDate.Date);
            Assert.Equal(post.PostTitle, retrievedPost.PostTitle);
            Assert.Equal(post.PostCreator, retrievedPost.PostCreator);
            Assert.Equal(post.PostText, retrievedPost.PostText);
        }


    }
}
