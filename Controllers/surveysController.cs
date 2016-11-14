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
    public class surveysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public surveysController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: surveys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Surveys.ToListAsync());
        }

        // GET: surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys.SingleOrDefaultAsync(m => m.id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: surveys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date_created,date_modified,description,rowguid,title")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys.SingleOrDefaultAsync(m => m.id == id);
            if (survey == null)
            {
                return NotFound();
            }
            return View(survey);
        }

        // POST: surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,date_created,date_modified,description,rowguid,title")] Survey survey)
        {
            if (id != survey.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.id))
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
            return View(survey);
        }

        // GET: surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Surveys.SingleOrDefaultAsync(m => m.id == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survey = await _context.Surveys.SingleOrDefaultAsync(m => m.id == id);
            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SurveyExists(int id)
        {
            return _context.Surveys.Any(e => e.id == id);
        }
    }
}
