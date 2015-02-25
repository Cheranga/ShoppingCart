using System;
using System.Linq.Expressions;
using ShoppingCart.Business.Models;
using ShoppingCart.DTO.DTOs;

namespace ShoppingCart.DTO.Extensions.Transformations
{
    public class SalesOrderTransformations : IEntityTransform<SalesOrderDTO, SalesOrder>
    {
        public Expression<Func<SalesOrderDTO, SalesOrder>> ToModel
        {
            get
            {
                return salesOrderDto => new SalesOrder
                                        {
                                            Id = salesOrderDto.Id,
                                            CustomerName = salesOrderDto.CustomerName,
                                            PONumber = salesOrderDto.PONumber
                                        };
            }
            set
            {
                
            }
        }
        public Expression<Func<SalesOrder,SalesOrderDTO>> ToDTO
        {
            get
            {
                return salesOrder => new SalesOrderDTO
                                     {
                                         Id = salesOrder.Id,
                                         CustomerName = salesOrder.CustomerName,
                                         PONumber = salesOrder.PONumber
                                     };
            }
            set
            {
                
            }
            
        }
    }
}