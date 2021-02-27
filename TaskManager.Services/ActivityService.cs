using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.Activity;

namespace TaskManager.Services
{
    public class ActivityService
    {
        // private readonly Guid _userId;
        
        //public ActivityService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateActivity(ActivityCreate model)
        {
            var entity =
                new Activity
                {
                    CategoryId = model.CategoryId,
                    //ActivityId = model.ActivityId,
                    Title = model.Title,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ActivityListItem> GetActivities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Activities
                    .Select(c => new ActivityListItem
                    {
                        ActivityId = c.ActivityId,
                        Title = c.Title,
                        Description = c.Description
                    }).ToList();
                return query;
            }
        }

        public ActivityDetail GetActivityById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Activities
                    .SingleOrDefault(e => e.ActivityId == Id);

                return new ActivityDetail
                {
                    ActivityId = entity.ActivityId,
                    Title = entity.Title,
                    Description = entity.Description
                };
            }
        }

        //public IEnumerable<ActivityListItem> GetActivitiesByUser()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Activities
        //            .Where(e => e.UserId == _userId)
        //            .Select(
        //                e =>
        //                new ActivityListItem
        //                {
        //                    Title = e.Title,
        //                    Description = e.Description,
        //                }
        //                );
        //        return query.ToArray();

        public bool UpdateActivity(ActivityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Activities
                    .Single(e => e.ActivityId == model.ActivityId);

                entity.Title = model.Title;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteActivity(int activityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Activities
                    .Single(e => e.ActivityId == activityId);

                ctx.Activities.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
