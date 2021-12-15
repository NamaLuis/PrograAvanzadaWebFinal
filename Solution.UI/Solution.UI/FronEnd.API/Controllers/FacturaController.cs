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
    public class FacturaController : Controller
    {
        string baseurl = "http://localhost:18658/";

        callapis.EmpleadoServicio empleadoservicios = new callapis.EmpleadoServicio();
        callapis.ProductoServicio productoservicios = new callapis.ProductoServicio();
        callapis.ClienteServicio clienteservicios = new callapis.ClienteServicio();

        //public FacturaController(restauranteVerdeContext context)
        //{
        //    _context = context;
        //}

        // GET: Factura
        public async Task<IActionResult> Index()
        {
            List<Models.Factura> aux = new List<Models.Factura>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/factura");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Factura>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Factura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = GetById(id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Factura/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(empleadoservicios.GetAllAsync(), "IdEmpleado", "Nombre");
            ViewData["IdProducto"] = new SelectList(productoservicios.GetAllAsync(), "IdProducto", "NombreProducto");
            ViewData["IdCliente"] = new SelectList(clienteservicios.GetAllAsync(), "Cedula", "Nombre");            
            return View();
        }

        // POST: Factura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,Fecha,IdProducto,IdCliente,IdEmpleado,Monto,Descuento")] Models.Factura factura)
        {
            if (ModelState.IsValid)
            {
                using(var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(factura);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/factura", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdEmpleado"] = new SelectList(empleadoservicios.GetAllAsync(), "IdEmpleado", "Nombre", factura.IdEmpleado);
            ViewData["IdProducto"] = new SelectList(productoservicios.GetAllAsync(), "IdProducto", "NombreProducto", factura.IdProducto);
            ViewData["IdCliente"] = new SelectList(clienteservicios.GetAllAsync(), "Cedula", "Nombre", factura.IdCliente);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = GetById(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(empleadoservicios.GetAllAsync(), "IdEmpleado", "Nombre", factura.IdEmpleado);
            ViewData["IdProducto"] = new SelectList(productoservicios.GetAllAsync(), "IdProducto", "NombreProducto", factura.IdProducto);
            ViewData["IdCliente"] = new SelectList(clienteservicios.GetAllAsync(), "Cedula", "Nombre", factura.IdCliente);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,Fecha,IdProducto,IdCliente,IdEmpleado,Monto,Descuento")] Models.Factura factura)
        {
            if (id != factura.IdFactura)
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
                        var content = JsonConvert.SerializeObject(factura);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/factura/" + id, byteContent).Result;

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
            ViewData["IdEmpleado"] = new SelectList(empleadoservicios.GetAllAsync(), "IdEmpleado", "Nombre", factura.IdEmpleado);
            ViewData["IdProducto"] = new SelectList(productoservicios.GetAllAsync(), "IdProducto", "NombreProducto", factura.IdProducto);
            ViewData["IdCliente"] = new SelectList(clienteservicios.GetAllAsync(), "Cedula", "Nombre", factura.IdCliente);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = GetById(id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/factura/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return (GetById(id) != null);
        }

        private Models.Factura GetById(int? id)
        {
            Models.Factura aux = new Models.Factura();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/factura/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Factura>(auxres);
                }
            }
            return aux;
        }
    }
}
