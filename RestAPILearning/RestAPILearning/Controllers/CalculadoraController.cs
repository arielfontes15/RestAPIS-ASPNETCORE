using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPILearning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ILogger<CalculadoraController> _logger;
        public CalculadoraController(ILogger<CalculadoraController> logger)
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

        //Endpoint utilizado para subtracao de dois numeros Calculadora/subtracao/{firstNumber} / {secondNumber}
        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult CalculaSubtracao(string firstNumber, string secondNumber)
        {
            //Validação feita para verificar se os numeros são numericos ou não.
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                //Conversão dos numeros de String para Decimal em seguida a subtracao dos dois numeros
                var subtracao = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                //Retornando um Ok como sucesso a subtracao dos dois numeros como parametro
                return Ok(subtracao.ToString());
            }
            //Caso os parametros digitados nao forem numeros ira retornar uma BadRequest
            return BadRequest("Number Invalid");
        }
        
        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public IActionResult CalculaDivisao(string firstNumber, string secondNumber)
        {
            //Validação feita para verificar se os numeros são numericos ou não.
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                //Conversão dos numeros de String para Decimal em seguida a divisao dos dois numeros
                var divisao = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                //Retornando um Ok como sucesso a divisao dos dois numeros como parametro
                return Ok(divisao.ToString());
            }
            //Caso os parametros digitados nao forem numeros ira retornar uma BadRequest
            return BadRequest("Number Invalid");
        }   
        
        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult CalculaMultiplicacao(string firstNumber, string secondNumber)
        {
            //Validação feita para verificar se os numeros são numericos ou não.
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                //Conversão dos numeros de String para Decimal em seguida a multiplicacao dos dois numeros
                var multiplicacao = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                //Retornando um Ok como sucesso a multiplicacao dos dois numeros como parametro
                return Ok(multiplicacao.ToString());
            }
            //Caso os parametros digitados nao forem numeros ira retornar uma BadRequest
            return BadRequest("Number Invalid");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult CalculaMedia(string firstNumber, string secondNumber)
        {
            //Validação feita para verificar se os numeros são numericos ou não.
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                //Conversão dos numeros de String para Decimal em seguida a media dos dois numeros
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                //Retornando um Ok como sucesso a media dos dois numeros como parametro
                return Ok(media.ToString());
            }
            //Caso os parametros digitados nao forem numeros ira retornar uma BadRequest
            return BadRequest("Number Invalid");
        }

        [HttpGet("raizquadrada/{firstNumber}")]
        public IActionResult CalculaRaizQuadrada(string firstNumber)
        {
            //Validação feita para verificar se os numeros são numericos ou não.
            if (IsNumeric(firstNumber))
            {
                //Conversão dos numeros de String para Decimal em seguida a raizQuadrada dos dois numeros
                var raizQuadrada = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                //Retornando um Ok como sucesso a raizQuadrada dos dois numeros como parametro
                return Ok(raizQuadrada.ToString());
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
