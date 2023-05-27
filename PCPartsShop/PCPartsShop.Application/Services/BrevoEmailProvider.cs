using PCPartsShop.Application.Interfaces;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PCPartsShop.Domain.ConfigurationDtos;

namespace PCPartsShop.Application.Services
{
    public class BrevoEmailProvider : IEmailProvider
    {
        private readonly IOptions<BrevoConfig> _options;
        public BrevoEmailProvider(IOptions<BrevoConfig> options)
        {
            _options = options;
        }

        public async Task<BrevoAPIResponseDto> SendEmail(BrevoEmailProviderDto email)
        {
            var baseUrl = _options.Value.BaseUrl;
            var apiKey = _options.Value.APIKey;

            HttpClient client = new()
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("api-key", apiKey);

            var jsonPayload = JsonConvert.SerializeObject(email);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("smtp/email", content);

            if (response.IsSuccessStatusCode)
            {
                var finalResponse = JsonConvert.DeserializeObject<BrevoAPIResponseDto>(await response.Content.ReadAsStringAsync());
                return await Task.FromResult(finalResponse);
            }

            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}
