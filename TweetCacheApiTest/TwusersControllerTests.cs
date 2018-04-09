using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TweetCacheApi.Services;
using TweetCacheApi.Models;

namespace TweetCacheApiTest
{
    [TestClass]
    public class TwuserControllerTests
    {
        private Spackle.RandomObjectGenerator _rog = new Spackle.RandomObjectGenerator();

        [TestMethod]
        public void Should_BeCorrect_When_FetchingListOfTwitterUsers()
        {
            // Arrange...
            var fakeUserList = MakeFakeTwitterUserList();
            var mockTwitterService = new Mock<ITwitterService>(MockBehavior.Strict);
            mockTwitterService.Setup(_ => _.IsInitialized).Returns(false);
            mockTwitterService.Setup(_ => _.Initialize());
            mockTwitterService.Setup(_ => _.GetUsers()).Returns(fakeUserList);
            var controller = new TweetCacheApi.Controllers.TwusersController(mockTwitterService.Object);

            // Act...
            var users = controller.GetUsers();

            // Assert...
            mockTwitterService.VerifyAll();
        }

        private List<TwitterUser> MakeFakeTwitterUserList()
        {
            var list = new List<TwitterUser>();
            list.Add(new TwitterUser() { id = _rog.Generate<long>(), handle = $"@{_rog.Generate<string>().Substring(0, 5)}User" });
            return list;
        }
    }
}
