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
    public class MOperatorsController : Controller
    {
        private readonly StackitDbContext _context;

        public MOperatorsController(StackitDbContext context)
        {
            _context = context;
        }

        // GET: MOperators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Operators.ToListAsync());
        }

        // GET: MOperators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mOperator = await _context.Operators
                .FirstOrDefaultAsync(m => m.MOperatorId == id);
            if (mOperator == null)
            {
                return NotFound();
            }

            return View(mOperator);
        }

        // GET: MOperators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MOperators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MOperatorId,Name,Info")] MOperator mOperator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mOperator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mOperator);
        }

        // GET: MOperators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mOperator = await _context.Operators.FindAsync(id);
            if (mOperator == null)
            {
                return NotFound();
            }
            return View(mOperator);
        }

        // POST: MOperators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MOperatorId,Name,Info")] MOperator mOperator)
        {
            if (id != mOperator.MOperatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mOperator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MOperatorExists(mOperator.MOperatorId))
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
            return View(mOperator);
        }

        // GET: MOperators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mOperator = await _context.Operators
                .FirstOrDefaultAsync(m => m.MOperatorId == id);
            if (mOperator == null)
            {
                return NotFound();
            }

            return View(mOperator);
        }

        // POST: MOperators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mOperator = await _context.Operators.FindAsync(id);
            _context.Operators.Remove(mOperator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MOperatorExists(int id)
        {
            return _context.Operators.Any(e => e.MOperatorId == id);
        }
    }
}
