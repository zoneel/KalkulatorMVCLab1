using System.Diagnostics;
using Kalkulator.Enums;
using Microsoft.AspNetCore.Mvc;
using Kalkulator.Models;
using Kalkulator.Models.Services;

namespace Kalkulator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewBag.Imie = "Jan";
        ViewBag.godzina = DateTime.Now.Hour;
        ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien odbry" : "Dobry wieczor";

        Dane[] osoby =
        {
            new Dane { Name = "Jan", Surname = "Kowalski" },
            new Dane { Name = "Jan", Surname = "KowalskiDwa" },
            new Dane { Name = "Jan", Surname = "KowalskiTrzy" },
            new Dane { Name = "Jan", Surname = "KowalskiCzetery" }

        };
        return View(osoby);
    }

    public IActionResult Urodziny(Urodziny urodziny)
    {
        ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
        return View();
    }

    public IActionResult Kalkulator(KalkulatorService service, int firstNumber, int secondNumber, TypeOfEquation typeOfEquation)
    {
        ViewBag.wynik = service.Calculate(firstNumber, secondNumber, typeOfEquation);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}