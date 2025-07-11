using HR_System.Core.Entities;
using HR_System.Core.Services.Contract;
using HR_System.Core.UnitsOfWork.Contract;
using HR_System.Repos.HrCon;
using HR_System.Repos.UnitsOfWork;
using HR_System.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Stop default filtration before actions. 
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(
                options => options.SuppressModelStateInvalidFilter = true);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register DBcontext
            builder.Services.AddDbContext<HrContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
            });

            // Register Identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<HrContext>();
            
            // Register Unit Of Work
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // Register Services
            builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            // Register AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
        }
    }
}
