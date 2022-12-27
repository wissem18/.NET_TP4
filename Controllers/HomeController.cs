using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UniversityContext u1=UniversityContext.getContext();
            UniversityContext u2 = UniversityContext.getContext();
            List<Student> s = u1.student.ToList();
            foreach (Student student in s)
            {
                Debug.WriteLine("ID : " + student.id);
                Debug.WriteLine("First Name : " + student.first_name);
                Debug.WriteLine("Last Name : " + student.last_name);
                Debug.WriteLine("Phone Number : " + student.phone_number);
                Debug.WriteLine("University : " + student.university);
                Debug.WriteLine("Time : " + student.timestamp);
                Debug.WriteLine("Course : " + student.course);
                Debug.WriteLine("\n");
            }
            return View();
        }
        [Route("/Courses")]
        public IActionResult Courses()
        {
            UniversityContext universityContext = UniversityContext.getContext();
            StudentRepository repo = new StudentRepository(universityContext);
            List<string> courses = new List<string>(repo.GetCourses());
            return View(courses);
        }
        [Route("/Courses/{course}")]
        public IActionResult Students(string course)
        {
            UniversityContext universityContext = UniversityContext.getContext();
            StudentRepository repo = new StudentRepository(universityContext);
            List<Student> students = new List<Student>(repo.Find(s => s.course == course));
            return View(students);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}