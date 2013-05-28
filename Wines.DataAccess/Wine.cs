using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wines.DataAccess {
    public class Wine {
        public long id { get; set; }
        public string name { get; set; }
        public string grapes { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string year { get; set; }
        public string description { get; set; }
        public string picture { get; set; }
    }
}
