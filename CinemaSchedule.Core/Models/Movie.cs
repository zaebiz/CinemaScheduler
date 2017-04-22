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
    /// Модель описывающая фильм
    /// </summary>
    public class Movie : IDbEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int MovieRatingLookupId { get; set; }
        public MovieRatingLookup MovieRatingLookup { get; set; }
}
}
