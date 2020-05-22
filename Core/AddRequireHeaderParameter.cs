using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShopWarehouse.API.Core
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "access token",
                Schema = new OpenApiSchema
                {
                    Type = "String",
                    Default = new OpenApiString("Bearer ")
                },
                Required = true
            });
        }
    }
}
