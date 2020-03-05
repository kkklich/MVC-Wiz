using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWizerunek.Models;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MVCWizerunek.Controllers
{
    public class StudencisController : Controller
    {
        public string query = "select * from studenci order by id";
        private readonly MVCWizerunekContext _context;

        public StudencisController(MVCWizerunekContext context)
        {
            _context = context;
        }


        // GET: Studencis
       [HttpGet]
        public async Task<IActionResult> Index(string nazwa)
        {
            List<Studenci> stud = new List<Studenci>();


            

            if (nazwa != null)
            {
                query = nazwa;
            }
            var conn = _context.Database.GetDbConnection();

            try {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    

                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new Studenci { id=reader.GetInt32(6)  ,imie = reader.GetString(0), nazwisko = reader.GetString(1), data_urodzenia=reader.GetDateTime(2) ,miasto=reader.GetString(4), liczba_dzieci=reader.GetInt32(5) };
                            stud.Add(row);
                        }
                    }
                    reader.Dispose();
                }


            }
            finally
            {
                conn.Close();
            }

            ViewData["nazwa"] = nazwa;
            return View(stud);

           // return View(await _context.Studenci.ToListAsync());
            
            
            
            
            //return View(await _context.Studenci.ToListAsync());
        }

        // GET: Studencis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenci = await _context.Studenci
                .FirstOrDefaultAsync(m => m.id == id);
            if (studenci == null)
            {
                return NotFound();
            }

            return View(studenci);
        }

        // GET: Studencis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studencis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,imie,nazwisko,data_urodzenia,plec,miasto,liczba_dzieci")] Studenci studenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studenci);
        }

        // GET: Studencis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenci = await _context.Studenci.FindAsync(id);
            if (studenci == null)
            {
                return NotFound();
            }
            return View(studenci);
        }

        // POST: Studencis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,imie,nazwisko,data_urodzenia,plec,miasto,liczba_dzieci")] Studenci studenci)
        {
            if (id != studenci.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudenciExists(studenci.id))
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
            return View(studenci);
        }

        // GET: Studencis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenci = await _context.Studenci
                .FirstOrDefaultAsync(m => m.id == id);
            if (studenci == null)
            {
                return NotFound();
            }

            return View(studenci);
        }

        // POST: Studencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studenci = await _context.Studenci.FindAsync(id);
            _context.Studenci.Remove(studenci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudenciExists(int id)
        {
            return _context.Studenci.Any(e => e.id == id);
        }
    }
}
