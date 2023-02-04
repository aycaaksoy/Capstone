
using DTO.ApiDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static DTO.ApiDTOs.TeamDTO;

namespace Capstone.Controllers
{
    public class LichessApiConsumeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LichessApiConsumeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {   
            List<TeamMember> teamMembers = new List<TeamMember>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://lichess.org/api/team/casem-mavi/users")
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                teamMembers = JsonConvert.DeserializeObject<List<TeamMember>>(body);
                
                return View(teamMembers);
            }
        }
    }
}
