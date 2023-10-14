using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Viamatica.Data;
using Viamatica.Shared;

namespace Viamatica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradosController : ControllerBase
    {
        private readonly ViamaticaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public AseguradosController(ViamaticaDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }

        [HttpGet]
        public async Task<IEnumerable<Asegurado>> GetAsegurado()
        {
            return await _context.Asegurados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAseguradoById(int id)
        {
            var asegurado = await _context.Asegurados.FirstOrDefaultAsync(c => c.IdAsegurado == id);

            if (asegurado == null)
            {
                return NotFound();
            }

            return Ok(asegurado);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsegurado(Asegurado asegurado)
        {
            if (asegurado == null)
            {
                return BadRequest();
            }
            await _context.Asegurados.AddAsync(asegurado);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostAsegurado", asegurado.IdAsegurado, asegurado);
        }


        [HttpPut]
        public async Task<IActionResult> PutAsegurado(Asegurado asegurado)
        {
            if (asegurado == null)
            {
                return BadRequest();
            }
            _context.Asegurados.Update(asegurado);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsegurado(int id)
        {
            var asegurado = await _context.Asegurados.FirstOrDefaultAsync(c => c.IdAsegurado == id);
            if (asegurado == null)
            {
                return NotFound();
            }

            _context.Asegurados.Remove(asegurado);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        [Route("UploadFile")]
        public IActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Files", "Resources");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
