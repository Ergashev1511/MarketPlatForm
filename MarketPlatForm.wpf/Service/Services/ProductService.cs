using MarketPlatForm.Api.Models;
using MarketPlatForm.wpf.Auth;
using MarketPlatForm.wpf.Service.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlatForm.wpf.Service.Services
{
    public class ProductService : IProductService
    {
        public async Task<bool> Create(Product product)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, Auth.Api.Bae_Url + "/api/Product/Create");
                var json=JsonConvert.SerializeObject(product);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                message.Content = content;

                var response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch { return false; }
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{Auth.Api.Bae_Url}" + $"/api/Product/GetAll");

                HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
                string responce = await message.Content.ReadAsStringAsync();

                List<Product> result = JsonConvert.DeserializeObject<List<Product>>(responce)!;
                return result;
            }
            catch
            {
                return new List<Product>();
            }
        }

        public async Task<Product> GetById(long Id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Auth.Api.Bae_Url + "/api/Product/Id"); // Set your actual base URL here

                // Append the endpoint to the base address
                HttpResponseMessage message = await client.GetAsync(client.BaseAddress);

                if (message.IsSuccessStatusCode)
                {
                    var response = await message.Content.ReadAsStringAsync();
                    Product product = JsonConvert.DeserializeObject<Product>(response)!;
                    return product;
                }
                return new Product(); // Return an empty ProductDto if the request fails
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                return new Product(); // Return an empty ProductDto if an exception occurs
            }
        }
    }
}
