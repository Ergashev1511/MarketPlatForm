using MarketPlatForm.Api.Models;
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
    public class CategoryService : ICategoryService
    {
        public async Task<bool> Create(Category category)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, Auth.Api.Bae_Url + "/api/Category/Create");
                var json = JsonConvert.SerializeObject(category);

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
            catch
            {
                return false;
            }
        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{Auth.Api.Bae_Url}" + $"/api/Category/GetAll");

                HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
                string responce = await message.Content.ReadAsStringAsync();

                List<Category> result = JsonConvert.DeserializeObject<List<Category>>(responce)!;
                return result;
            }
            catch
            {
                return new List<Category>();
            }
        }

        public async Task<Category> GetById(long Id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Auth.Api.Bae_Url + "/api/Cateogory/id"); // Set your actual base URL here

                // Append the endpoint to the base address
                HttpResponseMessage message = await client.GetAsync(client.BaseAddress);

                if (message.IsSuccessStatusCode)
                {
                    var response = await message.Content.ReadAsStringAsync();
                    Category category = JsonConvert.DeserializeObject<Category>(response)!;
                    return category;
                }
                return new Category(); // Return an empty ProductDto if the request fails
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                return new Category(); // Return an empty ProductDto if an exception occurs
            }
        }
    }
}
