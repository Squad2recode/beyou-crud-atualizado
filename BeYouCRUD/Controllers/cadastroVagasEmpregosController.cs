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
    public class cadastroVagasEmpregosController : Controller
    {
        private readonly Context _context;

        public cadastroVagasEmpregosController(Context context)
        {
            _context = context;
        }

        // GET: cadastroVagasEmpregos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroVagasEmprego.ToListAsync());
        }

        // GET: cadastroVagasEmpregos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVagasEmprego = await _context.CadastroVagasEmprego
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroVagasEmprego == null)
            {
                return NotFound();
            }

            return View(cadastroVagasEmprego);
        }

        // GET: cadastroVagasEmpregos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadastroVagasEmpregos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome_empresa,cargo,cidade_UF,salario,beneficios")] cadastroVagasEmprego cadastroVagasEmprego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroVagasEmprego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(cadastroVagasEmprego);
        }

        // GET: cadastroVagasEmpregos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVagasEmprego = await _context.CadastroVagasEmprego.FindAsync(id);
            if (cadastroVagasEmprego == null)
            {
                return NotFound();
            }
            return View(cadastroVagasEmprego);
        }

        // POST: cadastroVagasEmpregos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome_empresa,cargo,cidade_UF,salario,beneficios")] cadastroVagasEmprego cadastroVagasEmprego)
        {
            if (id != cadastroVagasEmprego.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroVagasEmprego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadastroVagasEmpregoExists(cadastroVagasEmprego.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("verVagasDeEmprego", "Home");
            }
            return View(cadastroVagasEmprego);
        }

        // GET: cadastroVagasEmpregos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVagasEmprego = await _context.CadastroVagasEmprego
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroVagasEmprego == null)
            {
                return NotFound();
            }

            return View(cadastroVagasEmprego);
        }

        // POST: cadastroVagasEmpregos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroVagasEmprego = await _context.CadastroVagasEmprego.FindAsync(id);
            _context.CadastroVagasEmprego.Remove(cadastroVagasEmprego);
            await _context.SaveChangesAsync();
            return RedirectToAction("verVagasDeEmprego", "Home");
        }

        private bool cadastroVagasEmpregoExists(int id)
        {
            return _context.CadastroVagasEmprego.Any(e => e.ID == id);
        }
    }
}

