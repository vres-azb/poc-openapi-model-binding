using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace PocApi;

public class MyCustomModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var request = bindingContext.HttpContext.Request;

        if (!request.ContentType.StartsWith("multipart/form-data", StringComparison.OrdinalIgnoreCase))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        var form = await request.ReadFormAsync();
        var json = form["requestModel"].FirstOrDefault();

        if (json == null)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        var requestModel = JsonSerializer.Deserialize<MyRequest>(json);
        var file = form.Files.GetFile("file");

        var resultModel = new MyRequest
        {
            Id = requestModel.Id,
            Name = requestModel.Name,
            File = file
        };

        bindingContext.Result = ModelBindingResult.Success(resultModel);
    }
}
