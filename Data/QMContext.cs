using Microsoft.EntityFrameworkCore;
using QinMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QinMilitary.Data
{
    public class QMContext : DbContext
    {
        public QMContext(DbContextOptions<QMContext> options) : base(options) { }

        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soldier>().ToTable("Soldier");
            modelBuilder.Entity<Officer>().ToTable("Officer");
            modelBuilder.Entity<Achievement>().ToTable("Achievement");
            modelBuilder.Entity<Unit>().ToTable("Unit");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
        }
    }
}
