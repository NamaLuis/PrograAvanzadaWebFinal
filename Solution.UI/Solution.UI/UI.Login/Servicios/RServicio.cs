using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI.Login.Servicios
{
    public class RServicio
    {
        string baseurl = "https://api-restauranteve.azurewebsites.net/index.html";
        public List<Models.Rol> GetAllAsync() 
        {
            List<Models.Rol> aux = new List<Models.Rol>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/rol").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Rol>>(auxres);
                }
            }
            return aux;
        }
    }
}
