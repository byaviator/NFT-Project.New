using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.DAL.Models
{
    public class CollectionModel :BaseModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string ItemsInCollection { get; set; }
        public string ImgPath { get; set; }

    }
}
