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
//    public class CategoriesController : Controller
//    {
//        string baseurl = "http://localhost:62460/"; //NEW //OJO es el mismo puerto del backend BE.API
//        //private readonly NorthwindContext _context;

//        //public CategoriesController(NorthwindContext context)
//        //{
//        //    _context = context;
//        //}

//        // GET: Categories
//        public async Task<IActionResult> Index()
//        {
//            List<Categories> list = new List<Categories>();//NEW

//            using (var cl = new HttpClient())
//            {
//                cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                cl.DefaultRequestHeaders.Clear();
//                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//Declaramos que queremos info convertida en JSON
//                HttpResponseMessage res = await cl.GetAsync("api/Categories");//Get async del API Categories

//                if (res.IsSuccessStatusCode)
//                {
//                    var auxres = res.Content.ReadAsStringAsync().Result;
//                    list = JsonConvert.DeserializeObject<List<Categories>>(auxres);
//                }
//            }
//                //return View(await _context.Categories.ToListAsync());
//                return View(list); //NEW
//        }


//        // GET: Categories/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var categories = GetById(id);
//            if (categories == null)
//            {
//                return NotFound();
//            }

//            return View(categories);
//        }

//        // GET: Categories/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Categories/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description,Picture")] Categories categories)
//        {
//            if (ModelState.IsValid)
//            {
//                //    _context.Add(categories);
//                //    await _context.SaveChangesAsync();
//                //    return RedirectToAction(nameof(Index));
//                using (var cl = new HttpClient())
//                {
//                    cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                    var content = JsonConvert.SerializeObject(categories);
//                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
//                    var byteContent = new ByteArrayContent(buffer);
//                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");//Declaramos que queremos info convertida en JSON
//                    var postTask = cl.PostAsync("api/Categories", byteContent).Result;// POST del API Categories

//                    if (postTask.IsSuccessStatusCode)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                }
//            }
//            return View(categories);
//        }

//        // GET: Categories/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var categories = GetById(id);
//            if (categories == null)
//            {
//                return NotFound();
//            }
//            return View(categories);

//        }

//        // POST: Categories/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description,Picture")] Categories categories)
//        {
//            if (id != categories.CategoryId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    using (var cl = new HttpClient())
//                    {
//                        cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                        var content = JsonConvert.SerializeObject(categories);
//                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
//                        var byteContent = new ByteArrayContent(buffer);
//                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");//Declaramos que queremos info convertida en JSON
//                        var postTask = cl.PutAsync("api/Categories/" + id, byteContent).Result;// PUT del API Categories

//                        if (postTask.IsSuccessStatusCode)
//                        {
//                            return RedirectToAction("Index");
//                        }
//                    }
//                }
//                catch (Exception)
//                {
//                    if (!CategoriesExists(categories.CategoryId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(categories);

//        }

//        // GET: Categories/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var categories = GetById(id);
//            if (categories == null)
//            {
//                return NotFound();
//            }

//            return View(categories);

//        }

//        // POST: Categories/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var categories = GetById(id);
//            using (var cl = new HttpClient())
//            {
//                cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                cl.DefaultRequestHeaders.Clear();
//                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//Declaramos que queremos info convertida en JSON
//                HttpResponseMessage res = await cl.DeleteAsync("api/Categories/" + id);//Delete async del API Categories

//                if (res.IsSuccessStatusCode)
//                {
//                    return RedirectToAction("Index");
//                }
//            }
//            return RedirectToAction("Index");
//        }

//        private bool CategoriesExists(int id)//deme cualquier objeto con este id, y validar si existe
//        {
//            return GetById(id)!= null;
//        }


//        private Categories GetById(int? id)//El simbolo de pregunta es xq permite nulos.
//    {
//        Categories aux = new Categories();
//            using (var cl = new HttpClient())
//            {
//                cl.BaseAddress = new Uri(baseurl);//El url donde invocamos el backend
//                cl.DefaultRequestHeaders.Clear();
//                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//Declaramos que queremos info convertida en JSON
//                HttpResponseMessage res = cl.GetAsync("api/Categories/" + id).Result;//Get async del API Categories

//                if (res.IsSuccessStatusCode)
//                {
//                    var auxres = res.Content.ReadAsStringAsync().Result;
//                    aux = JsonConvert.DeserializeObject<Categories>(auxres);
//                }
//            }
//            return aux;
//        }
//    }
//}
