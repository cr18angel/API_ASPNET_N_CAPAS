using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class MarcketDbContextData
    {
        public static async Task CargarDataAsync(MarcketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                if (!context.Productos.Any())
                {
                    var productoData = File.ReadAllText("../BusinessLogic/CargarData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productoData);

                    foreach (var producto in productos)
                    {
                        context.Productos.Add(producto);
                    }

                    await context.SaveChangesAsync();
                }


            }
            catch (Exception e)
            {

                var logger = loggerFactory.CreateLogger<MarcketDbContextData>();
                logger.LogError(e.Message);
            }

        }

    }
}
