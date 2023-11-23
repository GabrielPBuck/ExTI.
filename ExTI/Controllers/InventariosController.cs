using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExTI.Data;
using ExTI.Models;

namespace ExTI.Controllers
{
    public class InventariosController : Controller
    {
        private readonly dbContext _context;

        public InventariosController(dbContext context)
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> Index()
        {
              return _context.Inventario != null ? 
                          View(await _context.Inventario.ToListAsync()) :
                          Problem("Entity set 'dbContext.Inventario'  is null.");
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .FirstOrDefaultAsync(m => m.IdInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventarios/Create
        public IActionResult Create()
        {
            InventarioModel model = new InventarioModel();
            model.ListaClientes = _context.CadClientes.ToList();
            model.ListaMaquinas = _context.CadMaquinas.ToList();            
            return View(model);
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInventario,IdCliente,IdMaquina,Valor,Quantidade")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInventario,IdCliente,IdMaquina,Valor,Quantidade")] Inventario inventario)
        {
            if (id != inventario.IdInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.IdInventario))
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
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inventario == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .FirstOrDefaultAsync(m => m.IdInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventario == null)
            {
                return Problem("Entity set 'dbContext.Inventario'  is null.");
            }
            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario != null)
            {
                _context.Inventario.Remove(inventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
          return (_context.Inventario?.Any(e => e.IdInventario == id)).GetValueOrDefault();
        }
    }
}
