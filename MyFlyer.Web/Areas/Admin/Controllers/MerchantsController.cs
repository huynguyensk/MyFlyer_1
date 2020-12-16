using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFlyer.Data;
using MyFlyer.Model.Entities;

namespace MyFlyer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MerchantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MerchantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Merchants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merchants.ToListAsync());
        }

        // GET: Admin/Merchants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // GET: Admin/Merchants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Merchants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LogoFile,Url,ShowInHome,Id,IsActive")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchant);
        }

        // GET: Admin/Merchants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.FindAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            return View(merchant);
        }

        // POST: Admin/Merchants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LogoFile,Url,ShowInHome,Id,IsActive")] Merchant merchant)
        {
            if (id != merchant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantExists(merchant.Id))
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
            return View(merchant);
        }

        // GET: Admin/Merchants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // POST: Admin/Merchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchant = await _context.Merchants.FindAsync(id);
            _context.Merchants.Remove(merchant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantExists(int id)
        {
            return _context.Merchants.Any(e => e.Id == id);
        }
    }
}
