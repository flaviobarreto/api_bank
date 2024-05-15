using api_bank.Data;
using api_bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api_bank.Controller
{
    [ApiController]
    [Route(template: "v1")]
    public class CarteiraInvestimentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarteiraInvestimentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(template: "CarteiraInvestimento")]
        public async Task<IActionResult> GetCarteiraInvestimentoAsync()
        {
            List<ClienteAtivo> clienteAtivos = await _context
                        .ClienteAtivos
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(clienteAtivos);
        }

        [HttpGet]
        [Route(template: "CarteiraInvestimento/{id}")]
        public async Task<IActionResult> GetCarteiraInvestimentoByIdAsync([FromRoute] int id)
        {
            List<Ativo> carteira = (from s in _context.ClienteAtivos
                                    join at in _context.Ativos on s.AtivoId equals at.AtivoId
                                    join cl in _context.Clientes on s.ClienteId equals cl.ClienteId
                                    where s.ClienteId == id
                                    select at).ToList();

            return carteira == null ? NotFound() : Ok(carteira);
        }

        [HttpPost(template: "CarteiraInvestimento")]
        public async Task<IActionResult> PostAsync([FromBody] ClienteAtivo body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var carteira = new ClienteAtivo
            {
                AtivoId = body.AtivoId,
                ClienteId = body.ClienteId,
                Quantidade = body.Quantidade
            };

            try
            {
                await _context.ClienteAtivos.AddAsync(carteira);
                await _context.SaveChangesAsync();
                return Created(uri: $"v1/CarteiraInvestimento/{carteira.ClienteAtivoId}", carteira);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut(template: "CarteiraInvestimento/{id}")]
        public async Task<IActionResult> UpdateCarteiraInvestimentoAsync([FromBody] ClienteAtivo body, [FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var carteira = await _context.ClienteAtivos.FirstOrDefaultAsync(x => x.ClienteAtivoId == id);

            if (carteira == null)
                return BadRequest();

            try
            {
                carteira.Quantidade = body.Quantidade;

                _context.ClienteAtivos.Update(carteira);
                await _context.SaveChangesAsync();
                return Ok(carteira);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete(template: "CarteiraInvestimento/{id}")]
        public async Task<IActionResult> DeleteAtivoCarteiraAsync([FromRoute] int id)
        {
            var clienteAtivo = await _context
                .ClienteAtivos
                .FirstOrDefaultAsync(x => x.ClienteAtivoId == id);
            if (clienteAtivo == null)
                return BadRequest();
            try
            {
                _context.ClienteAtivos.Remove(clienteAtivo);
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
