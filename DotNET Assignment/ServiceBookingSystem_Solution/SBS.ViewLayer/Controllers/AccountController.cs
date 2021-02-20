using Newtonsoft.Json;
using SBS.BusinessEntities;
using SBS.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace SBS.ViewLayer.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        // GET: Account/Register
        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }
        // GET: Account/Login
        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        // POST: Account/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/Account/Register");
                var postTask = client.PostAsJsonAsync<Customer>("Register", customer);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("/Register");
                }
            }
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string EmailId, string password)
        {
            string baseAddress = "http://localhost:9622";
            password = Convert.ToBase64String(PassowrdEncrypt.Encrypt(password));
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/token");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", EmailId},
                    {"password", password}
                };

                password = Convert.ToBase64String(PassowrdEncrypt.Encrypt(password));

                var responseMessage = client.PostAsJsonAsync("token", "grant_type=password&username=" + EmailId + "&password=" + password);
                responseMessage.Wait();
                var content = new FormUrlEncodedContent(form);
                var responseTask = client.PostAsync("token", content);
                responseTask.Wait();

                var result = responseMessage.Result;
                Debug.WriteLine(result.Content);
                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = response.Content.ReadAsStringAsync().Result;
                    Token token = JsonConvert.DeserializeObject<Token>(responseStream);
                    Debug.WriteLine(token.AccessToken);
                    Session["token"] = token.AccessToken;

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
            return RedirectToAction("Login");
        }

        private class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }
        }

    }
}