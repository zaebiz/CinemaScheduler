using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;

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
    }
}
