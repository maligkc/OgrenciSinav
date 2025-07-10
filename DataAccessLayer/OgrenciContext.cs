using EntityLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OgrenciContext : DbContext
    {
        public OgrenciContext(DbContextOptions<OgrenciContext> options) : base(options) { }

        public DbSet<NotlarDto> Notlar { get; set; }
        public DbSet<TBLDERS> TBLDERS { get; set; }
        public DbSet<TBLOGRENCI> TBLOGRENCI { get; set; }
        public DbSet<TBLNOTLAR> TBLNOTLAR { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotlarDto>().HasNoKey();// stored procedure keysizdir.
        }
    }
}
