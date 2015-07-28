using ActionsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace ActionsServer.Controllers
{
    public class TokensController : ApiController
    {
        [ResponseType(typeof(Token))]
        public IHttpActionResult GetToken(string domain)
        {
            var result = new Token { Id = 1, Value = "XXX-" + domain };
            return Ok(result);
        }
    }
}
