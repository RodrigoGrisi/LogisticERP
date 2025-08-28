using LogisticERP.Context;
using Microsoft.AspNetCore.Mvc;
using LogisticERP.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticERP.Controllers;

[Route("[controller]")]
[ApiController]
public class ViagensController : ControllerBase
{

    private readonly AppDbContext _context;

    public ViagensController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("WithMotoristaDeatail")]
    public ActionResult<IEnumerable<Viagem>> GetViagemWithMotoristas()
    {

        try
        {
            var viagens = _context.Viagens
                .Include(v => v.Motorista)
                .AsNoTracking()
                .ToList();
            return viagens;

        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação.");

        }
    }

    [HttpGet("WithNotasFiscaisDeatail")]
    public ActionResult<IEnumerable<Viagem>> GetViagemWithNotasFiscais()
    {
        var viagens = _context.Viagens
            .Include(v => v.NotasFiscais)
            .AsNoTracking()
            .ToList();

        return viagens;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Viagem>> Get()
    {

        try
        {
            var viagens = _context.Viagens?.AsNoTracking().ToList();
            return viagens;

        }
        catch (Exception)
        {
            return NotFound("Nenhuma viagem foi encontrada");
        }

    }

    [HttpGet("{id:int}", Name = "BuscarViagem")]
    public ActionResult<Viagem> Get(int id)
    {
        var viagem = _context.Viagens?.FirstOrDefault(m => m.ViagemID == id);

        if (viagem == null)
        {
            return NotFound("Motorista não encontrado...");
        }

        return viagem;
    }

    [HttpPost]
    public ActionResult Post(Viagem viagem)
    {

        if (viagem == null)
        {
            return BadRequest();
        }

        _context.Viagens?.Add(viagem);
        _context.SaveChanges();

        return new CreatedAtRouteResult("BuscarViagem",
            new { id = viagem.ViagemID }, viagem);

    }

    [HttpPut("{id:int}")]
    public ActionResult EditarDadosMotorista(int id, Viagem viagem)
    {

        if (id != viagem.ViagemID)
        {
            return BadRequest("não encontramos o motorista indicado.");
        }

        _context.Entry(viagem).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(viagem);

    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletarViagem(int id)
    {

        var viagem = _context.Viagens?.FirstOrDefault(m => m.ViagemID == id);

        if (viagem is null)
        {
            return NotFound("Viagem não localizada");
        }

        _context.Viagens?.Remove(viagem);
        _context.SaveChanges();

        return Ok("Viagem Deletad com sucesso.");

    }



}
