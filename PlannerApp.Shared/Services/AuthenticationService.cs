using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Services
{
    public class AuthenticationService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public AuthenticationService(string url)
        {
            _baseUrl = url;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            var result = await client.PostAsync<UserManagerResponse>($"{_baseUrl}/api/Auth/Register", request);
            return result.Result;
        }
    }
}
