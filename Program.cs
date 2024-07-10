using PocApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.OperationFilter<MyCustomPostFilter>();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>{
    // options.SwaggerEndpoint("openapi.json", "My API");
});

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();