using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Model;
using Test.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["ArtikelCount"] = _context.Artikel.Count();
            ViewData["KategoriCount"] = _context.Kategori.Count();
            ViewData["RoleCount"] = _context.Roles.Count();

            return View();
            //IQueryable<CreateAtGroup> data =
            //from artikel in _context.Artikel
            //group artikel by artikel.CreateAt into dateGroup
            //select new CreateAtGroup()
            //{
            //    CreateAt = dateGroup.Key,
            //    ArtikelCount = dateGroup.Count()
            //    //kategoriCount = dateGroup.Count()
            //};
            // return View(await data.AsNoTracking().ToListAsync());


        }
        public IActionResult testap()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
