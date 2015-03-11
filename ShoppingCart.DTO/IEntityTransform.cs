using System;
using System.Linq.Expressions;

namespace ShoppingCart.DTO
{
    public interface IEntityTransform<T, U> where T:IDto where U:class 
    {
        Expression<Func<T, U>> ToModel { get; }
        Expression<Func<U, T>> ToDTO { get; }
    }
}