using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wines.DataAccess {
    public class Wine {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Grapes { get; set; }
        public string  Country { get; set; }
        public string Region { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
