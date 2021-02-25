using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models.Activity;
using TaskManager.Services;

namespace TaskManager.WebAPI.Controllers
{
    public class ActivityController : ApiController
    {
        private ActivityService CreateActivityServices()
        {
          //  var userId = Guid.Parse(User.Identity.GetUserId());
            var userId = int.Parse(User.Identity.GetUserId());
            var activityService = new ActivityService(userId);
            return activityService;
        }

        public  IHttpActionResult Get()
        {
            ActivityService activitySerivce = CreateActivityServices();
            var activities = activitySerivce.GetActivitiesByUser();
            return Ok(activities);
        }

        public IHttpActionResult Put(ActivityEdit activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityServices();

            if (!service.UpdateActivity(activity))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateActivityServices();

            if (!service.DeleteActivity(id))
                return InternalServerError();

            return Ok();
        }
    }
}
