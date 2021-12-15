using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI.Login.Servicios
{
    public class ProveedorServicio
    {
        string baseurl = "https://api-restauranteve.azurewebsites.net/index.html";
        public List<Models.Proveedor> GetAllAsync() 
        {
            List<Models.Proveedor> aux = new List<Models.Proveedor>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/proveedor").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Proveedor>>(auxres);
                }
            }
            return aux;
        }
    }
}
