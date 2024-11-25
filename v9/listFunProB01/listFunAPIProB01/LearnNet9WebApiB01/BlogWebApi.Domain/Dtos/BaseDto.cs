using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Dtos
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime DateOfCreated { get; set; }
        public DateTime DateOfModified { get; set; }
    }
}
