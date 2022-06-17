using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public string Size { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }


        public virtual ICollection<Player> Players { get; set; }
    }
}
