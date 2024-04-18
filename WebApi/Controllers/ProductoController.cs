using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<Producto> _contextGenerico;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> contextGenerico, IMapper mapper)
        {
            _contextGenerico = contextGenerico;
            _mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult Index()
        //    {
        //        return Content("Bienvenido Jose");
        //    }



        [HttpGet]
        public async Task<ActionResult<Pagination<ProductoDto>>> GetProductos([FromQuery] ProductoSpecificationParams productoParams)
        {

            // tratamiento de los que entra como parametro
            var spec = new ProductoSpecification(productoParams);
            
            // realizar la consulta con los parametros 
            var resultado = await _contextGenerico.GetAllWithSpec(spec);

            // total de productos 
            var specCount = new ProductoForCountingSpecification(productoParams);
            var totalProductos = await _contextGenerico.CountAsync(specCount);

            //cantidad de paginas   // necesitas rendondear porque siempre debe ser entero al maximo superior 1.7 => rendodeo a 2
            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / productoParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);


            // cuando se trata de relaciones entre clases, debo trabajar el mapper y los spect 

            var data = _mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(resultado);


            return Ok(new Pagination<ProductoDto>
            {
                Count = totalProductos,
                Data = data,
                PageCount = totalPages,
                PageIndex = productoParams.PageIndex,
                PageSize = productoParams.PageSize
            }
            );


        }







    }
}
