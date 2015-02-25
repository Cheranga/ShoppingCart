using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using ShoppingCart.Business.Models;
using ShoppingCart.DTO;
using ShoppingCart.DTO.DTOs;
using ShoppingCart.DTO.Extensions.Transformations;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.Web.API.Controllers
{
    public class SalesOrderApiController : BaseApiController
    {
        private readonly IEntityTransform<SalesOrderDTO, SalesOrder> entityTransformer;

        public SalesOrderApiController(IUoW uow, IEntityTransform<SalesOrderDTO, SalesOrder> entityTransformer ) : base(uow)
        {
            this.entityTransformer = entityTransformer;
        }

        public IQueryable<SalesOrderDTO> Get()
        {
            var repository = this.UoW.GetRepository<SalesOrder>();
            if (repository == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var salesOrders = repository.GetAll();
           
            var expression = entityTransformer.ToDTO;

            var salesOrderDTOList = salesOrders.Select(expression);

            return salesOrderDTOList;
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

            var expression = entityTransformer.ToDTO.Compile();

            return expression(salesOrder);
        }
    }
}
