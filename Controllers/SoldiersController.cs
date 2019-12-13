using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QinMilitary.Data;
using QinMilitary.Models;

namespace QinMilitary.Controllers
{
    public class SoldiersController : Controller
    {
        private readonly QMContext _context;

        public SoldiersController(QMContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Soldiers
        public async Task<IActionResult> Index()
        {
            var qMContext = _context.Soldiers.Include(s => s.Unit);
            return View(await qMContext.ToListAsync());
        }

        // GET: Soldiers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldier = await _context.Soldiers
                .Include(s => s.Unit)
                .FirstOrDefaultAsync(m => m.SoldierID == id);
            if (soldier == null)
            {
                return NotFound();
            }

            return View(soldier);
        }

        [Authorize(Roles = "Admin")]
        // GET: Soldiers/Create
        public IActionResult Create()
        {
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID");
            return View();
        }

        // POST: Soldiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoldierID,LastName,FirstName,Status,Age,Birthplace,UnitID")] Soldier soldier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soldier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", soldier.UnitID);
            return View(soldier);
        }

        // GET: Soldiers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldier = await _context.Soldiers.FindAsync(id);
            if (soldier == null)
            {
                return NotFound();
            }
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", soldier.UnitID);
            return View(soldier);
        }

        // POST: Soldiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoldierID,LastName,FirstName,Status,Age,Birthplace,UnitID")] Soldier soldier)
        {
            if (id != soldier.SoldierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soldier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoldierExists(soldier.SoldierID))
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
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", soldier.UnitID);
            return View(soldier);
        }

        // GET: Soldiers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldier = await _context.Soldiers
                .Include(s => s.Unit)
                .FirstOrDefaultAsync(m => m.SoldierID == id);
            if (soldier == null)
            {
                return NotFound();
            }

            return View(soldier);
        }

        // POST: Soldiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soldier = await _context.Soldiers.FindAsync(id);
            _context.Soldiers.Remove(soldier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoldierExists(int id)
        {
            return _context.Soldiers.Any(e => e.SoldierID == id);
        }
    }
}
