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
        private readonly Guid _userdId;

        public ActivityService(Guid userId)
        {

            _userdId = userId;
        }

        public bool CreateActivity(ActivityCreate model)
        {
            var entity =
                new Activity()
                {
                    UserId = _userdId, 
                    Title = model.Title,
                    CreatedUtc = DateTimeOffset.Now

                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }

        













    }
}
