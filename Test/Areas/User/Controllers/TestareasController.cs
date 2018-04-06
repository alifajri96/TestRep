using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Model;

namespace Test.Areas.User.Controllers
{
    [Area("User")]
    public class TestareasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/Testareas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testarea.ToListAsync());
        }

        // GET: User/Testareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testarea = await _context.Testarea
                .SingleOrDefaultAsync(m => m.ID == id);
            if (testarea == null)
            {
                return NotFound();
            }

            return View(testarea);
        }

        // GET: User/Testareas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Testareas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nama,Alamat")] Testarea testarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testarea);
        }

        // GET: User/Testareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testarea = await _context.Testarea.SingleOrDefaultAsync(m => m.ID == id);
            if (testarea == null)
            {
                return NotFound();
            }
            return View(testarea);
        }

        // POST: User/Testareas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nama,Alamat")] Testarea testarea)
        {
            if (id != testarea.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestareaExists(testarea.ID))
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
            return View(testarea);
        }

        // GET: User/Testareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testarea = await _context.Testarea
                .SingleOrDefaultAsync(m => m.ID == id);
            if (testarea == null)
            {
                return NotFound();
            }

            return View(testarea);
        }

        // POST: User/Testareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testarea = await _context.Testarea.SingleOrDefaultAsync(m => m.ID == id);
            _context.Testarea.Remove(testarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestareaExists(int id)
        {
            return _context.Testarea.Any(e => e.ID == id);
        }
    }
}
