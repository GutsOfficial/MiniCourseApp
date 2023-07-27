using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace efcoreApp.Controllers
{
   
    public class JoinController : Controller
    {
        private readonly CourseContext _context;
        public JoinController(CourseContext context)
        {
            _context=context;
        }
        public async Task<IActionResult> Create(){
            ViewBag.Students=new SelectList(await _context.Students.ToListAsync(),"StudentId","adsoyad");
             ViewBag.Courses=new SelectList(await _context.Courses.ToListAsync(),"CourseId","Title");
        return View();
       }
     
      public async Task<IActionResult> Index(){
            var moddd = await _context.courseJoins.Include(x=>x.ogrenci).Include(x=>x.kurs).ToListAsync();
            return View(moddd);
        } 
       [HttpPost] 
         public async Task<IActionResult> Create(CourseJoin model){
            model.CourseDate = DateTime.Now;
            _context.courseJoins.Add(model);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}