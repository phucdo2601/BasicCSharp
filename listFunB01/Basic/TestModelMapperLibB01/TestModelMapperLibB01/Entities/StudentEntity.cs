using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelMapperLibB01.Entities
{
    public class StudentEntity
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float SignNum { get; set; }
    }
}
