﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Core.Models
{
    /// <summary>
    /// Расписание кинотеатра по датам.  
    /// Можем использовать для функционала поиска :
    /// - по фильму (где идет и когда)
    /// - по кинотеатру (что идет и когда)
    /// - по дате (что и где идет)
    /// </summary>
    public class MovieDay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index("UniqueMovieDay", 1, IsUnique = true) ]
        public int CinemaId { get; set; }

        [Index("UniqueMovieDay", 2, IsUnique = true)]
        public int MovieId { get; set; }

        [Index("UniqueMovieDay", 3, IsUnique = true)]
        public DateTime Date { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }

    }
}