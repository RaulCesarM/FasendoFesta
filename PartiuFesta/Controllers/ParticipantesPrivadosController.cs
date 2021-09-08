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
    public class ParticipantesPrivadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantesPrivadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ParticipantesPrivados.Include(p => p.FestasPrivadas);
            return View(await applicationDbContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participantePrivado = await _context.ParticipantesPrivados
                .Include(p => p.FestasPrivadas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participantePrivado == null)
            {
                return NotFound();
            }

            return View(participantePrivado);
        }

       
        public IActionResult Create()
        {
           ViewData["FestaPrivadaId"] = new SelectList(_context.FestasPrivadas, "Id", "Anfitriao");
           
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ParticipantePrivado participantePrivado)
        {
            if (ModelState.IsValid)
            {
              

                    participantePrivado.Id = Guid.NewGuid();
                    _context.Add(participantePrivado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


              


                           
               
            }
            
           
            ViewData["FestaPrivadaId"] = new SelectList(_context.FestasPrivadas, "Id", "Anfitriao", participantePrivado.FestaPrivadaId);
           

            return View(participantePrivado);
        }

       
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participantePrivado = await _context.ParticipantesPrivados.FindAsync(id);
            if (participantePrivado == null)
            {
                return NotFound();
            }
            ViewData["FestaPrivadaId"] = new SelectList(_context.FestasPrivadas, "Id", "Anfitriao", participantePrivado.FestaPrivadaId);
            return View(participantePrivado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  ParticipantePrivado participantePrivado)
        {
            if (id != participantePrivado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participantePrivado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantePrivadoExists(participantePrivado.Id))
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
            ViewData["FestaPrivadaId"] = new SelectList(_context.FestasPrivadas, "Id", "Anfitriao", participantePrivado.FestaPrivadaId);
            return View(participantePrivado);
        }

        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participantePrivado = await _context.ParticipantesPrivados
                .Include(p => p.FestasPrivadas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participantePrivado == null)
            {
                return NotFound();
            }

            return View(participantePrivado);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var participantePrivado = await _context.ParticipantesPrivados.FindAsync(id);
            _context.ParticipantesPrivados.Remove(participantePrivado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantePrivadoExists(Guid id)
        {
            return _context.ParticipantesPrivados.Any(e => e.Id == id);
        }
    }
}
