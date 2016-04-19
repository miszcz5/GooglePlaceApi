using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleApi;
using MainApplication;
using Storage.ReadModels;

namespace Storage {
    public class LocationBarsDbContext : DbContext {
        private IDataProvider dataProvider;

        public LocationBarsDbContext() : base("DbConnection") {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LocationBarsDbContext>());
        }

        public LocationBarsDbContext(IDataProvider dataProvider) {
            this.dataProvider = dataProvider;
        }

        public DbSet<BarEntity> BarEntities { get; set; }
        public DbSet<LocationBarsEntity> LocationBarsEntities { get; set; }
        public DbSet<LocationEntity> LocationEntities { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<BarEntity>()
                .HasRequired(s => s.LocationBarsEntity).WithMany(s=>s.BarEntities).WillCascadeOnDelete(true);
            modelBuilder.Entity<LocationBarsEntity>()
               .HasRequired(s => s.Location)
               .WithRequiredPrincipal(s => s.LocationBarsEntity).WillCascadeOnDelete(true);
        }

    }
}
