using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Business.Models;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.Web.API.Controllers
{
    public class SalesOrderApiController : ApiController
    {
        private readonly IUoW uow;

        public SalesOrderApiController(IUoW uow)
        {
            this.uow = uow;
        }

        public IQueryable<SalesOrder> GetAll()
        {
            var repository = this.uow.GetRepository<SalesOrder>();
            if (repository == null)
            {
                return null;
            }

            var list = repository.GetAll().ToList();

            return repository.GetAll();
        }
    }
}
