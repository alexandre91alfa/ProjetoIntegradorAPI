using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using univespApiPI.repository;

namespace univespApiPI.Controllers
{
    [Route("v1")]
    public class FuncController : Controller
    {
        private readonly DbFunc _context;
        FuncController()
        {
        }

        // public async Task<IActionResult> GetFuncionarios()
        // {
        //     try
        //     {
        //         var result = await
        //     }
        //     catch (System.Exception)
        //     {

        //         throw;
        //     }
        // }
    }
}