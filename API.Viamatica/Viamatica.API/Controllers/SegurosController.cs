using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viamatica.Data;
using Viamatica.Shared;

namespace Viamatica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly ViamaticaDbContext _context;

        public SegurosController(ViamaticaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Seguro>> GetSeguro()
        {
            var seguros = await _context.Seguros.ToListAsync();
            return seguros;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeguroById(int id)
        {
            var seguro = await _context.Seguros.FirstOrDefaultAsync(c => c.IdSeguro == id);

            if (seguro == null)
            {
                return NotFound();
            }

            return Ok(seguro);
        }

        [HttpPost]
        public async Task<IActionResult> PostSeguro(Seguro seguro)
        {
            if (seguro == null)
            {
                return BadRequest();
            }
            await _context.Seguros.AddAsync(seguro);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostSeguro", seguro.IdSeguro, seguro);
        }


        [HttpPut]
        public async Task<IActionResult> PutSeguro(Seguro seguro)
        {
            if (seguro == null)
            {
                return BadRequest();
            }
            _context.Seguros.Update(seguro);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeguro(int id)
        {
            var seguro = await _context.Seguros.FirstOrDefaultAsync(c => c.IdSeguro == id);
            if (seguro == null)
            {
                return NotFound();
            }

            _context.Seguros.Remove(seguro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }   
}
