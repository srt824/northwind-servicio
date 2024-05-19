using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioNW.Data;
using ServicioNW.Models;
using AutoMapper;

namespace ServicioNW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTO_ProductosController : ControllerBase
    {
        private readonly NWContext _contexto;
        private readonly IMapper _mapper;

        public DTO_ProductosController(NWContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<DTO_Productos>> Traer()
        {
            var lista = (from p in _contexto.Products
                        select p).ToList();
            var DTO = _mapper.Map<List<DTO_Productos>>(lista);
            return DTO.ToList();
        }
    }
}
