using Microsoft.AspNetCore.Mvc;
using MSIT155Site.Models;
using MSIT155Site.Models.DTO;
using System.Text;

namespace MSIT155Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _context;
        public ApiController(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContentTest()
        {
            Thread.Sleep(3000);
            //int x = 10;
            //int y = 0;
            //int z = x / y;
            //return Content("HI!");
            //return Content("<h2>HI!</h2>", "text/html");
            return Content("HI!你好", "text/plain", Encoding.UTF8);
        }
        public IActionResult Cities()
        {
            var cities = _context.Addresses.Select(a=>a.City).Distinct();
            return Json(cities);
        }
        [HttpPost]
        public IActionResult Avatar(int id = 1)
        {
            Member? member = _context.Members.Find(id);
            if(member != null)
            {
                byte[] img = member.FileData;
                if(img != null)
                {
                    return File(img, "image/jpeg");
                }
            }
            return NotFound();
        }

        public IActionResult Register(UserDTO _user)
        {
            if (string.IsNullOrEmpty(_user.Name))
            {
                _user.Name = "guest";
            }
            return Content($"Hello {_user.Name}, {_user.Age}歲了, 電子郵件是 {_user.Email}", "text/plain", Encoding.UTF8);
        }

        public IActionResult CheckAccount(UserDTO _user)
        {
            var MemberName = _context.Members.FirstOrDefault(m => m.Name == _user.Name);
            if(MemberName != null)
            {
                return Content("帳號已存在", "text/plain", Encoding.UTF8);
            }
            return Content("帳號可使用", "text/plain", Encoding.UTF8);
        }

    }

}
