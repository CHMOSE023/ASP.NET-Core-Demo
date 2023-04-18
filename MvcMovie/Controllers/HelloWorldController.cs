using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            //return "This is my default action ...";
            return View();
        }

        // 查询字符串
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello"+ name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
