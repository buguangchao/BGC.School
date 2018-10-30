using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BGC.School.Core.Models;
using BGC.School.EntityFramework;
using BGC.School.Application.Dto;

namespace BGC.School.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string sortOrder,string searchFilter)
        {
            ViewData["SortOrderName"] = string.IsNullOrWhiteSpace(sortOrder) ? "name_desc" : "";
            ViewData["SortOrderDate"] = (string.IsNullOrWhiteSpace(sortOrder) || sortOrder == "date_asc") ? "date_desc" : "date_asc";

            ViewData["SearchName"] = searchFilter;

            var students = from p in _context.Students select p;

            if (!string.IsNullOrWhiteSpace(searchFilter))
            {
                students = students.Where(m=>m.Name.Contains(searchFilter));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(m => m.Name);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(m => m.EnrollDate);
                    break;
                case "date_asc":
                    students = students.OrderBy(m => m.EnrollDate);
                    break;
                default :
                    students = students.OrderBy(m => m.Name);
                    break;
            }

            return View(await students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                                        .Include(m=>m.Enrollments)
                                        .ThenInclude(e=>e.Course)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentDto student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var stu = new Student();
                    stu.Name = student.Name;
                    stu.EnrollDate = student.EnrollDate;

                    _context.Add(stu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("CreateError", "保存数据失败！原因："+ex.Message);
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("Id,Name,EnrollDate")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            var stu = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
            if (await TryUpdateModelAsync<Student>(stu,"",s=>s.Name, s => s.EnrollDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("CreateError", "保存数据失败！原因：" + ex.Message);
                }
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(student);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!StudentExists(student.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? hasError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            if (hasError.GetValueOrDefault())
            {
                ViewBag.DeleteError = "删除失败，请重新试下";
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                //throw new Exception("sdfsf");
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Delete),new { id=id, hasError =true});
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
