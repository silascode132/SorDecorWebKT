namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            Carts = new HashSet<Cart>();
            Feedbacks = new HashSet<Feedback>();
            OrderBills = new HashSet<OrderBill>();
        }

        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public string Pass { get; set; }

        public string Email { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool? Sex { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public string Diachi { get; set; }

        public bool STT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderBill> OrderBills { get; set; }
    }
}
