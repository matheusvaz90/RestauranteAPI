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
        // 1. O segredo: Não chamamos mais o AppDbContext aqui!
        // Chamamos apenas o "Contrato" (Interface)
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            // 2. O Controller apenas pede para o repositório buscar
            var produtos = await _repository.GetProdutosAsync();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            // 3. O Controller apenas pede para o repositório salvar
            var novoProduto = await _repository.PostProdutoAsync(produto);
            return Ok(novoProduto);
        }
    }
}