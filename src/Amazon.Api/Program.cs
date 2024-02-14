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

    app.Use(async (context, next) =>
    {
        try
        {
            await next(context);
        }
        catch
        {
            context.Response.StatusCode = 500;
        }
    });

    app.MapControllers();

    await app.RunAsync();
}
