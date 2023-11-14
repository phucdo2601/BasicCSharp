using System.ComponentModel.DataAnnotations;

namespace LearnNet5ApiEntityFrameWithMysqlB01.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Firstname { get; set; }
        [MaxLength(50)]
        public string Lastname { get; set; }
        public int Age { get; set; }
        public bool IsPlayer { get; set; }

    }
}
