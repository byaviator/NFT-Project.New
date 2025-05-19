using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.BL.ViewModels
{
    public class CollectionModelVM
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string ItemsInCollection { get; set; }
        public IFormFile? Image { get; set; }
    }
}
