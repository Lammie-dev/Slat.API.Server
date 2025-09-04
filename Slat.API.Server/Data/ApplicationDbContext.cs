using Microsoft.EntityFrameworkCore;
using Slat.API.Server.DataModels;

namespace Slat.API.Server
{
  
   /// <summary>
   /// this represent a bridge through the database
   /// </summary>
    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<StudentDataModel> Students { get; set; }
        public DbSet<LecturerDataModel> Lecturer { get; set; }
    }
     
    }
