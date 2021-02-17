using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MPA.Data;
using Proiect_MPA.Models;

namespace Proiect_MPA.Controllers
{
    public class GameShopsController : Controller
    {
        private readonly MagazinContext _context;

        public GameShopsController(MagazinContext context)
        {
            _context = context;
        }

        // GET: GameShops
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.GameShops.ToListAsync());
        
        }

        // GET: GameShops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameshop = await _context.GameShops
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gameshop == null)
            {
                return NotFound();
            }

            return View(gameshop);
        }

        // GET: GameShops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameShops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Location,PriceRange")] GameShop gameshop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameshop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameshop);
        }

        // GET: GameShops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameshop = await _context.GameShops.FindAsync(id);
            if (gameshop == null)
            {
                return NotFound();
            }
            return View(gameshop);
        }

        // POST: GameShops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Location,PriceRange")] GameShop gameshop)
        {
            if (id != gameshop.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameshop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gameshopExists(gameshop.ID))
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
            return View(gameshop);
        }

        // GET: GameShops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameshop = await _context.GameShops
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gameshop == null)
            {
                return NotFound();
            }

            return View(gameshop);
        }

        // POST: GameShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameshop = await _context.GameShops.FindAsync(id);
            _context.GameShops.Remove(gameshop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gameshopExists(int id)
        {
            return _context.GameShops.Any(e => e.ID == id);
        }
    }
}
