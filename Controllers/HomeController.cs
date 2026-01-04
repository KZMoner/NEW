using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using New.Models;

namespace New.Controllers;

public class HomeController : Controller
{
    private readonly APPDBcontext _db;
    public HomeController(APPDBcontext db)
    {
        _db = db;
    }
    public IActionResult Index(string Filter)
    {
        var query = _db.Rotiens.AsQueryable();
        var today = DateTime.UtcNow.Date;

        if (Filter == "today")
        {
            query = query.Where(r => r.Date >= today && r.Date < today.AddDays(1));
        }
        else if (Filter == "week")
        {
            var todayUtc = DateTime.UtcNow.Date;           // Today at 00:00 UTC
            var weekAgoUtc = todayUtc.AddDays(-6);         // 6 days before today (includes today = 7 days)

            query = query.Where(r => r.Date >= weekAgoUtc && r.Date <= todayUtc.AddDays(1));
        }
        else if (Filter == "month")
        {
            var startOfMonthUtc = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var startOfNextMonthUtc = startOfMonthUtc.AddMonths(1);

            query = query.Where(r => r.Date >= startOfMonthUtc && r.Date < startOfNextMonthUtc);
        }
        else if (Filter == "year")
        {
            var startOfYearUtc = new DateTime(today.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var startOfNextYearUtc = startOfYearUtc.AddYears(1);

            query = query.Where(r => r.Date >= startOfYearUtc && r.Date < startOfNextYearUtc);
        }

        var vm = new RotienViewModel
        {
            RotienList = query.OrderByDescending(r => r.Date).ToList()
        };

        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registertion(Registration model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            ModelState.AddModelError("ConfirmPassword", "Passwords do not match");
        }

        if (ModelState.IsValid)
        {
            _db.Registrations.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View("Register", model);
    }
    [HttpPost]
    public IActionResult Create(RotienViewModel model)
    {
        if (ModelState.IsValid)
        {
            //  model.NewRotien.Date = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc);
            model.NewRotien.Date = DateTime.SpecifyKind(model.NewRotien.Date, DateTimeKind.Utc);
            _db.Rotiens.Add(model.NewRotien);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);
    }
    [HttpPost]
    public IActionResult Edit(RotienViewModel model)
    {
        if (model.NewRotien.ID > 0)
        {
            var item = _db.Rotiens.Find(model.NewRotien.ID);
            if (item != null)
            {

                item.Date = DateTime.SpecifyKind(model.NewRotien.Date, DateTimeKind.Utc);
                item.Work = model.NewRotien.Work;
                item.place = model.NewRotien.place;

                _db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
        }

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int ID)
    {
        var rotien = _db.Rotiens.Find(ID);
        if (rotien == null)
        {
            return NotFound();
        }
        _db.Rotiens.Remove(rotien);
        _db.SaveChanges();
        return RedirectToAction("index");
    }


}
