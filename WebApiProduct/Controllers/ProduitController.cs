using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProduct.Models;

namespace WebApiProduct.Controllers
{
    [Route("api/[produit]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly ProduitContext _context;
        public ProduitController(ProduitContext context)
        {
            _context = context;
         
        }

        // GET: api/Produit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetAllProd()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Produit/5
        [HttpGet("{IdProd}")]
        public async Task<ActionResult<Produit>> GetProd(int IdProd)
        {
            var prod = await _context.Products.FindAsync(IdProd);
            if (prod == null)
            {
                return NotFound();
            }
            return prod;
        }


        // POST: api/Produit
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProd(Produit prod)
        {
            _context.Products.Add(prod);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllProd), new { idProd = prod.IdProd }, prod);
        }

        // PUT: api/Produit/5
        [HttpPut("{IdProd}")]
        public async Task<IActionResult> PutProd(int IdProd, Produit prod)
        {
            if (IdProd != prod.IdProd)
            {
                return BadRequest();
            }
            _context.Entry(prod).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Produit/5
        [HttpDelete("{idProd}")]
        public async Task<IActionResult> DeleteProd(int IdProd)
        {
            var prod = await _context.Products.FindAsync(IdProd);
            if (prod == null)
            {
                return NotFound();
            }
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}