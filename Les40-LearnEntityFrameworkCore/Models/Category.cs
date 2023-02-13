﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les40_LearnEntityFrameworkCore.Models
{
    [Table(name:"Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName ="ntext")]
        public string Description { get; set; }

        /* public virtual List<Product> Products { get; set; }*/

        public List<Product> Products { get; set; }
    }
}
