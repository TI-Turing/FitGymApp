using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Gymmetry.Application.Services
{
    public class ConfigAutoService : IConfigAutoService
    {
        private readonly IConfigAutoRepository _configAutoRepository;
        private readonly ILogger<ConfigAutoService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ConfigAutoService(IConfigAutoRepository configAutoRepository, ILogger<ConfigAutoService> logger, HttpClient httpClient, IConfiguration configuration)
        {
            _configAutoRepository = configAutoRepository;
            _logger = logger;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task UpdateUsdPricesFromExchangeAsync()
        {
            decimal usdToCop = 0;
            string apiUrl = _configuration["ExchangeRateApiUrl"] ?? "https://api.exchangerate.host/latest?base=USD&symbols=COP";
            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("rates", out var rates) && rates.TryGetProperty("COP", out var cop))
                {
                    usdToCop = cop.GetDecimal();
                }
                else
                {
                    _logger.LogWarning("No se pudo obtener el valor de COP en la respuesta de la API de tipo de cambio.");
                    return;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener el tipo de cambio USD/COP");
                return;
            }

            await _configAutoRepository.UpdateUsdPricesAsync(usdToCop);
        }
    }
}
