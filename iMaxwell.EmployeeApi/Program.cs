using iMaxwell.EmployeeApi.StartupConfig;

var builder = WebApplication.CreateBuilder(args);

DependencyInjectionExtensions.AddStandardServices(builder);
DependencyInjectionExtensions.AddCustomServices(builder);
DependencyInjectionExtensions.AddVersioning(builder);
DependencyInjectionExtensions.AddSecurity(builder);
DependencyInjectionExtensions.AddHealth(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opts.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
