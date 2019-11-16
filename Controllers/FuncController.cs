using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using univespApiPI.model;
using univespApiPI.repository;

namespace univespApiPI.Controllers
{
    [Route("v1")]
    public class FuncController : Controller
    {
        private readonly DbFunc _context;

        public FuncController(DbFunc context)
        {
            _context = context;
        }
        [HttpGet("v1/staff")]
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
        [HttpGet("v1/{id}")]
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
        [HttpPost("v1/add")]
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
                    return Ok($"Dados Salvos com sucesso {CreatedAtAction("Get", new { id = func.id }, func)}");
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
    }
}