using Amazon.Infrastructure.Common.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddInfrastructure(builder.Configuration);
}

WebApplication app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

    app.MapControllers();

    await app.RunAsync();
}
