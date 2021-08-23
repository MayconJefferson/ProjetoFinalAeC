using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetoFinalAeC.Models;
using projetoFinalAeC.Servicos;

namespace projetoFinalAeC.Controllers
{
    public class EmpregosController : Controller
    {
        private readonly DbContexto _context;

        public EmpregosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Empregos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empregos.ToListAsync());
        }

        // GET: Empregos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprego = await _context.Empregos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprego == null)
            {
                return NotFound();
            }

            return View(emprego);
        }

        // GET: Empregos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empregos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Emprego emprego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emprego);
        }

        // GET: Empregos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprego = await _context.Empregos.FindAsync(id);
            if (emprego == null)
            {
                return NotFound();
            }
            return View(emprego);
        }

        // POST: Empregos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Emprego emprego)
        {
            if (id != emprego.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregoExists(emprego.Id))
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
            return View(emprego);
        }

        // GET: Empregos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprego = await _context.Empregos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprego == null)
            {
                return NotFound();
            }

            return View(emprego);
        }

        // POST: Empregos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprego = await _context.Empregos.FindAsync(id);
            _context.Empregos.Remove(emprego);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregoExists(int id)
        {
            return _context.Empregos.Any(e => e.Id == id);
        }
    }
}
