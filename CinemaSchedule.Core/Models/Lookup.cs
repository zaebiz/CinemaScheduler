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
    /// Базовый класс для словаря
    /// </summary>
    public class Lookup 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int? Value { get; set; }
    }

    /// <summary>
    /// словарь возрастных рейтингов фильма
    /// </summary>
    public class MovieRatingLookup : Lookup
    {}
}
