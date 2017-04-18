namespace StudentApp.Core.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccess.DomainObjects;

    using DataTransferObjects;
    using Infastucture;
    using Interfaces;

    public class StudentRepositoryService : IRepositoryService<StudentItem, StudentCreateItem>
    {
        private readonly IRepository<Student> repository;
        private readonly IRepository<Course> courserepository;

        public StudentRepositoryService(IRepository<Student> repository, IRepository<Course> courserepository)
        {
            this.repository = repository;
            this.courserepository = courserepository;
        }

        public async Task<PagedListResult<StudentItem>> GetPagedList(PageableListQuery query)
        {
            var students = await this.repository.GetPagedList(query);

            var studentItems = students.List.Select(item => new StudentItem
                                                                {
                                                                    Id = item.Id, Name = item.Name, Phone = item.Phone
                                                                }).ToList();

            return new PagedListResult<StudentItem>(studentItems, students.Count);
        }

        public async Task<StudentItem> Get(int id)
        {
            var student = await this.repository.Get(id);
            var studentItem = new StudentItem
                                  {
                                      Id = student.Id,
                                      Name = student.Name,
                                      Phone = student.Phone,
                                      Email = student.Email,
                                      Organization = student.Organization,
                                      AddressId = student.AddressId,
                                      House = student.Address.House,
                                      Street = student.Address.Street,
                                      PostBox = student.Address.PostBox,
                                      City = student.Address.City,
                                      ZipCode = student.Address.ZipCode
                                  };
            student.Courses.ToList().ForEach(
                x =>
                    {
                        studentItem.CourseItems.Add(new CourseItem { Id = x.Id, Name = x.Name });
                    });
            return studentItem;
        }

        public async Task Save(StudentCreateItem studentItem)
        {
            var address = new StudentAddress
                              {
                                  House = studentItem.House,
                                  Street = studentItem.Street,
                                  PostBox = studentItem.PostBox,
                                  City = studentItem.City,
                                  ZipCode = studentItem.ZipCode
                              };
            var student = new Student
                              {
                                  Name = studentItem.Name,
                                  Phone = studentItem.Phone,
                                  Email = studentItem.Email,
                                  Organization = studentItem.Organization,
                                  Address = address
                              };

            foreach (var courseId in studentItem.CoursesList)
            {
                var course = await this.courserepository.Get(courseId);
                student.Courses.Add(course);
            }

            await this.repository.Save(student);
        }

        public async Task Update(StudentCreateItem studentItem)
        {
            var student = await this.repository.Get(studentItem.Id);
            if (student != null)
            {
                student.Name = studentItem.Name;
                student.Phone = studentItem.Phone;
                student.Email = studentItem.Email;
                student.Organization = studentItem.Organization;
                student.Address.House = studentItem.House;
                student.Address.Street = studentItem.Street;
                student.Address.PostBox = studentItem.PostBox;
                student.Address.City = studentItem.City;
                student.Address.ZipCode = studentItem.ZipCode;

                student.Courses.Clear();
                foreach (var courseId in studentItem.CoursesList)
                {
                    var course = await this.courserepository.Get(courseId);
                    student.Courses.Add(course);
                }

                await this.repository.Save(student);
            }
        }

        public async Task Delete(int id)
        {
           await this.repository.Delete(id);
        }
    }
}
