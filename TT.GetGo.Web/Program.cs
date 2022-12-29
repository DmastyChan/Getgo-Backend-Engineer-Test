using FluentValidation;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Logging;
using TT.GetGo.Services.Records;
using TT.GetGo.Web.Helper;
using TT.GetGo.Web.Mapping;
using TT.GetGo.Web.Models;
using TT.GetGo.Web.Services;
using TT.GetGo.Web.Validator;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;

    services.AddDbContext<GetGoDBContext>();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    
    // configure DI for application services
    services.AddScoped<IWebHelper, WebHelper>();
    services.AddScoped<ILogServices, LogServices>();
    services.AddScoped<ICarServices, CarServices>();
    services.AddScoped<ILocationServices, LocationServices>();
    services.AddScoped<IRecordServices, RecordServices>();
    services.AddScoped<ICarWorkflow, CarWorkflow>();

    // Register validator with service provider (or use one of the automatic registration methods)
    services.AddScoped<IValidator<UserRequest>, UserRequestValidator>();
    services.AddScoped<IValidator<BookRequest>, BookRequestValidator>();
    services.AddScoped<IValidator<SearchRequest>, SearchRequestValidator>();
    services.AddScoped<IValidator<ReachCarRequest>, ReachCarRequestValidator>();
}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

app.Run();
