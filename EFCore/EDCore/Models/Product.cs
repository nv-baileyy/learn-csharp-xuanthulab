using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
/*
Table("tableName")
[Key] -> Primary Key (PK)
[Required] -> Not null
[StringLength()] -> nvarchar
[Column("Tenanpham", TypeName = "ntext")]
[ForeignKey("CategID")]
References Navigation  -> Foreign Key (1 -> N)
Collection Navigation -> (khong tao Fk)
-> cac navigation khong dc nap truc tiep khi tuy van du lieu, ta phari nap thu cong bang EntityEntry
InverseProperty
congig in fluent API will override Anonation Attributes
*/

namespace EFCore.Models
{
    // [Table("Product")]
    public class Product
    {
        // [Key]
        public int ProductID { get; set; }

        // [Required]
        // [StringLength(50)]
        // [Column("Tenanpham", TypeName = "ntext")]
        // [Column(TypeName = "ntext")]
        public string Name { get; set; }

        // [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int? CategID { get; set; }
        // References Navigation
        // Foreign key
        // [ForeignKey("CategID")]
        // [Required] 
        public Category category { get; set; } //  Fk -> PK  : if not set attribute [ForeignKey] -> categoryId
        public void PrintInfor() => Console.WriteLine($"{ProductID} - {Name} - {Price} - {CategID}");
    }
}