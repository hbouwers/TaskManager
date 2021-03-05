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
        private readonly Guid _userId;

        public ActivityService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateActivity(ActivityCreate model)
        {
            var entity =
                new Activity
                {
                    UserId = _userId,
                    CategoryId = model.CategoryId,
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
                    .Where(e => e.UserId == _userId)
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
                    .Where(e => e.UserId == _userId)
                    .SingleOrDefault(e => e.ActivityId == Id);

                return new ActivityDetail
                {
                    ActivityId = entity.ActivityId,
                    CategoryId = entity.CategoryId,
                    Title = entity.Title,
                    Description = entity.Description
                };
            }
        }

        public bool UpdateActivity(ActivityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Activities
                    .Where(e => e.UserId == _userId)
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
                    .Where(e => e.UserId == _userId)
                    .Single(e => e.ActivityId == activityId);

                ctx.Activities.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
