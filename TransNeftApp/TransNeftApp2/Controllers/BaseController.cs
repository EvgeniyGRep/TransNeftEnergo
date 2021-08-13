using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TransNeftApp2.Controllers
{
    public class BaseController : Controller
    {
        protected const string rootApiUrl = @"http://127.0.0.1:8050/api/";
        protected readonly ILogger<BaseController> _logger;
        protected static readonly HttpClient client = new HttpClient();

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<List<TEntity>> GetListFromApi<TEntity>(string path)
        {
            var response = await client.GetStringAsync(path);
            var result = JsonConvert.DeserializeObject<List<TEntity>>(response);

            return result;
        }
    }
}
