using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FE.Models;

namespace FE.Controllers
{
    public class CategoriesController : Controller
    {
        string baseurl = "http://localhost:59634/"; //NEW
        //private readonly NorthwindContext _context;

        //public CategoriesController(NorthwindContext context)
        //{
        //    _context = context;
        //}

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            List<Categories> list = new List<Categories>();//NEW
            //return View(await _context.Categories.ToListAsync());
            return View(); //NEW
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var categories = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.CategoryId == id);
            //if (categories == null)
            //{
            //    return NotFound();
            //}

            //return View(categories);
            return View(); //NEW
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description,Picture")] Categories categories)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(categories);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(categories);
            return View(); //NEW
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var categories = await _context.Categories.FindAsync(id);
            //if (categories == null)
            //{
            //    return NotFound();
            //}
            //return View(categories);
            return View(); //NEW
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description,Picture")] Categories categories)
        {
            //if (id != categories.CategoryId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(categories);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CategoriesExists(categories.CategoryId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(categories);
            return View(); //NEW
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var categories = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.CategoryId == id);
            //if (categories == null)
            //{
            //    return NotFound();
            //}

            //return View(categories);
            return View(); //NEW
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var categories = await _context.Categories.FindAsync(id);
            //_context.Categories.Remove(categories);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool CategoriesExists(int id)
        //{
        //    return _context.Categories.Any(e => e.CategoryId == id);
        //}
    }
}
