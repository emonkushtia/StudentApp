namespace StudentApp.Core.DataTransferObjects
{
    using System;

    [Serializable]
    public class CourseItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
