using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using BLRI.Mvc.Models;
using System;

namespace BLRI.Mvc.Controllers
{

    public class HomeController : Controller
    {
        private readonly MyDatabaseContext _context;

        public HomeController(MyDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Register()
        {
            var registerModel = new RegistrationModel();
            return View(registerModel);
        }


        [HttpGet]
        public IActionResult RegisterUserList()
        {
            var result = new List<CompleteRegisterViewmodel>();

            var listOfUsers = _context.Registration.ToList();
            foreach (var x in listOfUsers)
            {
                result.Add(new CompleteRegisterViewmodel()
                {
                    RegisterDate = x.DateOfRegistration.ToString("yyyy-MM-dd"),
                    CustomerName = $"{x.LastName}, {x.FirstName}",
                    SubscriptionType = x.SubscriptionType,
                    Username = x.Username
                });
            }


            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateOfRegistration = DateTime.Now;

                _context.Add(model);
                await _context.SaveChangesAsync();

                var result = _context.Registration.Where(x => x.Email == model.Email).FirstOrDefault();


                var complete = new CompleteRegisterViewmodel()
                {
                    RegisterDate = result.DateOfRegistration.ToString("yyyy-MM-dd"),
                    CustomerName = $"{result.LastName}, {result.FirstName}",
                    SubscriptionType =  result.SubscriptionType,
                    Username = result.Username
                };

                return View("CompleteRegister", complete);
            }

            var registerModel = new RegistrationModel();
            return View(registerModel);
        }
    }
}
