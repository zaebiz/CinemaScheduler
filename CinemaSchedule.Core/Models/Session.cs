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
    /// Расписание показа фильма в кинотеатре на определенную дату.  
    /// </summary>
    public class Session
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MovieDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public int TicketPrice { get; set; }

        public virtual MovieDay MovieDay { get; set; }
    }
}
