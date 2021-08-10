namespace WebDecor.DATA.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImgRate")]
    public partial class ImgRate
    {
        public long ID { get; set; }

        public byte[] Image { get; set; }

        public string ImageUrl { get; set; }

        public long? RateID { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
