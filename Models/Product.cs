using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace productSystem.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        [Display(Name = "產品名稱")]
        public string ProductName { get; set; } = null!;
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        [Display(Name = "每單位數量")]
        public string? QuantityPerUnit { get; set; }
        [Display(Name = "單位價格")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "庫存量")]
        public short? UnitsInStock { get; set; }
        [Display(Name = "訂貨量")]
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        [Display(Name = "停產")]
        public bool Discontinued { get; set; }

        [Display(Name = "類別")]
        public virtual Category? Category { get; set; }
        [Display(Name = "供應商")]
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
