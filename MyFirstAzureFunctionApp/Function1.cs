using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyFirstAzureFunctionApp
{
    public static class Function1
    {
        [FunctionName("HttpFunc1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var queryName = req.Query["name"];
            var responseMessage = string.IsNullOrEmpty(queryName) ? "Invalid name !" : $"Hello {queryName}";

            
            return new OkObjectResult(responseMessage);
        }
    }
}
