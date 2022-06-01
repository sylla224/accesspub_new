using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accesspubnew.Models
{
    public class RateViewModel
    {
        public string rate_code_usd { get; set; }
        public string rate_achat_usd { get; set; }
        public string rate_vente_usd { get; set; }
        public string rate_code_eur { get; set; }
        public string rate_achat_eur { get; set; }
        public string rate_vente_eur { get; set; }
        public string date_jour { get; set; }
    }
}
