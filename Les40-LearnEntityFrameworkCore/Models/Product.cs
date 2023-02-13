using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les40_LearnEntityFrameworkCore.Models
{
    /**
     * Table : cau hinh ten bang trong sql
     * [Key]: Primary Key
     * [Required]: not null
     * [StringLength(50)] -> nvarchar(50)
     * TypeName: config ten kdl cu the
     * [Column(name:"product_name", TypeName ="ntext")]
     * 
     * Refrence Navigaton -> Foreign Key (1 -N)
     * Collect Navigation -> Ko tao Fk
     */
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column(name:"product_name", TypeName ="ntext")]
        public string ProductName { get; set; }

        [Column(TypeName ="money")]
        public decimal Price { get; set; }


        /*public int CateId { set; get; }           // Thuộc tính sẽ thiết lập là FK

        [ForeignKey("CateId")]
        public virtual Category Category { set; get; }       // Sinh FK (CategoryID ~ Cateogry.CategoryID) ràng buộc đến PK key của Category

        public int? CategorySecondId;
        [ForeignKey("CategorySecondId")]
        [InverseProperty("products")]
        public virtual Category SecondCategory { set; get; }*/

        public int CateId { set; get; }           // Thuộc tính sẽ thiết lập là FK

        [ForeignKey("CateId")]
        public Category Category { set; get; }       // Sinh FK (CategoryID ~ Cateogry.CategoryID) ràng buộc đến PK key của Category


        public void PrintInfo() => Console.WriteLine($"{ProductId} - {ProductName} - {CateId} - {Price}");
    }
}

