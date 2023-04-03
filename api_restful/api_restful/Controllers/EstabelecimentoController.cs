using api_restful.config;
using api_restful.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_restful.Controllers;

[ApiController]
[Route("estabelecimento")]
public class EstabelecimentoController: ControllerBase
{
    private readonly Contexto _contexto;
    public EstabelecimentoController(Contexto contexto)
    {
        _contexto = contexto;
    }
    
    [HttpPost]
    [Route("AdicionarEstabelecimento")]
    public async Task<ActionResult<Estabelecimento>> AdicionarEstabelecimento(Estabelecimento estabelecimento)
    {
        _contexto.TB_ESTABELECIMENTO.Add(estabelecimento);
        await _contexto.SaveChangesAsync();
        return Ok(estabelecimento);
    }
    
    [HttpDelete]
    [Route("ExcluirEstabelecimento/{id}")]
    public async Task<ActionResult<Estabelecimento>> ExcluirEstabelecimento(int id)
    {
        var estabelecimento = await _contexto.TB_ESTABELECIMENTO.FirstOrDefaultAsync( e => e.ID == id);
        if (estabelecimento != null){
            _contexto.TB_ESTABELECIMENTO.Remove(estabelecimento);
            await _contexto.SaveChangesAsync();
        }
        return Ok("Estabelecimento excluído com sucesso!");
    }
    
    [HttpGet]
    [Route("ListaEstabelecimentos")]
    public async Task<ActionResult<List<Estabelecimento>>> ListaEstabelecimentos()
    {
        return await _contexto.TB_ESTABELECIMENTO.ToListAsync(); 
    }
    
    [HttpGet]
    [Route("ObterEstabelecimento/{id}")]
    public async Task<ActionResult<Estabelecimento>> ObterEstabelecimento(int id)
    {
        return await _contexto.TB_ESTABELECIMENTO.FirstOrDefaultAsync(e => e.ID == id); 
    }
}