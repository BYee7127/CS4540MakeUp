using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QinMilitary.Data;
using QinMilitary.Models;

namespace QinMilitary.Controllers
{
    [Authorize(Roles = "High Commander")]
    public class HighController : Controller
    {
        private readonly QMContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HighController(QMContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: High
        public async Task<IActionResult> Index()
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            string userID = user.Id;

            var soldiers = _context.Soldiers.Where(c => c.CO.UserID == userID).OrderBy(c => c.FullName);
            if (soldiers == null)
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });

            return View("/Views/Soldiers/Index.cshtml", await soldiers.ToListAsync());
        }

        public async Task<IActionResult> HighUnit()
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            string userID = user.Id;

            var units = _context.Units.Where(c => c.Admin.UserID == userID);
            if(units == null)
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });

            return View(await units.ToListAsync());
        }

        // GET: High/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officer = await _context.Officers
                .FirstOrDefaultAsync(m => m.OfficerID == id);
            if (officer == null)
            {
                return NotFound();
            }

            return View(officer);
        }

        // GET: High/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: High/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfficerID,UserID,LastName,FirstName,Email,Years,Status,Rank")] Officer officer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officer);
        }

        // GET: High/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officer = await _context.Officers.FindAsync(id);
            if (officer == null)
            {
                return NotFound();
            }
            return View(officer);
        }

        // POST: High/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfficerID,UserID,LastName,FirstName,Email,Years,Status,Rank")] Officer officer)
        {
            if (id != officer.OfficerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficerExists(officer.OfficerID))
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
            return View(officer);
        }

        // GET: High/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officer = await _context.Officers
                .FirstOrDefaultAsync(m => m.OfficerID == id);
            if (officer == null)
            {
                return NotFound();
            }

            return View(officer);
        }

        // POST: High/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officer = await _context.Officers.FindAsync(id);
            _context.Officers.Remove(officer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficerExists(int id)
        {
            return _context.Officers.Any(e => e.OfficerID == id);
        }
    }
}
