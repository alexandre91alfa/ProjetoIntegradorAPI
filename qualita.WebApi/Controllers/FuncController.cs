using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qualita.Domain;
using qualita.WebApi.repository;

namespace qualita.WebApi.Controllers
{
    [Route("v1")]
    public class FuncController : Controller
    {
        private readonly DbFunc _context;

        public FuncController(DbFunc context)
        {
            _context = context;
        }
        [HttpGet("staff")]
        public async Task<IActionResult> GetFuncionarios()
        {
            try
            {
                var result = await _context.staffs.ToListAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Connect DB");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneFuncionarios(int id)
        {
            try
            {
                var result = await _context.staffs.FirstOrDefaultAsync(x => x.id == id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Connect DB");
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> PostAdicionar(Staff func)
        {

            if (!string.IsNullOrEmpty(func.id.ToString())
            && !string.IsNullOrEmpty(func.name.ToString())
            && !string.IsNullOrEmpty(func.function.ToString())
            && !string.IsNullOrEmpty(func.rg.ToString())
            && !string.IsNullOrEmpty(func.imgUrl.ToString()))
            {

                try
                {
                    _context.Add(func);
                    await _context.SaveChangesAsync();
                    return Ok("Dados Salvos com sucesso");
                }
                catch (System.Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Connect DB");
                }
            }
            else
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable, "value null");

            }

        }
        [HttpPut("pstaff/{id}")]
        public async Task<IActionResult> PutStaff(long id, Staff func)
        {
            if (id != func.id)
            {
                return BadRequest();
            }

            _context.Entry(func).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok("Alteração feita com sucesso");
        }

        // DELETE: v1/5
        [HttpDelete("delstaff/{id}")]
        public async Task<ActionResult<Staff>> DeleteStaff(long id)
        {
            var staff = await _context.staffs.FirstOrDefaultAsync(x => x.id == id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return Ok($"Id: {id} deletado com sucesso");
        }
    }
}