using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Areas.Admin.Controllers.Api
{
    [Area("Admin")]
    
    public class ApiArtikelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApiArtikelsController(ApplicationDbContext context)
        {
            _context = context;

            //if (_context.TodoItem.Count() == 0)
            //{
            //    _context.TodoItem.Add(new Artikel { Name = "Item1" });
            //    _context.SaveChanges();
            //}
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Artikel.ToList();
            return Ok(data.OrderBy(x=>x.Id));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult geta()
        {
            var data = new List<Dummy>();
            var dummy1 = new Dummy() {
            item1 = 200, y = "2001", a="300"};
            data.Add(dummy1);
            var dummy2 = new Dummy() {
                item1 = 100,
                y = "2005",
                a = "300"
            };
            data.Add(dummy2);
            var dummy3 = new Dummy() {
                item1 = 300,
                y = "2003",
                a = "300"
            };
            data.Add(dummy3);
            var dummy4 = new Dummy() {
                item1 = 100,
                y = "2010",
                a = "100"
            };
            data.Add(dummy4);
            return Ok(data.OrderBy(x => x.y));

        }

        //[HttpGet("{id}", Name = "GetTodo")]
        //public IActionResult GetById(long id)
        //{
        //    var item = _context.Artikel.FirstOrDefault(t => t.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(item);
        //}

        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
