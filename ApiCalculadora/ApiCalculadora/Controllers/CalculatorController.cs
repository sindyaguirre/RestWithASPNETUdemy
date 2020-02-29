using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiCalculadora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        //GET api/calculator/subtraction/2/3
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber,string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var response = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(response.ToString());
            }
            
            return BadRequest("Invalid input");
        }

        //GET api/calculator/division/2/3
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber,string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var response = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(response.ToString());
            }
            
            return BadRequest("Invalid input");
        }

        //GET api/calculator/subtraction/2/3
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber,string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var response = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(response.ToString());
            }
            
            return BadRequest("Invalid input");
        }


        //GET api/calculator/subtraction/2/3
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber,string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var response = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;

                return Ok(response.ToString());
            }
            
            return BadRequest("Invalid input");
        }

        //GET api/calculator/multiplication/2/3
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber,string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var response = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));

                return Ok(response.ToString());
            }
            
            return BadRequest("Invalid input");
        }

        //api/calculator/square-root/5
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number) 
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }
            return Ok("Invalid Input");

        }
        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo,out number);
            
            return isNumber;
        }
    }
}
