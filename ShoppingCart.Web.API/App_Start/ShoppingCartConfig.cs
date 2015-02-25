using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting.Jsonp;

namespace ShoppingCart.Web.API.App_Start
{
    public static class ShoppingCartConfig
    {
        public static void ConfigureApplication(HttpConfiguration configuration)
        {
            //
            // Add JSONP formatter
            //
            configuration.Formatters.Add(new JsonpMediaTypeFormatter(new JsonMediaTypeFormatter()));
            //
            // Have camel casing when converting object properties to JSON
            //
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}