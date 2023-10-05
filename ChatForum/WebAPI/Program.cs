using DataAccess.Context;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Services.IService;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions => {
    apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ISignUpService, SignUpService>();
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<IUserVerificationService, UserVerificationService>();
builder.Services.AddScoped<ICommentSubmissionService, CommentSubmissionService>();
builder.Services.AddScoped<ICommentViewerService, CommentViewerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
