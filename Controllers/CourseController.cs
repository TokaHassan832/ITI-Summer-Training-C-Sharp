using Microsoft.AspNetCore.Mvc;

namespace mvc1.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            //Response.Cookies.Append("Id", "5");
            //Response.Cookies.Append("name", "toka");

            HttpContext.Session.SetInt32("id", 5);
            HttpContext.Session.SetString("name", "toka");

            ViewBag.id = 5;
            ViewBag.name = "toka";
            return View();
        }

        public IActionResult Display()
        {
            //int id = int.Parse(Request.Cookies["id"]);
            //string name = Request.Cookies["name"];

            int? id = HttpContext.Session.GetInt32("id");
            string name = HttpContext.Session.GetString("name");

            ViewBag.id = id;
            ViewBag.name = name;
            return View();
        }
    }
}
