using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Dtos;

namespace OrderServices.SyncDataServices
{
    public class HttpProductDataClient : IProductDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpProductDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<ReadProductDto>> ReturnAllProduct()
        {
            var response = await _httpClient.GetAsync(_configuration["ProductService"]);
            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{content}");
                var product = JsonSerializer.Deserialize<List<ReadProductDto>>(content);
                if (product != null)
                {
                    Console.WriteLine($"{product.Count()} platforms returned from Product Service");
                    return product;
                }
                throw new Exception("No product found");
            }
            else
            {
                throw new Exception("Unable to reach Product Service");
            }
        }
        public async Task<IEnumerable<ReadProductDto>> GetProductByname(string name)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5001/api/products/{name}/nameproduct");
            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{content}");
                var product = JsonSerializer.Deserialize<List<ReadProductDto>>(content);
                if (product != null)
                {
                    Console.WriteLine($"{product.Count()} platforms returned from Product Service");
                    return product;
                }
                throw new Exception("No product found");
            }
            else
            {
                throw new Exception("Unable to reach Product Service");
            }
        }
    }
}