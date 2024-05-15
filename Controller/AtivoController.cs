using api_bank.Data;
using api_bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace api_bank.Controller
{
    [ApiController]
    [Route(template: "v1")]
    public class AtivoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AtivoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(template: "Ativos")]
        public async Task<IActionResult> GetAtivosAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Ativo> ativos = await _context
               .Ativos
               .AsNoTracking()
               .ToListAsync();
            stopwatch.Stop(); // 231 ms

            return Ok(ativos);
        }

        [HttpGet]
        [Route(template: "Ativos/{id}")]
        public async Task<IActionResult> GetAtivosByIdAsync([FromRoute] int id)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Ativo ativos = await _context
               .Ativos
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.AtivoId == id);
            stopwatch.Stop();

            return ativos == null ? NotFound() : Ok(ativos);
        }

        [HttpPost(template:"Ativos")]
        public async Task<IActionResult> PostAsync([FromBody] Ativo ativo)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

                var _ativo = new Ativo { 
                    AtivoName = ativo.AtivoName,
                    Preco = ativo.Preco
                };

            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                await _context.Ativos.AddAsync(_ativo);
                await _context.SaveChangesAsync();
                stopwatch.Stop();
                return Created(uri: $"v1/Ativos/{_ativo.AtivoId}", _ativo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut(template: "Ativos/{id}")]
        public async Task<IActionResult> UpdateAtivoAsync([FromBody] Ativo body, [FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            var _ativo = await _context.Ativos.FirstOrDefaultAsync(x => x.AtivoId == id);
            stopwatch.Stop();

            if (_ativo == null)
                return BadRequest();


            try
            {
                _ativo.AtivoName = body.AtivoName;
                _ativo.Preco = body.Preco;

                Stopwatch _stopwatch = Stopwatch.StartNew();
                _context.Ativos.Update(_ativo);
                await _context.SaveChangesAsync();
                _stopwatch.Stop();
                return Ok(_ativo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete(template: "Ativos/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var _ativo = await _context
                .Ativos
                .FirstOrDefaultAsync(x => x.AtivoId == id);
            if (_ativo == null)
                return BadRequest();
            try
            {
                _context.Ativos.Remove(_ativo);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
