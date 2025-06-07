using GSProjetoSocial.Data;
using GSProjetoSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GSProjetoSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Relatos.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Relatos.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Relato model)
        {
            _context.Relatos.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Relato model)
        {
            var existente = await _context.Relatos.FindAsync(id);
            if (existente == null) return NotFound();

            _context.Entry(existente).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existente = await _context.Relatos.FindAsync(id);
            if (existente == null) return NotFound();

            _context.Relatos.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
