using MeikoAPI.Models.DB;
using System.Data.Entity;
using System.Diagnostics;

namespace meiko.Models
{
    public class MeikoContext : DbContext
    {
        public MeikoContext()
            : base("DefaultConnection")
        {
#if (DEBUG)
            Database.Log = sql => Debug.Write(sql);
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SOLA");
        }

        public DbSet<仕入実績月部門別集計ビュー> 仕入実績月部門別集計ビューs { get; set; }
        public DbSet<仕入実績ビュー> 仕入実績ビューs { get; set; }

    }
}