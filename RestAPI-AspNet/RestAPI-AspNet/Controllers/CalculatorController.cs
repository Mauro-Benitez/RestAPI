using Microsoft.AspNetCore.Mvc;

namespace RestAPI_AspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }

        private decimal convertToDecimal(string strNumber)
        {

            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;

        }







        [HttpGet ("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum( string firstNumber, string secondNumber)
        {
           if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = convertToDecimal(firstNumber) + convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Ivalid Input");        
        
        
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Menos(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = convertToDecimal(firstNumber) - convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Ivalid Input");


        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult Multi(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = convertToDecimal(firstNumber) * convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Ivalid Input");


        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = convertToDecimal(firstNumber)/ convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Ivalid Input");


        }







    }
}
