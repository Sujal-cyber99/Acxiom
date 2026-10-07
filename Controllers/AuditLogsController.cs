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
    public class AuditLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuditLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuditLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuditLogs.ToListAsync());
        }

        // GET: AuditLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditLog = await _context.AuditLogs
                .FirstOrDefaultAsync(m => m.AuditLogId == id);
            if (auditLog == null)
            {
                return NotFound();
            }

            return View(auditLog);
        }

        // GET: AuditLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuditLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditLogId,UserId,Action,EntityName,RecordId,OldValue,NewValue,CreatedDate,IpAddress")] AuditLog auditLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auditLog);
        }

        // GET: AuditLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditLog = await _context.AuditLogs.FindAsync(id);
            if (auditLog == null)
            {
                return NotFound();
            }
            return View(auditLog);
        }

        // POST: AuditLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuditLogId,UserId,Action,EntityName,RecordId,OldValue,NewValue,CreatedDate,IpAddress")] AuditLog auditLog)
        {
            if (id != auditLog.AuditLogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditLogExists(auditLog.AuditLogId))
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
            return View(auditLog);
        }

        // GET: AuditLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditLog = await _context.AuditLogs
                .FirstOrDefaultAsync(m => m.AuditLogId == id);
            if (auditLog == null)
            {
                return NotFound();
            }

            return View(auditLog);
        }

        // POST: AuditLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auditLog = await _context.AuditLogs.FindAsync(id);
            if (auditLog != null)
            {
                _context.AuditLogs.Remove(auditLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditLogExists(int id)
        {
            return _context.AuditLogs.Any(e => e.AuditLogId == id);
        }
    }
}
