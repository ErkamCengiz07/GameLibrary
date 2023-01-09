using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameLibrary.Models;
using Microsoft.AspNetCore.Authorization;

namespace GameLibrary.Controllers
{
    [Authorize]
    public class GameSaleController : Controller
    {
        private readonly GameLibraryDbContext _context;

        public GameSaleController(GameLibraryDbContext context)
        {
            _context = context;
        }

        // GET: GameSale
        public async Task<IActionResult> Index()
        {
              return _context.GameSales != null ? 
                          View(await _context.GameSales.ToListAsync()) :
                          Problem("Entity set 'GameLibraryDbContext.GameSale'  is null.");
        }

        // GET: GameSale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameSales == null)
            {
                return NotFound();
            }

            var gameSale = await _context.GameSales
                .FirstOrDefaultAsync(m => m.GameSaleId == id);
            if (gameSale == null)
            {
                return NotFound();
            }

            return View(gameSale);
        }

        // GET: GameSale/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameSale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameSaleId,CustomerId,GameId,DateOfSell")] GameSale gameSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameSale);
        }

        // GET: GameSale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameSales == null)
            {
                return NotFound();
            }

            var gameSale = await _context.GameSales.FindAsync(id);
            if (gameSale == null)
            {
                return NotFound();
            }
            return View(gameSale);
        }

        // POST: GameSale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameSaleId,CustomerId,GameId,DateOfSell")] GameSale gameSale)
        {
            if (id != gameSale.GameSaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameSaleExists(gameSale.GameSaleId))
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
            return View(gameSale);
        }

        // GET: GameSale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameSales == null)
            {
                return NotFound();
            }

            var gameSale = await _context.GameSales
                .FirstOrDefaultAsync(m => m.GameSaleId == id);
            if (gameSale == null)
            {
                return NotFound();
            }

            return View(gameSale);
        }

        // POST: GameSale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameSales == null)
            {
                return Problem("Entity set 'GameLibraryDbContext.GameSale'  is null.");
            }
            var gameSale = await _context.GameSales.FindAsync(id);
            if (gameSale != null)
            {
                _context.GameSales.Remove(gameSale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameSaleExists(int id)
        {
          return (_context.GameSales?.Any(e => e.GameSaleId == id)).GetValueOrDefault();
        }
    }
}
