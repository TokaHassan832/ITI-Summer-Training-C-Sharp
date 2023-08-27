using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc1.BLL;
using mvc1.Models;

namespace mvc1.Controllers
{
    public class StudentController : Controller
    {
       //StudentBLL db = new StudentBLL();
       //IStudent db = new StudentBLL();

        IStudent db;

        public StudentController(IStudent _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }


        public IActionResult Details(int id)
        {
            Student std = db.GetbyId(id);
            if (std == null)
            {
                return NotFound();
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Create()
        {
            DepartmentBLL deptbll = new DepartmentBLL();
            ViewBag.departments = new SelectList(deptbll.GetAll(),"Id","Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                db.Add(model);
                return RedirectToAction("Index");
            }
            DepartmentBLL deptbll = new DepartmentBLL();
            ViewBag.departments = deptbll.GetAll();
            return View();
     
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Student student = db.GetbyId(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            DepartmentBLL deptbll = new DepartmentBLL();
            ViewBag.departments = deptbll.GetAll();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
                db.Update(student);
                return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Student student = db.GetbyId(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            db.Delete(id.Value);
            return RedirectToAction("Index");
        }

    }
}
