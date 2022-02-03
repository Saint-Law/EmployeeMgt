using AutoMapper;
using EmployeeMgt.Core.ViewModels;
using EmployeeMgt.Data.Interface;
using EmployeeMgt.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;
        private readonly IUserLoginRepository _loginRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository repo, IUserLoginRepository loginRepo, IMapper mapper)
        {
            _repo = repo;
            _loginRepo = loginRepo;
            _mapper = mapper;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var employee = await _repo.FindAll();
            var collection = _mapper.Map<List<Employee>, List<EmployeeVM>>(employee.ToList());
            return View(collection);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _repo.isExist(id);
            if (!isExists)
            {
                return NotFound();
            }
            var employee = await _repo.FindById(id);
            var collectoin = _mapper.Map<EmployeeVM>(employee);
            return View(collectoin);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeVM collection)
        {
            try
            {
                //TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var employee = _mapper.Map<Employee>(collection);
                employee.DateCreated = DateTime.Now;

                var isSuccess = await _repo.Create(employee);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(collection);
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _repo.isExist(id);
            if (!isExists)
            {
                return NotFound();
            }
            var employee = await _repo.FindById(id);
            var collection = _mapper.Map<EmployeeVM>(employee);
            return View(collection);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeVM collection)
        {
            try
            {
                //TODO: Add Update Logic Here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var employee = _mapper.Map<Employee>(collection);
                var isSuccess = await _repo.Update(employee);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...!!!");
                    return View(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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

        public async Task<ActionResult> myDetails(int id)
        {
            var isExists = await _repo.isExist(id);
            if (!isExists)
            {
                return NotFound();
            }
            var employee = await _repo.FindById(id);
            var collection = _mapper.Map<EmployeeVM>(employee);
            return View(collection);
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> myEdit(int id)
        {
            var isExists = await _repo.isExist(id);
            if (!isExists)
            {
                return NotFound();
            }
            var employee = await _repo.FindById(id);
            var collection = _mapper.Map<EmployeeVM>(employee);
            return View(collection);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> myEdit(EmployeeVM collection)
        {
            try
            {
                //TODO: Add Profile Update Logic Here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var employee = _mapper.Map<Employee>(collection);
                var isSuccess = await _repo.Update(employee);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(collection);
            }
        }

    }
}
