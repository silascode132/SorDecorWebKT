namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rating()
        {
            ImgRates = new HashSet<ImgRate>();
        }

        public long ID { get; set; }

        public string Comment { get; set; }

        public DateTime? DateUpdate { get; set; }

        [StringLength(128)]
        public string ProductID { get; set; }

        public int? Rate { get; set; }

        [StringLength(128)]
        public string UserAccount { get; set; }

        public byte[] Image { get; set; }

        public string ImageUrl { get; set; }

        public bool STT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImgRate> ImgRates { get; set; }

        public virtual Product Product { get; set; }

        public virtual UserAccount UserAccount1 { get; set; }
    }
}
