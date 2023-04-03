using api_restful.config;
using api_restful.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_restful.Controllers;

[ApiController]
[Route("servico")]
public class ServicoController : ControllerBase
{
    private readonly Contexto _contexto;
    public ServicoController(Contexto contexto)
    {
        _contexto = contexto;
    }
    
    [HttpPost]
    [Route("AdicionarServico")]
    public async Task<ActionResult<Servico>> AdicionarServico(Servico servico)
    {
        _contexto.TB_SERVICO.Add(servico);
        await _contexto.SaveChangesAsync();
        return Ok(servico);
    }
    
    [HttpDelete]
    [Route("ExcluirServico/{id}")]
    public async Task<ActionResult<Servico>> ExcluirServico(int id)
    {
        var servico = await _contexto.TB_SERVICO.FirstOrDefaultAsync( s => s.ID == id);
        if (servico != null){
            _contexto.TB_SERVICO.Remove(servico);
            await _contexto.SaveChangesAsync();
        }
        return Ok("Serviço excluído com sucesso!");
    }
    
    [HttpGet]
    [Route("ListaServicos")]
    public async Task<ActionResult<List<Servico>>> ListaServicos()
    {
        return await _contexto.TB_SERVICO.ToListAsync(); 
    }
    
    [HttpGet]
    [Route("ObterServico/{id}")]
    public async Task<ActionResult<Servico>> ObterServico(int id)
    {
        return await _contexto.TB_SERVICO.FirstOrDefaultAsync(s => s.ID == id); 
    }
    
}