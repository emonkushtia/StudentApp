namespace StudentApp.Core.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class StudentItem
    {
        public StudentItem()
        {
            this.CourseItems = new List<CourseItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Organization { get; set; }

        public int AddressId { get; set; }
       
        public string House { get; set; }
       
        public string Street { get; set; }

        public string PostBox { get; set; }
      
        public string City { get; set; }

        public string ZipCode { get; set; }

        public List<CourseItem> CourseItems { get; set; }
    }
}
