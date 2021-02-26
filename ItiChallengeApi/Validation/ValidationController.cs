using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Validation.Password;

namespace ItiChallengeApi.Validation
{
    /// <summary>
    /// This controller is responsible for doing validations on varied inputs.
    /// </summary>
    [ApiController]
    [Route("/validate")]
    public class ValidationController : ControllerBase
    {
        private readonly ILogger<ValidationController> _logger;

        public ValidationController(ILogger<ValidationController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This POST method returns if the given object contains a valid password.
        /// </summary>
        /// <returns>Either true or false</returns>
        [HttpPost("/password")]
        public bool ValidatePassword(JObject dto)
        {
            Console.WriteLine(dto["password"]);
            return new Password("password").IsValid;
        }
    }
}
