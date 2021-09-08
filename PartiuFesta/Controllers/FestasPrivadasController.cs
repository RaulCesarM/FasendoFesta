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
    public class FestasPrivadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FestasPrivadasController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            return View(await _context.FestasPrivadas.ToListAsync());
        }

        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festaPrivada = await _context.FestasPrivadas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (festaPrivada == null)
            {
                return NotFound();
            }

            return View(festaPrivada);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( FestaPrivada festaPrivada)
        {
            if (ModelState.IsValid)
            {
                festaPrivada.Id = Guid.NewGuid();
                _context.Add(festaPrivada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(festaPrivada);
        }

       
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festaPrivada = await _context.FestasPrivadas.FindAsync(id);
            if (festaPrivada == null)
            {
                return NotFound();
            }
            return View(festaPrivada);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FestaPrivada festaPrivada)
        {
            if (id != festaPrivada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(festaPrivada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FestaPrivadaExists(festaPrivada.Id))
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
            return View(festaPrivada);
        }

      
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festaPrivada = await _context.FestasPrivadas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (festaPrivada == null)
            {
                return NotFound();
            }

            return View(festaPrivada);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var festaPrivada = await _context.FestasPrivadas.FindAsync(id);
            _context.FestasPrivadas.Remove(festaPrivada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FestaPrivadaExists(Guid id)
        {
            return _context.FestasPrivadas.Any(e => e.Id == id);
        }
    }
}
