using DatabaseDropdown.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseDropdown.Controllers
{
    public class UserController : Controller
    {
        private UserDbContext dbContext;
        public UserController(UserDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            var list = dbContext.users.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            dbContext.users.Add(user);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var user = dbContext.users.SingleOrDefault(e => e.Id == id);
            if (user != null)
            {
                dbContext.users.Remove(user);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Getcountries()
        {
            var countries = dbContext.countries.ToList();
            return Json(countries);
        }
        public IActionResult Getstates(int id)
        {
            var states = dbContext.states.Where(e=>e.Country.Id==id);
            return Json(states);
        }
        public IActionResult Getcities(int id)
        {
            var cities = dbContext.cities.Where(e=>e.State.Id==id);
            return Json(cities);
        }
    }
}
