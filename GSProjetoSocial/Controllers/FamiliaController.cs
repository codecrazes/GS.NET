using GSProjetoSocial.Data;
using GSProjetoSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GSProjetoSocial.Controllers
{
    public class FamiliaController : Controller
    {
        private readonly AppDbContext _context;

        public FamiliaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var familias = await _context.FormulariosFamilia
                                .Include(f => f.Endereco)
                                .ToListAsync();
            return View(familias);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var familia = await _context.FormulariosFamilia
                                .Include(f => f.Endereco)
                                .FirstOrDefaultAsync(f => f.Id == id.Value);
            if (familia == null) return NotFound();

            return View(familia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormularioFamilia model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var existente = await _context.FormulariosFamilia.FindAsync(id.Value);
            if (existente == null) return NotFound();

            return View(existente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FormularioFamilia model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.FormulariosFamilia.AnyAsync(f => f.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var familia = await _context.FormulariosFamilia
                                .Include(f => f.Endereco)
                                .FirstOrDefaultAsync(f => f.Id == id.Value);
            if (familia == null) return NotFound();

            return View(familia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var existente = await _context.FormulariosFamilia.FindAsync(id);
            if (existente == null) return NotFound();

            _context.FormulariosFamilia.Remove(existente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
