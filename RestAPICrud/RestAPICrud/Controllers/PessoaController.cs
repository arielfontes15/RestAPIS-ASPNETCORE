using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestAPICrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
        }

        //Endpoint utilizado para soma de dois numeros Calculadora/soma/{firstNumber} / {secondNumber}
        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult CalculaSoma(string firstNumber, string secondNumber)
        {
            //Validação feita para verificar se os numeros são numericos ou não.
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                //Conversão dos numeros de String para Decimal em seguida a soma dos dois numeros
                var soma = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                //Retornando um Ok como sucesso a soma dos dois numeros como parametro
                return Ok(soma.ToString());
            }
            //Caso os parametros digitados nao forem numeros ira retornar uma BadRequest
            return BadRequest("Number Invalid");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number
                );
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}
