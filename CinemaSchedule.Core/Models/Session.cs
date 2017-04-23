using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Core.Models
{
    /// <summary>
    /// Расписание сеансов на определенную дату.  
    /// </summary>
    public class Session : IDbEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        

        public int MovieDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public decimal TicketPrice { get; set; }

        public virtual MovieDay MovieDay { get; set; }
    }
}
