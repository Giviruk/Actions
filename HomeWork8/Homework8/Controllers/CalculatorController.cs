using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Homework8.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers;

public class CalculatorController : Controller
{
    public string Calculate([FromServices] ICalculator calculator,
        string val1,
        string operation,
        string val2)
    {
        throw new NotImplementedException();
    }
    
    [ExcludeFromCodeCoverage]
    public IActionResult Index()
    {
        return Content(
            "Заполните val1, operation(plus, minus, multiply, divide) и val2 здесь '/calculator/calculate?val1= &operation= &val2= '\n" +
            "и добавьте её в адресную строку.");
    }
}