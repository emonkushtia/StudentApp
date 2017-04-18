namespace StudentApp.DataAccess.DomainObjects
{
    using System.ComponentModel.DataAnnotations;

    public class StudentAddress
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string House { get; set; }

        [StringLength(100)]
        [Required]
        public string Street { get; set; }

        [StringLength(40)]
        public string PostBox { get; set; }

        [Required]
        public string City { get; set; }

        public string ZipCode { get; set; }
    }
}
