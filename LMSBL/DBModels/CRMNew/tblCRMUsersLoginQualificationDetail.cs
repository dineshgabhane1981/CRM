namespace LMSBL.DBModels.CRMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class tblCRMUsersLoginQualificationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; }
        [AllowHtml]
        public string ImmigrationLoginDetails { get; set; }
        [AllowHtml]
        public string QualificationAssessmentDetails { get; set; }
    }
}
