using GSProjetoSocial.Data;
using GSProjetoSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GSProjetoSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormularioFamiliaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FormularioFamiliaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var familias = await _context.FormulariosFamilia
                                .Include(f => f.Endereco)
                                .ToListAsync();
            return Ok(familias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var familia = await _context.FormulariosFamilia
                                .Include(f => f.Endereco)
                                .FirstOrDefaultAsync(f => f.Id == id);
            if (familia == null) return NotFound();
            return Ok(familia);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormularioFamilia model)
        {
            _context.FormulariosFamilia.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormularioFamilia model)
        {
            var existente = await _context.FormulariosFamilia.FindAsync(id);
            if (existente == null) return NotFound();

            _context.Entry(existente).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existente = await _context.FormulariosFamilia.FindAsync(id);
            if (existente == null) return NotFound();

            _context.FormulariosFamilia.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
