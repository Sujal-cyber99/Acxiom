using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcxiomCRM.Data;
using AcxiomCRM.Models;

namespace AcxiomCRM.Controllers
{
    public class FollowUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FollowUps
        public async Task<IActionResult> Index()
        {
            return View(await _context.FollowUps.ToListAsync());
        }

        // GET: FollowUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followUp = await _context.FollowUps
                .FirstOrDefaultAsync(m => m.FollowUpId == id);
            if (followUp == null)
            {
                return NotFound();
            }

            return View(followUp);
        }

        // GET: FollowUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FollowUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FollowUpId,CustomerId,LeadId,FollowUpDate,FollowUpType,Remarks,Status,AssignedTo")] FollowUp followUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(followUp);
        }

        // GET: FollowUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followUp = await _context.FollowUps.FindAsync(id);
            if (followUp == null)
            {
                return NotFound();
            }
            return View(followUp);
        }

        // POST: FollowUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FollowUpId,CustomerId,LeadId,FollowUpDate,FollowUpType,Remarks,Status,AssignedTo")] FollowUp followUp)
        {
            if (id != followUp.FollowUpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowUpExists(followUp.FollowUpId))
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
            return View(followUp);
        }

        // GET: FollowUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var followUp = await _context.FollowUps
                .FirstOrDefaultAsync(m => m.FollowUpId == id);
            if (followUp == null)
            {
                return NotFound();
            }

            return View(followUp);
        }

        // POST: FollowUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followUp = await _context.FollowUps.FindAsync(id);
            if (followUp != null)
            {
                _context.FollowUps.Remove(followUp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowUpExists(int id)
        {
            return _context.FollowUps.Any(e => e.FollowUpId == id);
        }
    }
}
