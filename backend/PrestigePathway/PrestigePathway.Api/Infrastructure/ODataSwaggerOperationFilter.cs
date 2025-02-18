using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PrestigePathway.Api.Infrastructure
{
    public class ODataSwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            // Add common OData query options
            var odataQueryOptions = new List<OpenApiParameter>
            {
                new OpenApiParameter
                {
                    Name = "$filter",
                    In = ParameterLocation.Query,
                    Description = "Filter results using OData syntax (e.g., Name eq 'John')",
                    Required = false,
                    Schema = new OpenApiSchema { Type = "string" }
                },
                new OpenApiParameter
                {
                    Name = "$select",
                    In = ParameterLocation.Query,
                    Description = "Select specific fields (e.g., Name, Age)",
                    Required = false,
                    Schema = new OpenApiSchema { Type = "string" }
                },
                new OpenApiParameter
                {
                    Name = "$orderby",
                    In = ParameterLocation.Query,
                    Description = "Order results using OData syntax (e.g., Name asc)",
                    Required = false,
                    Schema = new OpenApiSchema { Type = "string" }
                },
                new OpenApiParameter
                {
                    Name = "$top",
                    In = ParameterLocation.Query,
                    Description = "Limit the number of results (e.g., $top=10)",
                    Required = false,
                    Schema = new OpenApiSchema { Type = "integer", Format = "int32" }
                },
                new OpenApiParameter
                {
                    Name = "$skip",
                    In = ParameterLocation.Query,
                    Description = "Skip a number of results (e.g., $skip=5)",
                    Required = false,
                    Schema = new OpenApiSchema { Type = "integer", Format = "int32" }
                }
            };
            odataQueryOptions.ForEach(o => operation.Parameters.Add(o));

        }
    }

}
