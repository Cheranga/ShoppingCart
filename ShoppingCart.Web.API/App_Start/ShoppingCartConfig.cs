using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting.Jsonp;

namespace ShoppingCart.Web.API.App_Start
{
    public static class ShoppingCartConfig
    {
        public static void ConfigureApplication(HttpConfiguration configuration)
        {
            //
            // Avoiding cyclic redundancy
            //
            var jsonFormatter = configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.PreserveReferencesHandling= PreserveReferencesHandling.Objects;
            //
            // Add JSONP formatter
            //
            var jsonpFormatter = GetJSONPFormatter();
            configuration.Formatters.Add(jsonpFormatter);
            //
            // Have camel casing when converting object properties to JSON and JSONP
            //
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static MediaTypeFormatter GetJSONPFormatter()
        {
            //
            // create a supported jsonmediatypeformatter with camel casing enabled when serialized
            //
            var supportiveJsonFormatter = new JsonMediaTypeFormatter
                                          {
                                              SerializerSettings =
                                              {
                                                  ContractResolver = new CamelCasePropertyNamesContractResolver()
                                              }
                                          };

            var jsonpFormatter = new JsonpMediaTypeFormatter(supportiveJsonFormatter);

            return jsonpFormatter;
        }
    }
}