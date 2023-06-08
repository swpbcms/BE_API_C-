using BCMS.Interface;
using BCMS.Models;
using BCMS.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => 
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategory,CategoryService>();
builder.Services.AddScoped<IMember, MemberService>();
builder.Services.AddScoped<ILike, LikeService>();
builder.Services.AddScoped<IComment, CommentService>();
builder.Services.AddScoped<IJoinEvent, JoinEventService>();
builder.Services.AddScoped<IPost, PostService>();
builder.Services.AddScoped<IReportType, ReportTypeService>();
builder.Services.AddScoped<IProcessEvent, ProcessEventService>();
builder.Services.AddScoped(typeof(BCMSContext));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddEndpointsApiExplorer();


app.UseCors(x => x.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
