using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace Models
{
    public class Employys
    {
        [Key]
        public int EmployyId { get; set; }
        public string EmployyName { get; set; }=string.Empty;
        public int DepartId { get; set; }
    }
    public class EmployysLeave
    {
        [Key]
        public int LeaveId { get; set; }
        public int EmployyId { get; set; }
        public int NumOfDays { get; set; }
    }
    public class EmployysContext : DbContext
    {
        public DbSet<Employys> Employys { get; set; }
        public DbSet<EmployysLeave> EmployysLeave { get; set; }
        public string Dbpath { get; }
        public EmployysContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Dbpath = System.IO.Path.Join(path, "LeaveManagement1.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={Dbpath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employys>().HasKey(k => k.EmployyId);
            modelBuilder.Entity<EmployysLeave>().HasKey(k => k.LeaveId);
        }
    }
}
