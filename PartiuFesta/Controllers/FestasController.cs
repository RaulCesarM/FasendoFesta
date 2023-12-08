using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartiuFesta.Data.Context;
using PartiuFesta.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PartiuFesta.Controllers
{
    public class FestasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FestasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Festas.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festa = await _context.Festas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (festa == null)
            {
                return NotFound();
            }

            return View(festa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome_Da_Festa,Anfitriao,TipoFesta,Cidade,Bairro,Rua,Numero,DataDaFesta,Link_Do_Google_Maps,Id")] Festa festa)
        {
            if (ModelState.IsValid)
            {
                festa.Id = Guid.NewGuid();
                _context.Add(festa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(festa);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festa = await _context.Festas.FindAsync(id);
            if (festa == null)
            {
                return NotFound();
            }
            return View(festa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome_Da_Festa,Anfitriao,TipoFesta,Cidade,Bairro,Rua,Numero,DataDaFesta,Link_Do_Google_Maps,Id")] Festa festa)
        {
            if (id != festa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(festa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FestaExists(festa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(festa);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festa = await _context.Festas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (festa == null)
            {
                return NotFound();
            }

            return View(festa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var festa = await _context.Festas.FindAsync(id);
            _context.Festas.Remove(festa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FestaExists(Guid id)
        {
            return _context.Festas.Any(e => e.Id == id);
        }
    }
}