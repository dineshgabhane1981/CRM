namespace LMSBL.DBModels.CRMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        [Key]
        public int userId { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        public string emailId { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string contactNo { get; set; }

        public bool? isActive { get; set; }

        public int createdBy { get; set; }

        public DateTime? createdOn { get; set; }

        public int tenantId { get; set; }

        public int? roleId { get; set; }

        public bool? isNew { get; set; }

        [Column(TypeName = "ntext")]
        public string profileImage { get; set; }

        public int? CRMClientId { get; set; }

        public bool? isLMS { get; set; }
    }
}
