using Back_End1_Aura.Data;
using Back_End1_Aura.Repository;
using Back_End1_Aura.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Entity Framework Core services.
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository and service
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "YourAPI", Version = "v1" });
});

var app = builder.Build();

// Enable detailed errors in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();