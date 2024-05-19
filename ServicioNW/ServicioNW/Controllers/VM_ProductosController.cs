using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioNW.Data;
using ServicioNW.Models;

namespace ServicioNW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VM_ProductosController : ControllerBase
    {
        private readonly NWContext _contexto;
        public VM_ProductosController(NWContext contexto)
        {
            _contexto = contexto;
        }

        // AHORA CAMBIA CON RESPECTO A LOS DTO
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<VM_Productos>>> Traer()
        {
            var productos = _contexto.Products.Select
                (p => new VM_Productos()
                {
                    Id=p.ProductID,
                    Categoria=p.Category.CategoryName,
                    Proveedor=p.Supplier.CompanyName,
                    Nombre=p.ProductName,
                    Precio=p.UnitPrice

                }).ToListAsync();
            return await productos;
        }
    }
}
