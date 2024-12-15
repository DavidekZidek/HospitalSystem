using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.ViewModels;
using HospitalSystem.Models;

namespace HospitalSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IHomeService _homeService;

    public HomeController(ILogger<HomeController> logger, IHomeService homeService)
    {
        _logger = logger;
        _homeService = homeService;
    }

    public IActionResult Index()
    {
        PatientViewModel viewModel = _homeService.GetPatientViewModel();
        return View(viewModel);
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