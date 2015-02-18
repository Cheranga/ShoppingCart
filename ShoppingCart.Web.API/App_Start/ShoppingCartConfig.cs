using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;

namespace ShoppingCart.Web.API.App_Start
{
    public static class ShoppingCartConfig
    {
        public static void ConfigureApplication(HttpConfiguration configuration)
        {
            configuration.Formatters.Add(new JsonpMediaTypeFormatter(new JsonMediaTypeFormatter()));
        }
    }
}