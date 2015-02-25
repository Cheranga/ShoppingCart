using System.Web.Http;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.Web.API.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly IUoW uow;

        public IUoW UoW
        {
            get
            {
                return this.uow;
            }
        }

        public BaseApiController(IUoW uow)
        {
            this.uow = uow;
        }
    }
}