using Microsoft.AspNetCore.Mvc;
using Lottery.Service;
using System.Threading.Tasks;

namespace Lottery.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Visitors")]
    public class VisitorsController : BaseController
    {

        private readonly VisitorsService visitorsService = new VisitorsService();

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            await visitorsService.Created();

            return Result();
        }
    }
}