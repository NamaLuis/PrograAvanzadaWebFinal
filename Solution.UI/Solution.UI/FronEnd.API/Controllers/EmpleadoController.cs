using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using callapis = FrontEnd.API.Servicios;



namespace FrontEnd.API.Controllers
{
    public class EmpleadoController : Controller
    {
        string baseurl = "http://localhost:18658/";

        callapis.GServicio servicios = new callapis.GServicio();
        callapis.RServicio Rolservicios = new callapis.RServicio();

        //public EmpleadoesController(restauranteVerdeContext context)
        //{
        //    _context = context;
        //}

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            List<Models.Empleado> aux = new List<Models.Empleado>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/empleado");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Empleado>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = GetById(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            ViewData["IdPuesto"] = new SelectList(servicios.GetAllAsync(), "IdPuesto", "Nombre");
            ViewData["IdRol"] = new SelectList(Rolservicios.GetAllAsync(), "IdRol", "NombreRol");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,Nombre,Apellido1,Apellido2,Salario,FechaIngreso,IdPuesto,IdRol")] Models.Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                using(var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(empleado);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/empleado", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdPuesto"] = new SelectList(servicios.GetAllAsync(), "IdPuesto", "Nombre", empleado.IdPuesto);
            ViewData["IdRol"] = new SelectList(Rolservicios.GetAllAsync(), "IdRol", "NombreRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = GetById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdPuesto"] = new SelectList(servicios.GetAllAsync(), "IdPuesto", "Nombre", empleado.IdPuesto);
            ViewData["IdRol"] = new SelectList(Rolservicios.GetAllAsync(), "IdRol", "NombreRol", empleado.IdRol);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Nombre,Apellido1,Apellido2,Salario,FechaIngreso,IdPuesto,IdRol")] Models.Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseurl);
                        var content = JsonConvert.SerializeObject(empleado);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/empleado/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPuesto"] = new SelectList(servicios.GetAllAsync(), "IdPuesto", "Nombre", empleado.IdPuesto);
            ViewData["IdRol"] = new SelectList(Rolservicios.GetAllAsync(), "IdRol", "NombreRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = GetById(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/empleado/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return (GetById(id) != null);
        }

        private Models.Empleado GetById(int? id)
        {
            Models.Empleado aux = new Models.Empleado();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/empleado/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Empleado>(auxres);
                }
            }
            return aux;
        }
    }
}
