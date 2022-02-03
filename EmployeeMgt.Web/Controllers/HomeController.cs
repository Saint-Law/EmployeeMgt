using AutoMapper;
using EmployeeMgt.Core.ViewModels;
using EmployeeMgt.Data.Interface;
using EmployeeMgt.Data.Models;
using EmployeeMgt.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeMgt.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly IEmployeeRepository _repo;
        private readonly IUserLoginRepository _loginRepo;
        private readonly IUserRoleRepository userRole;
        private readonly IMapper _mapper;

        public HomeController(IEmployeeRepository repo, IUserLoginRepository loginRepo,
           IMapper mapper, IUserRoleRepository _userRole)
        {
            _repo = repo;
            _loginRepo = loginRepo;
            userRole = _userRole;
            _mapper = mapper;
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLoginVM collection)
        {

            try
            {
                //TODO : added insert logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var users = await _loginRepo.FindAll();
                var isSuccess = users.FirstOrDefault(x => x.UserName == collection.UserName &&
                x.Password == collection.Password);

                if (isSuccess != null)
                {
                    var myRoles = await userRole.FindAll();
                    var roles = myRoles.FirstOrDefault(x => x.UserName == collection.UserName);
                    if (roles != null)
                    {
                        //Code for Keeping Currently Logged in User information
                        var userClaims = SetUserClaims(isSuccess, roles);
                        var userIdentity = new ClaimsIdentity(userClaims, "EmployeeSecureClaims");
                        var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                        await HttpContext.SignInAsync(userPrincipal);

                        //For getting user role and redirecting to the appropriate dashboard
                        if (roles.RoleId == 1)
                        {
                            return RedirectToAction("Dashboard", "Verified");
                        }
                        else if (roles.RoleId == 2)
                        {
                            return RedirectToAction("EmployeeDashboard", "Verified");
                        }
                        else
                        {
                            return RedirectToAction("#", "#");
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid Username/Password");
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(collection);
            }
        }

        //For Setting User's Claims, Claims is just User Information at the point of loggin in
        public List<Claim> SetUserClaims(UserLogin claimsObjs, UserRole myRole)
        {
            var userClaims = new List<Claim>()
            {
              new Claim(EmpClaims.email, claimsObjs.UserName),
              new Claim(EmpClaims.UserId, claimsObjs.Id.ToString()),
              new Claim(EmpClaims.roleName, myRole.RoleId.ToString())
            };

            return userClaims;
        }

        public IActionResult Index()
        {
            return View();
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
