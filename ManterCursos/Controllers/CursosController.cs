using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManterCursos.Data;
using ManterCursos.Controllers;

namespace ManterCursos.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ManterCursosContext _context;

        public CursosController(ManterCursosContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.CursoId)
            {
                return BadRequest();
            }

            if (!DataAtual(curso.dtInicio))
            {
                return BadRequest("Data não pode estar no passado!");
            }

            if (!DataValida(curso.dtInicio, curso.dtTermino))
            {
                return BadRequest("Data de início está após a data de término!");
            }

            if (!ValidaNome(curso.CursoId, curso.Nome))
            {
                return BadRequest("Já existe um curso com este nome!");
            }

            if (VerificaIntervalo(curso.dtInicio, curso.dtTermino))
            {
                _context.Entry(curso).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            DateTime DtModificada;
            return Ok(DtModificada = DateTime.Now);
        }

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            
                
            if (!ValidaNome(curso.CursoId, curso.Nome))
            {
                return BadRequest("Já existe um curso com este nome!");
            }

            if (!DataAtual(curso.dtInicio))
            {
                return BadRequest("Data no passado.");
            }

            if (!DataValida(curso.dtInicio, curso.dtTermino))
            {
                return BadRequest("Data de início está após a data de término!");
            }

            if (VerificaIntervalo(curso.dtInicio, curso.dtTermino))
            {
                curso.DtCriacao = DateTime.Now;

                _context.Cursos.Add(curso);
                await _context.SaveChangesAsync();

                return Ok( new { id = curso.CursoId, DtCriacao = DateTime.Now});
            }

            else
            {
                return BadRequest("Existe curso neste período!");
            }
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            if (curso.dtTermino < DateTime.Now)
            {
                return BadRequest("Este curso já foi realizado, portanto não pode ser excluído!");
            }

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.CursoId == id);
        }

        private bool VerificaIntervalo(DateTime dtInicio, DateTime dtTermino)
        {
            var result = from obj in _context.Cursos select obj;
            result = result.Where(x => x.dtTermino >= dtInicio)
                .Where(x => x.dtInicio <= dtTermino);

            if (!result.Any())
            {
                return true;
            }
            return false;
        }

        private bool DataAtual(DateTime dtInicio)
        {

            if (dtInicio >= DateTime.Now)
            {
                return true;
            }
            return false;
        }

        private bool DataValida(DateTime Inicio, DateTime fim)
        {
            if (Inicio < fim)
            {
                return true;
            }
            return false;
        }

        private bool ValidaNome(int id, string nome)
        {
            var result = from obj in _context.Cursos select obj;

            result = result.Where(x => x.Nome == nome).Where(x => x.CursoId != id);

            if (!result.Any())
            {
                return true;
            }
            return false;
            
            
        }
    }
}
