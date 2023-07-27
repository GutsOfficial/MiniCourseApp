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
    
    public class StudentController : Controller
    {
        private readonly CourseContext _context;

        public StudentController(CourseContext context)
        {
            _context=context;
        }
        public IActionResult Create(){
            return View();
        }
         public async Task<IActionResult> Index(){
            return View(await _context.Students.ToListAsync());
        }
        [HttpPost] 
         public async Task<IActionResult> Create(Student model){
            _context.Students.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            var student  = await _context.Students
            .Include(o=>o.joinlist)
            .ThenInclude(o=>o.kurs)
            .FirstOrDefaultAsync(o=>o.StudentId==id);

            return View(student);
        }
        [HttpPost]
         public async Task<IActionResult> Edit(int? id, Student model){
            if(ModelState.IsValid){

                try{
                        _context.Update(model);
                        await _context.SaveChangesAsync();
                }
                catch(Exception){

                }
                return RedirectToAction("Index");
            }


            return View(model);
        }
        public async Task<IActionResult> Delete(int? id){

            var student = await _context.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id ){

            
           var student = await _context.Students.FindAsync(id);
           _context.Students.Remove(student);
           _context.SaveChangesAsync();
           return RedirectToAction("Index");

        }
       
    }
}