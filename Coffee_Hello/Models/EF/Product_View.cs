namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_View
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string CategoryName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductPrice { get; set; }

        public string ShowImage { get; set; }

        public string ProductDescription { get; set; }

        [StringLength(2)]
        public string Size { get; set; }
    }
}
