using AnketToplamaMerkezi.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.DAL
{
    public class SurveyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-0477TV9\\TEW_SQLEXPRESS;database=SurveyDB;integrated security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PollsterInformation>()
                .HasData(
                    new PollsterInformation
                    {
                        Id = 1,
                        PollsterName = "John",
                        PollsterSurname = "Doe"
                    },
                    new PollsterInformation
                    {
                        Id = 2,
                        PollsterName = "Jane",
                        PollsterSurname = "Doe"
                    }
                );

            modelBuilder.Entity<SurveyInformation>()
                .HasData(
                    new SurveyInformation
                    {
                        Id = 1,
                        PollsterId = 1,
                        SurveyName = "Tuttuğunuz Futbol Takımı",
                        SurveyType = 1
                    },
                    new SurveyInformation
                    {
                        Id = 2,
                        PollsterId = 2,
                        SurveyName = "Hayatınızdan Memnunmusunuz",
                        SurveyType = 2
                    }
                );

        }
        public DbSet<SurveyInformation> SurveyInformations { get; set; }
        public DbSet<HappinessSurveyAnswers> HappinessSurveyAnswers { get; set; }
        public DbSet<FootballSurveyAnswers> FootballSurveyAnswers { get; set; }
        public DbSet<PollsterInformation> PollsterInformation { get; set; }
        public DbSet<SavedSurveys> SavedSurveys { get; set; }

    }


}
