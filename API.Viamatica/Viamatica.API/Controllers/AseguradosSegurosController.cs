using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viamatica.Data;
using Viamatica.Shared;

namespace Viamatica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradosSegurosController : ControllerBase
    {
        private readonly ViamaticaDbContext _context;

        public AseguradosSegurosController(ViamaticaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AseguradoSeguro>> GetAseguradoSeguro()
        {
            return await _context.AseguradosSeguros.Include(a => a.Asegurado).Include(b => b.Seguro).ToListAsync();
        }

        [HttpGet("ConsultarByAll")]
        public async Task<IEnumerable<AseguradoSeguro>> GetAseguradoSeguroByAll()
        {
            return await _context.AseguradosSeguros.Include(a => a.Asegurado).Include(b => b.Seguro).ToListAsync();
        }


        [HttpGet("ConsultarByCedula")]
        public async Task<IEnumerable<AseguradoSeguro>> GetAseguradoSeguroByCedula(string cedula)
        {
            return await _context.AseguradosSeguros.Include(a => a.Asegurado).Include(b => b.Seguro).Where(c => c.Asegurado.Cedula == cedula).ToListAsync();
        }

        [HttpGet("ConsultarByCodigo")]
        public async Task<IEnumerable<AseguradoSeguro>> GetAseguradoSeguroByCodigo(string codigo)
        {
            return await _context.AseguradosSeguros.Include(a => a.Seguro).Include(b => b.Asegurado).Where(c => c.Seguro.Codigo == codigo).ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> PostAseguradoSeguro(AseguradoSeguro aseguradoSeguro)
        {
            if (aseguradoSeguro == null)
            {
                return BadRequest();
            }
            await _context.AseguradosSeguros.AddAsync(aseguradoSeguro);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostAseguradoSeguro", aseguradoSeguro);
        }

        

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAseguradoSeguro(int id)
        {
            var aseguradoSeguro = await _context.AseguradosSeguros.FirstOrDefaultAsync(c => c.Id == id);

            if (aseguradoSeguro == null)
            {
                return NotFound();
            }

            _context.AseguradosSeguros.Remove(aseguradoSeguro);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
