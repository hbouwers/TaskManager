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
                new Activity()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Description = model.Description,


                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<ActivityListItem> GetActivitiesByUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Activities
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new ActivityListItem
                        {
                            Title = e.Title,
                            Description = e.Description,

                        }
                        );
                return query.ToArray();

            }

        }


        public bool UpdateActivity(ActivityEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Activities
                    .Single(e => e.ActivityId == model.ActivityId && e.UserId == _userId);

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
                    .Single(e => e.ActivityId == activityId && e.UserId == _userId);

                ctx.Activities.Remove(entity);

                return ctx.SaveChanges() == 1;

            }

        }

































    }
}
