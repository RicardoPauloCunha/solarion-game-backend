using SolarionGame.Api.Configurations.Middlewares;
using SolarionGame.Api.Configurations.Startups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

// Add custom services
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomAuthorization();
builder.Services.AddCustomBehavior();
builder.Services.AddCustomDependencyInjection(builder.Configuration);
builder.Services.AddCustomEntityFramework(builder.Configuration);
builder.Services.AddCustomMail(builder.Configuration);
builder.Services.AddCustomQuery();
builder.Services.AddCustomRepository();
builder.Services.AddCustomSetting(builder.Configuration);
builder.Services.AddCustomSwagger();
builder.Services.AddCustomValidatorLanguage();
builder.Services.AddCustomValidator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ControlPec");
    c.DocumentTitle = "API ControlPec";
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();