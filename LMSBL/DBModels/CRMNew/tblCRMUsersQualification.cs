namespace LMSBL.DBModels.CRMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCRMUsersQualification
    {
        [Key]
        public int QualificationId { get; set; }

        public int ClientId { get; set; }

        [StringLength(250)]
        public string Qualification { get; set; }

        [StringLength(250)]
        public string AwardingBody { get; set; }

        public DateTime? DateAwarded { get; set; }

        [StringLength(250)]
        public string Country { get; set; }

        public bool Exempt { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
