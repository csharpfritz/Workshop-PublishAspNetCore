using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
  public class HomeController : Controller
  {

    private readonly SpeakerDbContext _Context;

    public HomeController(Models.SpeakerDbContext context)
    {
      _Context = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Speakers()
    {

      return View();

    }

    [Route("/api/SpeakerList")]
    public IEnumerable<Models.Speaker> SpeakerList()
    {
      return _Context.Speakers.ToArray();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View();
    }
  }
}
