using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers
{
  public class TravelsController : Controller
  {
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

    public IActionResult Delete(int id)
    {
      Travel.Delete(id);
      return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Travel travel)
    {
      Travel.Post(travel);
      return RedirectToAction("Index", "Home");
    }
  }
}