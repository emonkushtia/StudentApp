namespace StudentApp.DataAccess
{
    using System.Data.Entity;

    using DomainObjects;

    public class DataContext : DbContext
    {
        public DataContext() : base("StudentAppContext")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }
    }
}
