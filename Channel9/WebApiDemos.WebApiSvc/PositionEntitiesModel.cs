namespace WebApiDemos.WebApiSvc
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PositionEntitiesModel : DbContext
    {
        public PositionEntitiesModel()
            : base("name=PositionsContext")
        {
        }

        public virtual DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
