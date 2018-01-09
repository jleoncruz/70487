using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CountingKs.Data;
using System.Web.Http.Cors;

namespace CountingKs.Controllers
{
    [RoutePrefix("api/stats")]
    //[EnableCors("*", "*", "GET")] //Method Level or Controller Level
    public class StatsController : BaseApiController
    {
        public StatsController(ICountingKsRepository repo) : base(repo)
        {

        }

        //[Route("api/stats")]
        [Route("")]
        //[DisableCors()]  //Method Level or Controller Level
        //public HttpResponseMessage Get()
        public IHttpActionResult Get()
        {
            var results = new
            {
                NumFoods = TheRepository.GetAllFoods().Count(),
                NumUsers = TheRepository.GetApiUsers().Count()
            };

            return Ok(results);
            //return Request.CreateResponse(results);
        }

        //[Route("api/stats/{id}")]
        //[Route("{id}")]
        [Route("~/api/stat/{id:int}")]
        //public HttpResponseMessage Get(int id)
        public IHttpActionResult Get(int id)
        {
            if (id == 1)
            {
                //return Request.CreateResponse(new { NewFoods = TheRepository.GetAllFoods().Count() });
                return Ok(new { NewFoods = TheRepository.GetAllFoods().Count() });
            }

            if (id == 2)
            {
                //return Request.CreateResponse(new { NumUsers = TheRepository.GetApiUsers().Count() });
                return Ok(new { NumUsers = TheRepository.GetApiUsers().Count() });
            }

            //return Request.CreateResponse(HttpStatusCode.NotFound);
            return NotFound();
        }

        [Route("~/api/stat/{name:alpha}")]
        //public HttpResponseMessage Get(string name)
        public IHttpActionResult Get(string name)
        {
            if (name == "foods")
            {
                return Ok(new { NewFoods = TheRepository.GetAllFoods().Count() });
            }

            if (name == "users")
            {
                return Ok(new { NumUsers = TheRepository.GetApiUsers().Count() });
            }

            //return Request.CreateResponse(HttpStatusCode.NotFound);
            return NotFound();
        }
    }
}
