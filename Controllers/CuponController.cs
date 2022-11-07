using ApiConEFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponController :ControllerBase
    {
        private readonly DataContext _context;

        public CuponController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cupon>>> Get()
        {
            return Ok(await _context.Cupones.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cupon>> Get(int id)
        {
            var cupon = await _context.Cupones.FindAsync(id);
            if (cupon == null)
                return BadRequest("Cupon no encontrado");
            return Ok(cupon);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cupon>>> AddCupon( Cupon request)
        {
            _context.Cupones.Add(request);
            await _context.SaveChangesAsync();
            return Ok(await _context.Cupones.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Cupon>>> UpdateCupon(Cupon request)
        {
            var dbCupon = await _context.Cupones.FindAsync(request.Id);
            if (dbCupon == null)
                return BadRequest("Cupon no encontrado");

            dbCupon.D_Nombre = request.D_Nombre;
            dbCupon.D_Cupon = request.D_Cupon;
            dbCupon.Usados = request.Usados;
            dbCupon.Propietario = request.Propietario;
            await _context.SaveChangesAsync();

            return Ok(await _context.Cupones.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cupon>>> DeleteCupon(int id)
        {
            var cupon = await _context.Cupones.FindAsync(id);
            if (cupon == null)
                return BadRequest("Cupon no encontrado");

            _context.Cupones.Remove(cupon);
            await _context.SaveChangesAsync();

            return Ok( await _context.Cupones.ToListAsync());
        }
    }
}