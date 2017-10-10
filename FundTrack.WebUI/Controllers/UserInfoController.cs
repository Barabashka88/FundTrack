﻿using Microsoft.AspNetCore.Mvc;
using FundTrack.Infrastructure.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FundTrack.WebUI.Controllers
{
    //Controller that will handle getuserinfo request. Probably it will be replaced with one, that uses authentication
    [Route("api/[controller]")]
    public class UserInfoController : Controller
    {
        // GET: api/values
        [HttpGet]      
        //Returns dummy userInfo view model
        public JsonResult Get()
        {
            var userInfo = new UserInfoViewModel()
            {
                Id = 5,
                Login = "smokingpenguin",
                FirstName = "John",
                LastName = "Smith",
                Email = "agentsmith@matrix.com",
                Address = "Lviv, Pasternaka st. 5",
                PhotoUrl = "https://vignette1.wikia.nocookie.net/matrix/images/4/4d/Agent-smith-the-matrix-movie-hd-wallpaper-2880x1800-4710.png/revision/latest/scale-to-width-down/250?cb=20140504013834"
            };

            return Json(userInfo);
        }
    }
}
