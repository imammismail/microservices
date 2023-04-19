using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OrderServices.Dtos;

namespace OrderServices.SyncDataServices
{
    public class HttpWalletDataClient : IWalletDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpWalletDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<ReadWalletDto>> ReturnAllWallet()
        {
            var response = await _httpClient.GetAsync(_configuration["WalletService"]);
            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{content}");
                var wallet = JsonSerializer.Deserialize<List<ReadWalletDto>>(content);
                if (wallet != null)
                {
                    Console.WriteLine($"{wallet.Count()} platforms returned from Wallet Service");
                    return wallet;
                }
                throw new Exception("No product found");
            }
            else
            {
                throw new Exception("Unable to reach Product Service");
            }
        }
        public async Task<IEnumerable<ReadWalletDto>> GetWalletByname(string name)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5001/api/Wallet/{name}");
            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{content}");
                var product = JsonSerializer.Deserialize<List<ReadWalletDto>>(content);
                if (product != null)
                {
                    Console.WriteLine($"{product.Count()} wallet returned from wallet Service");
                    return product;
                }
                throw new Exception("No wallet found");
            }
            else
            {
                throw new Exception("Unable to reach wallet Service");
            }
        }
    }
}