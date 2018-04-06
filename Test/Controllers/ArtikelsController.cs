using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Test.Data;
using Test.Model;

namespace Test.Controllers
{
    public class ArtikelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public ArtikelsController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Artikels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Artikel.Include(a => a.Kategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Artikels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel
                .Include(a => a.Kategori)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // GET: Artikels/Create
        public IActionResult Create()
        {
            ViewData["Nama"] = new SelectList(_context.Kategori, "ID", "Nama");
            return View();
        }

        // POST: Artikels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Judul,Deskripsi,ID_Kategori")]Artikel artikel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var files = HttpContext.Request.Form.Files;
        //        foreach (var Image in files)
        //        {
        //            if (Image != null && Image.Length > 0)
        //            {

        //                var file = Image;
        //                var uploads = Path.Combine(_env.WebRootPath, "uploads\\img\\artikels");

        //                if (file.Length > 0)
        //                {
        //                    var fileName = ContentDispositionHeaderValue.Parse
        //                        (file.ContentDisposition).FileName.Trim();

        //                    System.Console.WriteLine(fileName);
        //                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
        //                    {
        //                        await file.CopyToAsync(fileStream);
        //                        artikel.ImageName = file.FileName;
        //                    }


        //                }
        //            }
        //        }

        //        _context.Add(artikel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //    }
        //    ViewData["ID_Kategori"] = new SelectList(_context.Kategori, "ID", "ID", artikel.ID_Kategori);
        //    return View(artikel);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Artikel emp)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        //There is an error here
                        var uploads = Path.Combine(_env.WebRootPath, "uploads\\img");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                emp.ImageName = fileName;
                            }

                        }
                    }
                }
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            ViewData["ID_Kategori"] = new SelectList(_context.Kategori, "ID", "ID", emp.ID_Kategori);
            return View(emp);
        }

        // GET: Artikels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel.SingleOrDefaultAsync(m => m.Id == id);
            if (artikel == null)
            {
                return NotFound();
            }
            ViewData["Nama"] = new SelectList(_context.Kategori, "ID", "Nama", artikel.ID_Kategori);
            return View(artikel);
        }

        // POST: Artikels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Artikel emp)
        {
            if (id != emp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;
                    foreach (var Image in files)
                    {
                        if (Image != null && Image.Length > 0)
                        {
                            var file = Image;
                            //There is an error here
                            var uploads = Path.Combine(_env.WebRootPath, "uploads\\img");
                            if (file.Length > 0)
                            {
                                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    emp.ImageName = fileName;
                                }

                            }
                        }
                    }
                    _context.Add(emp);
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtikelExists(emp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewData["ID_Kategori"] = new SelectList(_context.Kategori, "ID", "ID", emp.ID_Kategori);
            return View(emp);
        }

        // GET: Artikels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel
                .Include(a => a.Kategori)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // POST: Artikels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artikel = await _context.Artikel.SingleOrDefaultAsync(m => m.Id == id);
            _context.Artikel.Remove(artikel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtikelExists(int id)
        {
            return _context.Artikel.Any(e => e.Id == id);
        }
    }
}
