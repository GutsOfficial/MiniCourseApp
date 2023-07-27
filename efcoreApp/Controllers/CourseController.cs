using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace efcoreApp.Controllers
{
    
    public class CourseController : Controller
    {
        private readonly CourseContext _context;
        public CourseController(CourseContext context)
        {
            _context = context;
        }
        
        
       public IActionResult Create(){
        return View();
       }
     
      public async Task<IActionResult> Insex(){
            var mod = await _context.Courses.ToListAsync();
            return View(mod);
        } 
       [HttpPost] 
         public async Task<IActionResult> Create(Course model){
            _context.Courses.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Insex");

        }
        public async Task<IActionResult> Delete(int? id){

            var student = await _context.Courses.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id ){

            
           var student = await _context.Courses.FindAsync(id);
           _context.Courses.Remove(student);
           _context.SaveChangesAsync();
           return RedirectToAction("Insex");

        }

        public async Task<IActionResult> Edit(int? id){
             var student  = await _context.Courses
            .Include(x=>x.joinlist)
            .ThenInclude(x=>x.ogrenci)
            .FirstOrDefaultAsync(x=>x.CourseId==id);
            return View(student);
        }
        [HttpPost]
         public async Task<IActionResult> Edit(int? id, Course model){
            if(ModelState.IsValid){

                try{
                        _context.Update(model);
                        await _context.SaveChangesAsync();
                }
                catch(Exception){

                }
                return RedirectToAction("Insex");
            }


            return View(model);
        }
         
    }
}