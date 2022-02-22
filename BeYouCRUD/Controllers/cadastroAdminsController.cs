#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeYouCRUD.Models;

namespace BeYouCRUD.Controllers
{
    public class cadastroAdminsController : Controller
    {
        private readonly Context _context;

        public cadastroAdminsController(Context context)
        {
            _context = context;
        }

        

        // GET: cadastroAdmins
        public async Task<IActionResult> Index()
        {
            return View(await _context.cadastroAdmins.ToListAsync());
        }

        // GET: cadastroAdmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAdmin = await _context.cadastroAdmins
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroAdmin == null)
            {
                return NotFound();
            }

            return View(cadastroAdmin);
        }

        // GET: cadastroAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadastroAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome_admin,email,telefone,senha")] cadastroAdmin cadastroAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroAdmin);
        }

        // GET: cadastroAdmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAdmin = await _context.cadastroAdmins.FindAsync(id);
            if (cadastroAdmin == null)
            {
                return NotFound();
            }
            return View(cadastroAdmin);
        }

        // POST: cadastroAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome_admin,email,telefone,senha")] cadastroAdmin cadastroAdmin)
        {
            if (id != cadastroAdmin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadastroAdminExists(cadastroAdmin.ID))
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
            return View(cadastroAdmin);
        }

        // GET: cadastroAdmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroAdmin = await _context.cadastroAdmins
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroAdmin == null)
            {
                return NotFound();
            }

            return View(cadastroAdmin);
        }

        // POST: cadastroAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroAdmin = await _context.cadastroAdmins.FindAsync(id);
            _context.cadastroAdmins.Remove(cadastroAdmin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cadastroAdminExists(int id)
        {
            return _context.cadastroAdmins.Any(e => e.ID == id);
        }
    }
}
