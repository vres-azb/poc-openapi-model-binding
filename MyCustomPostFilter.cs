using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PocApi;

public class MyCustomPostFilter: IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var parameters = context.MethodInfo.GetParameters()
            .Where(p => p.ParameterType == typeof(MyRequest)).ToList();

        if (parameters.Count == 0)
            return;

    
        var reqBody = new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = new Dictionary<string, OpenApiSchema>
                        {
                            ["requestModel"] = new OpenApiSchema
                            {
                                Type = "string"
                            },
                            ["file"] = new OpenApiSchema
                            {
                                Type = "string",
                                Format = "binary"
                            }
                        },
                        Required = new HashSet<string> { "requestModel","file" }
                    }
                }
            }
        };

        operation.RequestBody = reqBody;
    }
}