using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Context
{
    public class GameDBContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}
