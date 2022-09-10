using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFishka.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(EventsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
