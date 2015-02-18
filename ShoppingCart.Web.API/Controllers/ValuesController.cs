using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Infrastructure.UoW;
using ShoppingCart.Web.API.Models;

namespace ShoppingCart.Web.API.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private readonly IUoW uow;

        public ValuesController(IUoW uow)
        {
            this.uow = uow;
        }

        // GET api/values
        public IEnumerable<TestCustomer> Get()
        {
            //return new string[] { "value1", "value2" };
            return new[]
                   {
                     new TestCustomer{Id = 1, Name = "Cheranga", Address = "Mt. Waverley"},  
                     new TestCustomer{Id = 2, Name = "Bodhi", Address = "Mt. Waverley"},
                     new TestCustomer{Id = 3, Name = "Kenolee", Address = "Mt. Waverley"}
                   };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
