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
    public class ParticipantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Participantes.Include(p => p.Festa);
            return View(await applicationDbContext.ToListAsync());
        }

       
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .Include(p => p.Festa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

      
        public IActionResult Create()
        {
            ViewData["FestaId"] = new SelectList(_context.Festas, "Id", "Anfitriao");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Participante participante)
        {
            if (ModelState.IsValid)
            {
                participante.Id = Guid.NewGuid();
                _context.Add(participante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FestaId"] = new SelectList(_context.Festas, "Id", "Anfitriao", participante.FestaId);
            return View(participante);
        }

      
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            ViewData["FestaId"] = new SelectList(_context.Festas, "Id", "Anfitriao", participante.FestaId);
            return View(participante);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Participante participante)
        {
            if (id != participante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipanteExists(participante.Id))
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
            ViewData["FestaId"] = new SelectList(_context.Festas, "Id", "Anfitriao", participante.FestaId);
            return View(participante);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participante = await _context.Participantes
                .Include(p => p.Festa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }

            return View(participante);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipanteExists(Guid id)
        {
            return _context.Participantes.Any(e => e.Id == id);
        }
    }
}
