using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetCacheApi.Models;

namespace TweetCacheApi.Services
{
    internal class TwitterServiceMock : ITwitterService
    {
        private bool _isInitialized = false;

        public bool IsInitialized
        {
            get { return _isInitialized; }
        }

        public List<TwitterUser> GetUsers()
        {
            var list = new List<TwitterUser>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(MakeFakeTwitterUserList(i));
            }

            return list;
        }

        public void Initialize()
        {
            _isInitialized = true;
        }


        private TwitterUser MakeFakeTwitterUserList(long id)
        {
            return new TwitterUser() { id = id, handle = $"@Xyz{id.ToString()}User" };
        }

    }
}
