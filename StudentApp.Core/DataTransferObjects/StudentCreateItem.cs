namespace StudentApp.Core.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class StudentCreateItem
    {
        public StudentCreateItem()
        {
            this.CoursesList = new List<int>();
        }

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

        public List<int> CoursesList { get; set; }
    }
}
