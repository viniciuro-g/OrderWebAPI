using BudgetWebAPI.Data;
using BudgetWebAPI.Models.Enum;
using BudgetWebAPI.Repositories.Implementation;
using BudgetWebAPI.Repositories.Interfaces;
using BudgetWebAPI.Services.Implementation;
using BudgetWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrderWebAPI.Models.Entities;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = null 
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyFrontend", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));


builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();

    if (!context.Customers.Any())
    {
        context.Customers.AddRange(
            new Customer
            {
                Name = "Vinicius Rodrigues",
                Email = "Vini@example.com",
                Address = "Rua das Flores, 123"
            },
            new Customer
            {
                Name = "Metheus Henrique",
                Email = "matheus@example.com",
                Address = "Avenida Central, 456"
            },
            new Customer
            {
                Name = "Ronaldo",
                Email = "Ronaldo@example.com",
                Address = "Praça da Matriz, 789"
            }
        );
        context.SaveChanges();

        if( !context.Orders.Any())
        {
            context.Orders.AddRange(
                new Order
                {
                    CustomerId = 1,
                    Description = "Desenvolvimento de website e blog corporativo.",
                    Status = Status.Draft,
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Description = "Criação de Layout", Quantity = 1, UnitPrice = 1200.00m },
                        new OrderItem { Description = "Desenvolvimento de Páginas (x5)", Quantity = 5, UnitPrice = 350.00m },
                        new OrderItem { Description = "Configuração de SEO inicial", Quantity = 1, UnitPrice = 500.00m }
                    }
                },
                new Order
                {
                    CustomerId = 2,
                    Description = "Contrato de manutenção de TI.",
                    Status = Status.Draft,
                    Items = new List<OrderItem>
                    {
                    new OrderItem { Description = "Suporte Técnico Remoto (banco de 10 horas)", Quantity = 10, UnitPrice = 120.00m }
                    }
                },
                new Order
                {
                    CustomerId = 3, 
                    Description = "Compra de equipamentos.",
                    Status = Status.Pending,
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Description = "Notebook Dell Vostro", Quantity = 2, UnitPrice = 4500.00m },
                        new OrderItem { Description = "Monitor UltraWide 29 polegadas", Quantity = 2, UnitPrice = 1100.00m }
                    }
                }
            );
            context.SaveChanges();

        }
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Budget API V1");

        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting(); 

app.UseCors("AllowMyFrontend"); 

app.UseAuthorization();

app.MapControllers(); 

app.Run();