namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInfo")]
    public partial class OrderInfo
    {
        public long ID { get; set; }

        [Required]
        [StringLength(128)]
        public string ItemOrder { get; set; }

        [Required]
        [StringLength(128)]
        public string ProductID { get; set; }

        public int SL { get; set; }

        public decimal Total { get; set; }

        public virtual OrderBill OrderBill { get; set; }

        public virtual Product Product { get; set; }
    }
}
