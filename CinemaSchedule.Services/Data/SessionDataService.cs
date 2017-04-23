using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Extensions;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Models.Filters;

namespace CinemaSchedule.Services.Data
{
    /// <summary>
    /// CRUD сервис сеансов
    /// </summary>
    public class SessionDataService : DataServiceBase<Session>
    {
        public SessionDataService(ApplicationDbContext ctx) : base(ctx)
        {
        }

        private async Task ValidateSession(Session newSession)
        {
            var sessionsFromDb = await GetList(new SessionFilter()
            {
                MovieDayId = newSession.MovieDayId
            });

            var newSessionStartTime = newSession.StartTime.ConvertToTimeSpan();
            foreach (var session in sessionsFromDb)
            {
                if (session.StartTime.ConvertToTimeSpan() == newSessionStartTime)
                    throw new Exception("Сеанс на это время уже создан");
            }

        }

        public override async Task<Session> AddItem(Session item)
        {
            await ValidateSession(item);
            return await base.AddItem(item);
        }

        public override async Task<Session> UpdateItem(Session item)
        {
            await ValidateSession(item);
            return await base.UpdateItem(item);
        }
    }
}
