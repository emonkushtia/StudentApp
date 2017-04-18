namespace StudentApp.DataAccess.DomainObjects
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students")]
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(20)]
        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Organization { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public StudentAddress Address { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
