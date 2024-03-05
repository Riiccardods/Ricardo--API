using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RICARDOAPI.API.Data;
using RICARDOAPI.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RICARDOAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MensagemContatoController : ControllerBase
    {
        private readonly DataContext _context;

        public MensagemContatoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MensagemContato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MensagemContato>>> GetMensagensContato()
        {
            return await _context.MensagensContato.ToListAsync();
        }

        // GET: api/MensagemContato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MensagemContato>> GetMensagemContato(int id)
        {
            var mensagemContato = await _context.MensagensContato.FindAsync(id);

            if (mensagemContato == null)
            {
                return NotFound();
            }

            return mensagemContato;
        }

        // POST: api/MensagemContato
        [HttpPost]
        public async Task<ActionResult<MensagemContato>> PostMensagemContato(MensagemContato mensagemContato)
        {
            _context.MensagensContato.Add(mensagemContato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMensagemContato", new { id = mensagemContato.Id }, mensagemContato);
        }

        // PUT: api/MensagemContato/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensagemContato(int id, MensagemContato mensagemContato)
        {
            if (id != mensagemContato.Id)
            {
                return BadRequest();
            }

            _context.Entry(mensagemContato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemContatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/MensagemContato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensagemContato(int id)
        {
            var mensagemContato = await _context.MensagensContato.FindAsync(id);
            if (mensagemContato == null)
            {
                return NotFound();
            }

            _context.MensagensContato.Remove(mensagemContato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MensagemContatoExists(int id)
        {
            return _context.MensagensContato.Any(e => e.Id == id);
        }
    }
}
