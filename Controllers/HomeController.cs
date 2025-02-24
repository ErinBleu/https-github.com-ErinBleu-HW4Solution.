using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HW4Project.Models;

namespace HW4Project.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult RGBColor(int? red, int? green, int? blue)
    {
        // Default color if values are missing
        red ??= 0;
        green ??= 0;
        blue ??= 0;

        string hexColor = $"#{red:X2}{green:X2}{blue:X2}";

        ViewData["HexColor"] = hexColor;
        ViewData["Red"] = red;
        ViewData["Green"] = green;
        ViewData["Blue"] = blue;

        return View();
    }

    [HttpGet]
    public IActionResult ColorInterpolator(ColorInterpolation colorInt)
    {
        return View("ColorInterpolator", colorInt);
    }

    [HttpPost]
    public IActionResult ColorInterpolator()
    {
        ColorInterpolation colorInt = new();

        colorInt.GenerateColors();

        return View("ColorInterpolator", colorInt);
    }

   /* [HttpGet] // ✅ This must be inside the class
    public IActionResult ColorInterpolator()
    {
        
        return View();
    }*/
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
