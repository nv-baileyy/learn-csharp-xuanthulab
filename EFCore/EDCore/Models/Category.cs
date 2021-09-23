using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace EFCore.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}
        [StringLength(100)]
        public string Name {get; set;}
        [Column("description", TypeName = "ntext")]
        public string Description {get; set;}
        // Collect Navigation
        public List<Product> products {get; set;}
        public CategoryDetail categoryDetail {get; set;}
    }
}