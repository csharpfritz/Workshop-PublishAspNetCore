using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{

  public class SpeakerDbContext : DbContext
  {

    public SpeakerDbContext(DbContextOptions<SpeakerDbContext> options) : base(options) { }

    public DbSet<Speaker> Speakers { get; set; }

  }

  public static class SpeakerDbContextExtensions
  {

    public static void EnsureSeedData(this SpeakerDbContext context)
    {

        if (!context.Speakers.Any())
        {

          context.Speakers.AddRange(

            new Speaker { FirstName="Jeff", LastName="Fritz", Company="Microsoft", Topic="Deploying ASP.NET Core"},
            new Speaker { FirstName="Bill", LastName="Wolff", Company="Philly.NET", Topic="Running a Successful User Group"},
            new Speaker { FirstName="Rob", LastName="Keiser", Company="Philly.NET", Topic="Workshops in a Jiffy!"},
            new Speaker { FirstName="Ken", LastName="Lovely", Company="Lovely Lights Inc", Topic="Christmas Light Shows Your Neighbors will Hate"},
            new Speaker { FirstName="Dave", LastName="Voyles", Company="Microsoft", Topic="Build, Play, and Stream Games for a Living"},
            new Speaker { FirstName="Amanda", LastName="Lange", Company="Microsoft", Topic="Introduction to Hololens Development"}

          );

          context.SaveChanges();

        }

    }

    public static bool AllMigrationsApplied(this DbContext context)
    {
      var applied = context.GetService<IHistoryRepository>()
          .GetAppliedMigrations()
          .Select(m => m.MigrationId);


      var total = context.GetService<IMigrationsAssembly>()
          .Migrations
          .Select(m => m.Key);


      return !total.Except(applied).Any();

    }


  }

}
