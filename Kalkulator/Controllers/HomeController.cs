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

    public IActionResult Kalkulator(KalkulatorService service, KalkulatorZapytanie zapytanie)
    {
        if (zapytanie.Number1 is null || zapytanie.Number2 is null)
        {
            ViewBag.wynik = "Niepoprawna liczba";
            return View();
        }
        
        if (zapytanie.EquationType == TypeOfEquation.Division && zapytanie.Number2 == 0)
        {
            ViewBag.wynik = "Nie dziel przez zero!";
            return View();
        }
        
        if (zapytanie.Number1 is not null && zapytanie.Number2 is not null)
        {
            ViewBag.wynik = service.Calculate((double)zapytanie.Number1, (double)zapytanie.Number2, zapytanie.EquationType);
            return View();
        }
            return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}