using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioNW.Data;
using ServicioNW.Models;

namespace ServicioNW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly NWContext _contexto;
        public ProductosController(NWContext contexto) 
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> TraerTodos()
        {
            var lista = await (from p in _contexto.Products
                               select p).ToListAsync();
            return lista;
        }
    }
}
