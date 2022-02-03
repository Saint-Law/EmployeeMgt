using AutoMapper;
using EmployeeMgt.Core.ViewModels;
using EmployeeMgt.Data.Interface;
using EmployeeMgt.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Web.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUserLoginRepository loginRepo;
        private readonly IMapper Mapper;

        public UserLoginController(IUserLoginRepository _loginRepo, IMapper _Mapper)
        {
            loginRepo = _loginRepo;
            Mapper = _Mapper;
        }

        // GET: LoginController
        public async Task<ActionResult> Index()
        {
            var uLogin = await loginRepo.FindAll();
            var collection = Mapper.Map<List<UserLogin>, List<UserLoginVM>>(uLogin.ToList());
            return View(collection);
        }

        // GET: LoginController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExist = await loginRepo.isExist(id);
            if (!isExist)
            {
                return NotFound();
            }

            var uLogin = await loginRepo.FindById(id);
            var collection = Mapper.Map<UserLoginVM>(uLogin);
            return View(collection);
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserLoginVM collection)
        {
            try
            {
                //TODO : added insert logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var users = await loginRepo.FindAll();
                var isSuccess = users.FirstOrDefault(x => x.UserName == collection.UserName &&
                x.Password == collection.Password);

                ///var isSuccess = await loginRepo.Create(uLogin);
                if (isSuccess != null)
                {
                    return RedirectToAction("Dashboard", "Verified");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(collection);
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
