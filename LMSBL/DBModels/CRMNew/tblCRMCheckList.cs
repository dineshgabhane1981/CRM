namespace LMSBL.DBModels.CRMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCRMCheckList
    {
        public int Id { get; set; }

        public int CRMClientID { get; set; }

        [StringLength(250)]
        public string CheckListName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int VisaType { get; set; }
    }
}
