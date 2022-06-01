using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accesspubnew.Models
{
    public class rate
    {
        public int ID { get; set; }
        public string rate_code { get; set; }
        public string rate_achat { get; set; }
        public string rate_vente { get; set; }
        public string date_jour { get; set; }
    }
}
