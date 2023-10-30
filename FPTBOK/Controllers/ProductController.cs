using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTBOK.Models;

namespace FPTBOK.Controllers
{
    public class ProductController : Controller
    {
        private readonly testASMContext _context;
         private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(testASMContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        // get file name 
         private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }
        // GET: Product
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && !User.IsInRole("Customer")){
             var testContext = _context.Products.Include(b => b.IdCatNavigation.Status == "Yes");
               return View(await testContext.ToListAsync());
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.cat = _context.Categories.FirstOrDefault(c=> c.Id == product.IdCat);
            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {

// if (_context.Categories != null)
//             {
//                 var categories = await _context.Categories
//                     .Where(c => c.Status == "Yes")
//                     .ToListAsync();

//                 return View(categories);
//             }
//             else
//             {
//                 return Problem("Entity set 'BookContext.Categories' is null.");
//             }
             ViewData["IdCat"] = new SelectList(_context.Categories.Where(c => c.Status == "Yes"), "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Image,IdCat,ImageFile")] Product product)
        {
           if (ModelState.IsValid)
            {
                string uniqueFilename = GetUniqueFileName(product.ImageFile.FileName);
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string filePath = Path.Combine(uploadsFolder, uniqueFilename);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                product.Image = uniqueFilename;

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
             ViewData["IdCat"] = new SelectList(_context.Categories, "Id", "Name");
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var idCatList = _context.Categories.Where(c => c.Status == "Yes").ToList();
            ViewData["IdCat"] = new SelectList(idCatList, "Id", "Name");
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Image,IdCat,ImageFile")] Product product)
        {
             

            if (id != product.Id)
            {
                return NotFound();
            }
                
            string uniqueFilename = GetUniqueFileName(product.ImageFile.FileName);
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            string filePath = Path.Combine(uploadsFolder, uniqueFilename);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                product.Image = uniqueFilename;
                
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'testASMContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
