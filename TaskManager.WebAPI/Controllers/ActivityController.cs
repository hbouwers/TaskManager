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
    [Authorize]
    public class ActivityController : ApiController
    {    
        /// <summary>
        /// Create an Activity
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public IHttpActionResult Post(ActivityCreate activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.CreateActivity(activity))
                return InternalServerError();

            return Ok();
        }
       
        /// <summary>
        /// Get all Activities
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
            {
                ActivityService activityService = CreateActivityService();
                var activity = activityService.GetActivities();
                return Ok(activity);
            }
        /// <summary>
        /// Get Activities by CategoryId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [Route("api/Activity/GetByCategory/{id}")]
        public IHttpActionResult GetByCategory(int id)
        {
            ActivityService activityService = CreateActivityService();
            var activity = activityService.GetActivitiesByCategory(id);
            return Ok(activity);
        }

        /// <summary>
        /// Get Activity by ActivityId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public IHttpActionResult Get(int id)
        {
            ActivityService activityService = CreateActivityService();
            var activity = activityService.GetActivityById(id);
            return Ok(activity);
        }
        /// <summary>
        /// Update an Activity
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public IHttpActionResult Put(ActivityEdit activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.UpdateActivity(activity))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete an Activity by ActivityId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateActivityService();

            if (!service.DeleteActivity(id))
                return InternalServerError();

            return Ok();
        }

        private ActivityService CreateActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var activityService = new ActivityService(userId);
            return activityService;
        }
    }
}
