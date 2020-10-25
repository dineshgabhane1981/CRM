using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBL.DBModels.CRMNew
{
    public class CRMDashboardClients
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? LodgementDate { get; set; }
        public string SubStageName { get; set; }

    }
}
