namespace LMSBL.DBModels.CRMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("tblCRMAgreement")]
    public partial class tblCRMAgreement
    {
        [Key]
        public int AgreementId { get; set; }
        public int ClientId { get; set; }
        
        [Required]
        [AllowHtml]
        [StringLength(250)]
        public string AgreementName { get; set; }

        public string AgreementContent { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
