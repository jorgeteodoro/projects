using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ZurichApp.Commands;
using Zurich.Domain.Handler;

namespace ZurichApp.Controllers
{
    /// <summary>
    /// Represents a RESTful service.
    /// </summary>
    [RoutePrefix("api/zurich")]
    public class ServiceController : ApiController
    {

       

        private readonly VeiculoServiceHandler _handler;

        /// <summary>
        /// Endorsement Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="handler"></param>
        public ServiceController(VeiculoServiceHandler handler)
        {
            _handler = handler;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route]
        [ResponseType(typeof(CreateCommand))]
        public IHttpActionResult Post([FromBody]CreateCommand cmd)
        {

         

            var endorsement = _handler.CreateHandle(cmd);

            if (endorsement.Success)
                return Ok(endorsement);

            return Content(HttpStatusCode.BadRequest, endorsement);


        }


    }
}
