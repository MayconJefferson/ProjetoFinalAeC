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
    public class CandidatosController : Controller
    {
        private readonly DbContexto _context;

        public CandidatosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Candidatos.Include(c => c.Profissao);
            return View(await dbContexto.ToListAsync());
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .Include(c => c.Profissao)
                .FirstOrDefaultAsync(m => m.Id_Candidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            ViewData["ProfissaoID"] = new SelectList(_context.Profissoes, "Id", "Descricao");
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Candidato,Nome,Nascimento,Cep,Logradouro,Numero,Bairro,Cidade,UF,Telefone,Email,ProfissaoID")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfissaoID"] = new SelectList(_context.Profissoes, "Id", "Descricao", candidato.ProfissaoID);
            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            ViewData["ProfissaoID"] = new SelectList(_context.Profissoes, "Id", "Descricao", candidato.ProfissaoID);
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Candidato,Nome,Nascimento,Cep,Logradouro,Numero,Bairro,Cidade,UF,Telefone,Email,ProfissaoID")] Candidato candidato)
        {
            if (id != candidato.Id_Candidato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.Id_Candidato))
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
            ViewData["ProfissaoID"] = new SelectList(_context.Profissoes, "Id", "Descricao", candidato.ProfissaoID);
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .Include(c => c.Profissao)
                .FirstOrDefaultAsync(m => m.Id_Candidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id_Candidato == id);
        }
    }
}
