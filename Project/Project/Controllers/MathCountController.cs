using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Project.Dal;
using Project.Extentions;
using ProjectTest;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathCountController : ControllerBase
    {
        private CalculatorSoapClient _calculatorSoap = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);
        private MathDbContext _mathDbContext;
        private readonly ILogger<MathCountController> _log;
        public MathCountController(MathDbContext mathDbContext, ILogger<MathCountController> log)
        {
            _mathDbContext = mathDbContext;
            _log = log;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Number num)
        {
            _log.LogInformation("add");
            int result = 0;

            try
            {
                await _mathDbContext.AddLog(1,$"Required {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.AddAsync(num.NumOne, num.NumTwo);
                _log.LogInformation("result succesfull", result);

                await _mathDbContext.AddLog(1, $"Response {result} & {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _mathDbContext.AddLog(1, $"Required {JsonConvert.SerializeObject(num)}");
                await _mathDbContext.AddLog(1, "Error");
                _log.LogError("Request dont correct", ex);
                throw;
            }

        }

        [HttpPost("subtract")]
        public async Task<IActionResult> Subtract([FromBody] Number num)
        {
            _log.LogInformation("subtract");
            int result = 0;

            try
            {
                await _mathDbContext.AddLog(2, $"Requested {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.SubtractAsync(num.NumOne, num.NumTwo);
                _log.LogInformation("result succesfully", result);

                await _mathDbContext.AddLog(2, $"Response {result} {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _mathDbContext.AddLog(2, $"Requested {JsonConvert.SerializeObject(num)}");
                await _mathDbContext.AddLog(2, "Error");
                _log.LogError("request dont correct", ex);
                throw;
            }

        }

        [HttpPost("divide")]
        public async Task<IActionResult> Divide([FromBody] Number num)
        {
            _log.LogInformation("divide");
            int result = 0;

            try
            {
                await _mathDbContext.AddLog(3, $"Requested {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.DivideAsync(num.NumOne, num.NumTwo);
                _log.LogInformation("result succesfully");

                await _mathDbContext.AddLog(3, $"Response {result} {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _mathDbContext.AddLog(3, $"Requested {JsonConvert.SerializeObject(num)}");
                await _mathDbContext.AddLog(3,"Error");
                _log.LogError("request dont correct", ex);
                throw;
            }

        }

        [HttpPost("multiply")]
        public async Task<IActionResult> Multiply([FromBody] Number num)
        {
            _log.LogError("multiply");
            int result = 0;

            try
            {
                await _mathDbContext.AddLog(4, $"Requested {JsonConvert.SerializeObject(num)}");
                result = await _calculatorSoap.MultiplyAsync(num.NumOne, num.NumTwo);
                _log.LogInformation("result succesfully");

                await _mathDbContext.AddLog(4, $"Response {result} {JsonConvert.SerializeObject(num)}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                await _mathDbContext.AddLog(4, $"Requested {JsonConvert.SerializeObject(num)}");
                await _mathDbContext.AddLog(4, "Error");
                _log.LogError("request dont correct", ex);
                throw;
            }
        }

    }
}