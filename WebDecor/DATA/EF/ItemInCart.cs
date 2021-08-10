namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemInCart
    {
        public string ID { get; set; }

        [Required]
        [StringLength(128)]
        public string ProductID { get; set; }

        public decimal Price { get; set; }

        public int? SL { get; set; }

        public decimal Total { get; set; }

        [Required]
        [StringLength(128)]
        public string CartItemID { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
