using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stackit.Data;
using Stackit.Models;

namespace Stackit.Controllers
{
    public class MachineOperatorsController : Controller
    {
        private readonly StackitDbContext _context;

        public MachineOperatorsController(StackitDbContext context)
        {
            _context = context;
        }

        // GET: MachineOperators
        public async Task<IActionResult> Index()
        {
            var stackitDbContext = _context.MachineOperator.Include(m => m.Machine).Include(m => m.Operator);
            return View(await stackitDbContext.ToListAsync());
        }

        // GET: MachineOperators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineOperator = await _context.MachineOperator
                .Include(m => m.Machine)
                .Include(m => m.Operator)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (machineOperator == null)
            {
                return NotFound();
            }

            return View(machineOperator);
        }

        // GET: MachineOperators/Create
        public IActionResult Create()
        {
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId");
            ViewData["MOperatorId"] = new SelectList(_context.Operators, "MOperatorId", "MOperatorId");
            return View();
        }

        // POST: MachineOperators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MachineId,MOperatorId")] MachineOperator machineOperator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineOperator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId", machineOperator.MachineId);
            ViewData["MOperatorId"] = new SelectList(_context.Operators, "MOperatorId", "MOperatorId", machineOperator.MOperatorId);
            return View(machineOperator);
        }

        // GET: MachineOperators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineOperator = await _context.MachineOperator.FindAsync(id);
            if (machineOperator == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId", machineOperator.MachineId);
            ViewData["MOperatorId"] = new SelectList(_context.Operators, "MOperatorId", "MOperatorId", machineOperator.MOperatorId);
            return View(machineOperator);
        }

        // POST: MachineOperators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MachineId,MOperatorId")] MachineOperator machineOperator)
        {
            if (id != machineOperator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineOperator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineOperatorExists(machineOperator.ID))
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
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineId", machineOperator.MachineId);
            ViewData["MOperatorId"] = new SelectList(_context.Operators, "MOperatorId", "MOperatorId", machineOperator.MOperatorId);
            return View(machineOperator);
        }

        // GET: MachineOperators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineOperator = await _context.MachineOperator
                .Include(m => m.Machine)
                .Include(m => m.Operator)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (machineOperator == null)
            {
                return NotFound();
            }

            return View(machineOperator);
        }

        // POST: MachineOperators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineOperator = await _context.MachineOperator.FindAsync(id);
            _context.MachineOperator.Remove(machineOperator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineOperatorExists(int id)
        {
            return _context.MachineOperator.Any(e => e.ID == id);
        }
    }
}
