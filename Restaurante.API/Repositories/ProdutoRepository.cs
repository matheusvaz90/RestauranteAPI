using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurante.API.Data;
using Restaurante.API.Interfaces;
using Restaurante.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.API.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> GetProdutosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> PostProdutoAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }
}