using Microsoft.EntityFrameworkCore;

namespace APISalasEveris.Models
{
    public class RoomContext :  DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options)
        { }

        public DbSet<RoomInformation> RoomInformations { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Building> Building { get; set; }
    }
}
