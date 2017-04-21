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
    /// Модель кинотеатра
    /// </summary>
    public class Cinema 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int MaxSpectatorsCount { get; set; }
        public string Address { get; set; }
    }
}
