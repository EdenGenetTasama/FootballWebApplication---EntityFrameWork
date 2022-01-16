using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FootballWebApplication.Models
{
    public partial class FootBallContext : DbContext
    {
        public FootBallContext()
            : base("name=FootBallContext")
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
