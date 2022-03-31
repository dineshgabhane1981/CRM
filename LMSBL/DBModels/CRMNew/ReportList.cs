using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBL.DBModels
{
    public class ReportList
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CurrentStage { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
