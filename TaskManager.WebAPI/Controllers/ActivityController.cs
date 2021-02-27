using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models.Activity;
using TaskManager.Models.Category;
using TaskManager.Services;

namespace TaskManager.WebAPI.Controllers
{
    public class ActivityController : ApiController
    {
        // private readonly ActivityService _service = new ActivityService();

       
        public IHttpActionResult Post(ActivityCreate activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ActivityService();

            if (!service.CreateActivity(activity))
                return InternalServerError();

            return Ok();
        }
       
        public IHttpActionResult Get()
            {
                var activityService = new ActivityService();
                var activity = activityService.GetActivities();
                return Ok(activity);
            }
        public IHttpActionResult Get(int id)
        {
            var activityService = new ActivityService();
            var activity = activityService.GetActivityById(id);
            return Ok(activity);
        }

        public IHttpActionResult Put(ActivityEdit activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ActivityService();

            if (!service.UpdateActivity(activity))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = new ActivityService();

            if (!service.DeleteActivity(id))
                return InternalServerError();

            return Ok();
        }
    }
}
