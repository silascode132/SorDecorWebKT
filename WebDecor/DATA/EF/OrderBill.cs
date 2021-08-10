namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderBill()
        {
            OrderInfoes = new HashSet<OrderInfo>();
        }

        public string ID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        public string UserAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        public string Note { get; set; }

        public bool Paid { get; set; }

        public bool DeliverySTT { get; set; }

        public DateTime DateOrder { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string Email { get; set; }

        public virtual UserAccount UserAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderInfo> OrderInfoes { get; set; }
    }
}
