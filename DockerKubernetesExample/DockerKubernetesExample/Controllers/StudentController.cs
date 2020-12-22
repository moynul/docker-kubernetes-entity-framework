using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerKubernetesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DockerKubernetesExample.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _CoreDbProvider;
        private readonly IConfiguration _configuration;

        public StudentController(IStudentRepository coreDbProvider, IConfiguration configuration)
        {
            _CoreDbProvider = coreDbProvider;
            _configuration = configuration;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> studentLists = await _CoreDbProvider.GetStudent();
            return View(studentLists);
        }


        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _CoreDbProvider.GetStudentByid(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rollno,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _CoreDbProvider.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _CoreDbProvider.GetStudentByid(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rollno,Address")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _CoreDbProvider.Update(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _CoreDbProvider.GetStudentByid(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _CoreDbProvider.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
