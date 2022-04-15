//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using FE.Models;
//using System.Net.Http;
//using Newtonsoft.Json;

//namespace FE.Controllers
//{
//    public class ProductsController : Controller
//    {
//        string baseurl = "http://localhost:62460/"; //NEW //OJO es el mismo puerto del backend BE.API


//        // GET: Products
//        public async Task<IActionResult> Index()
//        {

//            List<Products> list = new List<Products>();//NEW

//            using (var cl = new HttpClient())
//            {
//                cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                cl.DefaultRequestHeaders.Clear();
//                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//Declaramos que queremos info convertida en JSON
//                HttpResponseMessage res = await cl.GetAsync("api/Products");//Get async del API 

//                if (res.IsSuccessStatusCode)
//                {
//                    var auxres = res.Content.ReadAsStringAsync().Result;
//                    list = JsonConvert.DeserializeObject<List<Products>>(auxres);
//                }
//            }

//            return View(list); //NEW
//        }
    

//        // GET: Products/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var products = GetById(id);
//            if (products == null)
//            {
//                return NotFound();
//            }

//            return View(products);
//        }

//        // GET: Products/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Products/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,DateDiscontinued")] Products products)
//        {
//        if (ModelState.IsValid)
//            {

//                using (var cl = new HttpClient())
//                {
//                    cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                    var content = JsonConvert.SerializeObject(products);
//                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
//                    var byteContent = new ByteArrayContent(buffer);
//                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");//Declaramos que queremos info convertida en JSON
//                    var postTask = cl.PostAsync("api/Products", byteContent).Result;// POST del API products

//                    if (postTask.IsSuccessStatusCode)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                }
//            }
//            return View(products);
//        }

//    // GET: Products/Edit/5
//    public async Task<IActionResult> Edit(int? id)
//    {
//        if (id == null)
//        {
//            return NotFound();
//        }

//        var products = GetById(id);
//        if (products == null)
//        {
//            return NotFound();
//        }
//        return View(products);

//    }

//    // POST: Products/Edit/5
//    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,DateDiscontinued")] Products products)
//        {
//        if (id != products.ProductId)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                using (var cl = new HttpClient())
//                {
//                    cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                    var content = JsonConvert.SerializeObject(products);
//                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
//                    var byteContent = new ByteArrayContent(buffer);
//                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");//Declaramos que queremos info convertida en JSON
//                    var postTask = cl.PutAsync("api/Products/" + id, byteContent).Result;// PUT del API products

//                    if (postTask.IsSuccessStatusCode)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                if (!ProductsExists(products.ProductId))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        return View(products);
//    }

//        // GET: Products/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var products = GetById(id);
//            if (products == null)
//            {
//                return NotFound();
//            }

//            return View(products);

//        }


//        // POST: Products/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
    
//            var products = GetById(id);
//            using (var cl = new HttpClient())
//            {
//                cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                cl.DefaultRequestHeaders.Clear();
//                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//Declaramos que queremos info convertida en JSON
//                HttpResponseMessage res = await cl.DeleteAsync("api/Products/" + id);//Delete async del API products

//                if (res.IsSuccessStatusCode)
//                {
//                    return RedirectToAction("Index");
//                }
//            }
//            return RedirectToAction("Index");
//        }

//        private bool ProductsExists(int id)//deme cualquier objeto con este id, y validar si existe
//        {
//            return GetById(id) != null;
//        }
//        private Products GetById(int? id)//El simbolo de pregunta es xq permite nulos.
//        {
//        Products aux = new Products();
//            using (var cl = new HttpClient())
//            {
//                cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                cl.DefaultRequestHeaders.Clear();
//                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//Declaramos que queremos info convertida en JSON
//                HttpResponseMessage res = cl.GetAsync("api/Products/" + id).Result;//Get async del API 

//                if (res.IsSuccessStatusCode)
//                {
//                    var auxres = res.Content.ReadAsStringAsync().Result;
//                    aux = JsonConvert.DeserializeObject<Products>(auxres);
//                }
//            }
//            return aux;
//        }
//    }
//}

