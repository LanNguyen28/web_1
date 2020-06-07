namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDER")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            ORDERDETAIL = new HashSet<ORDERDETAIL>();
        }

        public int OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public double? Total { get; set; }

        [Required]
        [StringLength(250)]
        public string CustomerName { get; set; }

        [StringLength(20)]
        public string CustomerPhone { get; set; }

        [StringLength(250)]
        public string CustomerAdress { get; set; }

        [StringLength(250)]
        public string CustomerEmail { get; set; }

        public int? CustomerID { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAIL { get; set; }
    }
}
