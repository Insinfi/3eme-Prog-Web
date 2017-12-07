using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.IO;
using RestSharp;
using RestSharp.Deserializers;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index3()
        {
            var client = new RestClient("http://127.0.0.1:8080/api/home");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            JsonDeserializer deserial = new JsonDeserializer();
            IEnumerable<Models.User> list = deserial.Deserialize<IEnumerable<Models.User>>(response);
            return View(list);
        }

        public async Task<JsonResult> GetUserInfo(string id)
        {
            Models.TokenResponse MyToken;

            if (Session["Token"] == null)
            {
                MyToken = await Authenticate("toto", "toto");
                if (MyToken.Result == 1)
                    Session["Token"] = MyToken;
                else
                    Session["Token"] = null;
            }
            else
            {
                MyToken = (Models.TokenResponse)Session["Token"];
            }
            var client = new RestClient($"http://127.0.0.1:8080/api/home/{MyToken.Token}/{id}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            JsonDeserializer deserial = new JsonDeserializer();
            Models.FullUser user = deserial.Deserialize<Models.FullUser>(response);
            return Json(user);
        }

        public async Task<ActionResult> Index()
        {
            Models.TokenResponse MyToken;

            if (Session["Token"] == null)
            {
                MyToken = await Authenticate("toto", "toto");
                if (MyToken.Result == 1)
                    Session["Token"] = MyToken;
                else
                    Session["Token"] = null;
            }
            else
            {
                MyToken = (Models.TokenResponse)Session["Token"];
            }

            HttpClient client = new HttpClient();
            var url = $"http://127.0.0.1:8080/api/home/{MyToken.Token}/";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(url).Result.Content;
            string responseString = response.ReadAsStringAsync().Result;
            IEnumerable<Models.User> list = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Models.User>>(responseString);
            return View(list);
        }

        private async Task<Models.TokenResponse> Authenticate(string UserName, string Password)
        {
            HttpClient client = new HttpClient();
            var url = "http://127.0.0.1:8080/api/home/authenticate";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Username", UserName),
                new KeyValuePair<string, string>("Password", Password)

            });

            HttpResponseMessage response = await client.PostAsync(url, content);
            var data = await response.Content.ReadAsStringAsync();
            Models.TokenResponse MyToken = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TokenResponse>(data);
            return MyToken;
        }
    }
}