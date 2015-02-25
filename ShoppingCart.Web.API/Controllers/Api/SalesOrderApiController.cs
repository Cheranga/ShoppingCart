using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ShoppingCart.Business.Models;
using ShoppingCart.DTO;
using ShoppingCart.DTO.Extensions.ModelExtensions;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.Web.API.Controllers.Api
{
    public class SalesOrderApiController : BaseApiController
    {
        public SalesOrderApiController(IUoW uow) : base(uow)
        {
        }

        public SalesOrderDTO GetSalesOrderById(int id)
        {
            var repository = this.UoW.GetRepository<SalesOrder>();
            if(repository == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var salesOrder = repository.GetById(id);
            if(salesOrder == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return salesOrder.ToDTO();
        }
    }
}
