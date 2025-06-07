using GSProjetoSocial.Data;
using GSProjetoSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GSProjetoSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoApoioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PontoApoioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pontos = await _context.PontosApoio
                .Include(p => p.Endereco)
                .ToListAsync();
            return Ok(pontos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ponto = await _context.PontosApoio
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (ponto == null) return NotFound();
            return Ok(ponto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PontoApoio model)
        {
            _context.PontosApoio.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PontoApoio model)
        {
            var existente = await _context.PontosApoio.FindAsync(id);
            if (existente == null) return NotFound();

            _context.Entry(existente).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existente = await _context.PontosApoio.FindAsync(id);
            if (existente == null) return NotFound();

            _context.PontosApoio.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
