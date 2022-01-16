using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballWebApplication.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, MaxLength(15)]

        public string LastName { get; set; }
        public string Posstion { get; set; }
        public int Age { get; set; }

    }
}