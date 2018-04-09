using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TweetCacheApi.Controllers
{
    [Route("api/[controller]")]
    public class TwusersController : Controller
    {
        private readonly Services.ITwitterService _service;

        public TwusersController(Services.ITwitterService svc)
        {
            _service = svc;
        }

        [HttpGet]
        public IEnumerable<Models.TwitterUser> GetUsers()
        {
            if (!_service.IsInitialized)
            {
                _service.Initialize();
            }

            return _service.GetUsers();
        }
    }
}