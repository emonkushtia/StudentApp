namespace StudentApp.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    using DomainObjects;

    public sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            context.Courses.Add(new Course() { Name = "Bangla" });
            context.Courses.Add(new Course() { Name = "English" });
            context.Courses.Add(new Course() { Name = "Math" });
            context.Courses.Add(new Course() { Name = "Computer" });

            base.Seed(context);
        }
    }
}
