using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartiuFesta.Data.Context;
using PartiuFesta.Models;

namespace PartiuFesta.Controllers
{
    public class FestasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FestasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Festas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Festas.ToListAsync());
        }

        // GET: Festas/Details/5
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

        // GET: Festas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Festas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Festas/Edit/5
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

        // POST: Festas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Festas/Delete/5
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

        // POST: Festas/Delete/5
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
