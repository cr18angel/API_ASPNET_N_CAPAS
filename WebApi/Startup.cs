using BusinessLogic.Data;
using BusinessLogic.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using WebApi.Dtos;
using Core.Interfaces;
namespace WebApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        //INICIO DE SERVICIOS  ------------------------------------------------------------------------------------------------ 

        public void ConfigureServices(IServiceCollection services)
        {

            //configuracion ENTITY FRAME  
            services.AddDbContext<MarcketDbContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Configuracion de Automaper 
            services.AddAutoMapper(typeof(MappingProfiles));


            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));



            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

        }


        // FIN DE SERVICIOS 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });
        }


    }
}
