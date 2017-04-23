using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage = "Не указано  время начала сеанса"), DisplayName("Время начала")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Задайте время между 00:00 и 23:59")]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "Не указана цена"), DisplayName("Цена билета")] 
        [DataType(DataType.Currency, ErrorMessage = "Некорректная цена")]
        public decimal TicketPrice { get; set; }

        public virtual MovieDay MovieDay { get; set; }
    }
}
