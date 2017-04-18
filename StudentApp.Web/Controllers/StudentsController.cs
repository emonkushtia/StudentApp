namespace StudentApp.Web.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Core.DataTransferObjects;
    using Core.Infastucture;
    using Core.Interfaces;

    using Filters;

    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private readonly IRepositoryService<StudentItem, StudentCreateItem> repositoryService;

        public StudentsController(IRepositoryService<StudentItem, StudentCreateItem> repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        [Route("")]
        public async Task<HttpResponseMessage> Get([FromUri]PageableListQuery query)
        {
            query = query ?? new PageableListQuery();
            var students = await this.repositoryService.GetPagedList(query);
            return this.Request.CreateResponse(
                HttpStatusCode.OK, students);
        }

        [Route("{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            var student = await this.repositoryService.Get(id);
            return this.Request.CreateResponse(HttpStatusCode.OK, student);
        }

        [Route("")]
        [ValidateModel]
        public async Task<HttpResponseMessage> Post(StudentCreateItem student)
        {
            try
            {
                await this.repositoryService.Save(student);
            }
            catch
            {
                this.ModelState.AddModelError("Exception", "Student Save failed. Please contact to your system admin.");
                return this.Request.CreateErrorResponse(HttpStatusCode.OK, this.ModelState);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("update")]
        [HttpPost]
        [ValidateModel]
        public async Task<HttpResponseMessage> Update(StudentCreateItem student)
        {
            try
            {
                await this.repositoryService.Update(student);
            }
            catch
            {
                this.ModelState.AddModelError("Exception", "Student update failed. Please contact to your system admin.");
                return this.Request.CreateErrorResponse(HttpStatusCode.OK, this.ModelState);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("{id:int}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            await this.repositoryService.Delete(id);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
