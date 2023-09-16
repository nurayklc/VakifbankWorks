using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Entities
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Surname { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
