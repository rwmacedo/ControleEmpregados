using System.Linq;
using System.Threading.Tasks;
using ControleEmpregados.Data;
using ControleEmpregados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleEmpregados.Controllers
{
    public class EmpregadoController : Controller

    {
       private readonly IESContext _context;

        public EmpregadoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Empregados.OrderBy(c => c.MATRICULA).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MATRICULA, NOME, DATA_DE_NASCIMENTO, FUNCAO, ESCOLARIDADE")] Empregado empregado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(empregado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(empregado);
        }

        // GET: Departamento/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados.FindAsync(id);
            if (empregado == null)
            {
                return NotFound();
            }
            return View(empregado);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("EmpregadoID, MATRICULA, NOME, DATA_DE_NASCIMENTO, FUNCAO, ESCOLARIDADE")] Empregado empregado)
        {
            if (id != empregado.EmpregadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregadoExists(empregado.EmpregadoID))
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
            return View(empregado);
        }

        //private bool EmpregadoExists(long? id)
        //{
        //    return _context.Empregados.Any(e => e.EmpregadoID == id);
        //}
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados.SingleOrDefaultAsync(m => m.EmpregadoID == id);
            if (empregado == null)
            {
                return NotFound();
            }

            return View(empregado);
        }
        
        // GET: Departamento/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empregado = await _context.Empregados.FirstOrDefaultAsync(m => m.EmpregadoID == id);
        if (empregado == null)
        {
            return NotFound();
        }

        return View(empregado);
    }

    // POST: Departamento/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var empregado = await _context.Empregados.FindAsync(id);
        _context.Empregados.Remove(empregado);
        await _context.SaveChangesAsync();
        TempData["Message"] = "Empregado " + empregado.NOME.ToUpper() + " foi removido";
        return RedirectToAction(nameof(Index));
    }
    private bool EmpregadoExists(long? id)
    {
        return _context.Empregados.Any(e => e.EmpregadoID == id);
    }

}
}
