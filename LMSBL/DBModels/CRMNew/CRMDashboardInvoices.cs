using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBL.DBModels.CRMNew
{
    public class CRMDashboardInvoices
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDueDate { get; set; }
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
