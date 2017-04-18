namespace StudentApp.Core.Service
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccess.DomainObjects;

    using DataTransferObjects;
    using Infastucture;
    using Interfaces;

    public class CourseRepositoryService : IRepositoryService<CourseItem, CourseCreateItem>
    {
        private readonly IRepository<Course> repository;

        public CourseRepositoryService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<PagedListResult<CourseItem>> GetPagedList(PageableListQuery query)
        {
            var lstCourse = await this.repository.GetPagedList(query);

            var lstCourseItem = lstCourse.List.Select(item => new CourseItem
                                                                  {
                                                                      Id = item.Id, Name = item.Name
                                                                  }).ToList();

            return new PagedListResult<CourseItem>(lstCourseItem, lstCourseItem.Count);
        }

        public Task<CourseItem> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(CourseCreateItem obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(CourseCreateItem obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
