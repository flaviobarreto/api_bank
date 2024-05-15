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
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(template: "Cliente")]
        public async Task<IActionResult> GetClienteAsync()
        {
            List<Cliente> clientes = await _context
               .Clientes
               .AsNoTracking()
               .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet]
        [Route(template: "Cliente/{id}")]
        public async Task<IActionResult> GetClienteByIdAsync([FromRoute] int id)
        {
            Cliente clientes = await _context
              .Clientes
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.ClienteId == id);

            return clientes == null ? NotFound() : Ok(clientes);
        }

        [HttpPost(template: "Cliente")]
        public async Task<IActionResult> PostAsync([FromBody] Cliente body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = new Cliente
            {
                Nome = body.Nome
            };

            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return Created(uri: $"v1/Cliente/{cliente.ClienteId}", cliente);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut(template: "Cliente/{id}")]
        public async Task<IActionResult> UpdateClienteAsync([FromBody] Cliente body, [FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);

            if (cliente == null)
                return BadRequest();

            try
            {
                cliente.Nome = body.Nome;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete(template: "Cliente/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var cliente = await _context
                .Clientes
                .FirstOrDefaultAsync(x => x.ClienteId == id);
            if (cliente == null)
                return BadRequest();
            try
            {
                _context.Clientes.Remove(cliente);
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
