using Microsoft.AspNetCore.Mvc;
using mvc1.BLL;
using mvc1.Models;

namespace mvc1.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBLL db = new DepartmentBLL();
        public IActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }


        public IActionResult Details(int id)
        {
            Department dept = db.GetbyId(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                db.Add(model);
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Department dept = db.GetbyId(id.Value);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            db.Update(department);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Department dept = db.GetbyId(id.Value);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
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
