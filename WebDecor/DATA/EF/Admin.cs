namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        public string ID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128)]
        public string Pass { get; set; }

        [Required]
        public string NameAd { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public long RoleAdmin { get; set; }

        public bool STT { get; set; }

        public virtual RoleAdmin RoleAdmin1 { get; set; }
    }
}
