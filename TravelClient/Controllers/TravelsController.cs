using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TravelClient.Controllers
{
  public class TravelsController : Controller
  {
    private readonly TravelClientContext _db;

    private readonly UserManager<ApplicationUser> _userManager;

    public TravelsController(UserManager<ApplicationUser> userManager, TravelClientContext db)
    {
      _userManager = userManager;
      _db = db;
    }


    public IActionResult Index()
    {
      var allTravels = Travel.GetTravels();
      return View(allTravels);
    }

    [HttpPost]
    public IActionResult Index(Travel travel)
    {
      Travel.Post(travel);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var travel = Travel.GetDetails(id);
      return View(travel);
    }

    [Authorize]
    public IActionResult Edit(int id)
    {
      var travel = Travel.GetDetails(id);
      return View(travel);
    }

    [HttpPost]
    public IActionResult Details(int id, Travel travel)
    {
      travel.TravelId = id;
      Travel.Put(travel);
      return RedirectToAction("Details", id);
    }

    [Authorize]
    public IActionResult Delete(int id)
    {
      Travel.Delete(id);
      return RedirectToAction("Index");
    }

    [Authorize]
    public IActionResult Create()
    {
      return View();
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create(Travel travel)
    {
      Travel.Post(travel);
      return RedirectToAction("Index", "Travels");
    }
  }
}