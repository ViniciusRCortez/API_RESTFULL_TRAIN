using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            decimal res = ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber);
            return Ok(res.ToString());
        }
        return BadRequest("Invalid Input");   
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult Sub(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            decimal res = ConvertDecimal(firstNumber) - ConvertDecimal(secondNumber);
            return Ok(res.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult Mult(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            decimal res = ConvertDecimal(firstNumber) * ConvertDecimal(secondNumber);
            return Ok(res.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult Div(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            decimal res = ConvertDecimal(firstNumber) / ConvertDecimal(secondNumber);
            return Ok(res.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("media/{firstNumber}/{secondNumber}")]
    public IActionResult Media(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            decimal res = ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber);
            res /= 2;
            return Ok(res.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("sqrt/{strNumber}")]
    public IActionResult Sqrt(string strNumber)
    {
        if (IsNumeric(strNumber))
        {
            double res = ConvertDouble(strNumber);
            res = Math.Sqrt(res);
            return Ok(res.ToString());
        }
        return BadRequest("Invalid Input");
    }

    private decimal ConvertDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private double ConvertDouble(string strNumber)
    {
        double doubleValue;
        if (double.TryParse(strNumber, out doubleValue))
        {
            return doubleValue;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
        return isNumber;
    }
}
