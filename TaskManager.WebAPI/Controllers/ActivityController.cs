using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Services;

namespace TaskManager.WebAPI.Controllers
{
    public class ActivityController : ApiController
    {

        private ActivityService CreateActivityServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var activityService = new ActivityService(userId);
            return activityService;

        }


















    }
}
