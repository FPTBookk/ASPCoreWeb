using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookFPTShop.Models;

namespace BookFPTShop.Controllers
{
    public class OrderBookController : Controller
    {
        private readonly FPTDTBContext _context;

        public OrderBookController(FPTDTBContext context)
        {
            _context = context;
        }

        // GET: OrderBook
        public async Task<IActionResult> Index()
        {
              return _context.OrderBooks != null ? 
                          View(await _context.OrderBooks.ToListAsync()) :
                          Problem("Entity set 'FPTDTBContext.OrderBooks'  is null.");
        }

        // GET: OrderBook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderBooks == null)
            {
                return NotFound();
            }

            var orderBook = await _context.OrderBooks
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderBook == null)
            {
                return NotFound();
            }

            return View(orderBook);
        }

        // GET: OrderBook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderBook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,Address,TotalAmount,OrderStatus")] OrderBook orderBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderBook);
        }

        // GET: OrderBook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderBooks == null)
            {
                return NotFound();
            }

            var orderBook = await _context.OrderBooks.FindAsync(id);
            if (orderBook == null)
            {
                return NotFound();
            }
            return View(orderBook);
        }

        // POST: OrderBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,Address,TotalAmount,OrderStatus")] OrderBook orderBook)
        {
            if (id != orderBook.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderBookExists(orderBook.OrderId))
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
            return View(orderBook);
        }

        // GET: OrderBook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderBooks == null)
            {
                return NotFound();
            }

            var orderBook = await _context.OrderBooks
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderBook == null)
            {
                return NotFound();
            }

            return View(orderBook);
        }

        // POST: OrderBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderBooks == null)
            {
                return Problem("Entity set 'FPTDTBContext.OrderBooks'  is null.");
            }
            var orderBook = await _context.OrderBooks.FindAsync(id);
            if (orderBook != null)
            {
                _context.OrderBooks.Remove(orderBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderBookExists(int id)
        {
          return (_context.OrderBooks?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
