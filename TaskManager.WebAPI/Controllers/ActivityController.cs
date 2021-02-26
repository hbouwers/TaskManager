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
        //private readonly ActivityService _service = new ActivityService();

        public IHttpActionResult Post(ActivityCreate activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateActivityServices();
            if (!service.CreateActivity(activity))
                return InternalServerError();
            return Ok();
        }


        private ActivityService CreateActivityServices()
        {
            var userid =(User.Identity.GetUserId());
            //var userid = int.parse(User.Identity.GetUserId());
           
            var activityService = new ActivityService(userid);
            return activityService;
        }

        public IHttpActionResult Get(int id)
        {
            ActivityService activitySerivce = CreateActivityServices();
            var activities = activitySerivce.GetActivityById(id);
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
