namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ItemInCarts = new HashSet<ItemInCart>();
            OrderInfoes = new HashSet<OrderInfo>();
        }

        public string ID { get; set; }

        [Required]
        public string ProductName { get; set; }

        public long Made { get; set; }

        public string Info { get; set; }

        public string Descript { get; set; }

        public decimal? Price { get; set; }

        public decimal Sale { get; set; }

        public long Category { get; set; }

        public bool Freeship { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int SL { get; set; }

        public DateTime DateUpdate { get; set; }

        public bool STT { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemInCart> ItemInCarts { get; set; }

        public virtual Made Made1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderInfo> OrderInfoes { get; set; }
    }
}
