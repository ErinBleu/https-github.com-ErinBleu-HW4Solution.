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
}
