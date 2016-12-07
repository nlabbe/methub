using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Methub.Data;
using Methub.Models;

namespace methub.Controllers
{
    public class ConstraintsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConstraintsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Constraints
        public async Task<IActionResult> Index()
        {
            return View(await _context.Constraints.ToListAsync());
        }

        // GET: Constraints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constraint = await _context.Constraints.SingleOrDefaultAsync(m => m.id == id);
            if (constraint == null)
            {
                return NotFound();
            }

            return View(constraint);
        }

        // GET: Constraints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Constraints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,comment,constraint_type,end_date,frequency,max_time,min_time,priority,rol,start_date")] Constraint constraint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constraint);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(constraint);
        }

        // GET: Constraints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constraint = await _context.Constraints.SingleOrDefaultAsync(m => m.id == id);
            if (constraint == null)
            {
                return NotFound();
            }
            return View(constraint);
        }

        // POST: Constraints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,comment,constraint_type,end_date,frequency,max_time,min_time,priority,rol,start_date")] Constraint constraint)
        {
            if (id != constraint.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(constraint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstraintExists(constraint.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(constraint);
        }

        // GET: Constraints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constraint = await _context.Constraints.SingleOrDefaultAsync(m => m.id == id);
            if (constraint == null)
            {
                return NotFound();
            }

            return View(constraint);
        }

        // POST: Constraints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constraint = await _context.Constraints.SingleOrDefaultAsync(m => m.id == id);
            _context.Constraints.Remove(constraint);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConstraintExists(int id)
        {
            return _context.Constraints.Any(e => e.id == id);
        }
    }
}
