using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.API.Data;
using Restaurante.API.Models;
using Restaurante.API.Interfaces;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _repository.GetProdutosAsync();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            var novoProduto = await _repository.PostProdutoAsync(produto);
            return Ok(novoProduto);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _repository.DeleteProdutoAsync(id);

            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}