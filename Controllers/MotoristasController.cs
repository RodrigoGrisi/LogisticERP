using LogisticERP.Context;
using LogisticERP.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticERP.Controllers;

[Route("[controller]")]
[ApiController]
public class MotoristasController : ControllerBase
{
    private readonly AppDbContext _context;


    public MotoristasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Motorista>>> Get()
    {
        return await _context.Motoristas?.Include(v => v.Viagens).ToListAsync();

    }

    [HttpGet("{id:int}", Name = "BuscarMotorista")]
    public async Task<ActionResult<Motorista>> Get(int id)
    {

        try
        {
            return await _context.Motoristas?.FirstOrDefaultAsync(m => m.MotoristaID == id);
        }
        catch (Exception)
        {
            return NotFound($"Motorista não encontrado...");
        }
    }

    [HttpPost]
    public ActionResult Post(Motorista motorista)
    {

        if (motorista == null)
        {
            return BadRequest();
        }

        _context.Motoristas.Add(motorista);
        _context.SaveChanges();

        return new CreatedAtRouteResult("BuscarMotorista",
            new { id = motorista.MotoristaID }, motorista);

    }

    [HttpPut("{id:int}")]
    public ActionResult EditarDadosMotorista(int id, Motorista motorista)
    {

        if (id != motorista.MotoristaID)
        {
            return BadRequest("não encontramos o motorista indicado.");
        }

        _context.Entry(motorista).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(motorista);

    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletarMotorista(int id)
    {

        var motorista = _context.Motoristas?.FirstOrDefault(m => m.MotoristaID == id);

        if (motorista is null)
        {
            return NotFound("Motorista não localizado");
        }

        _context.Motoristas.Remove(motorista);
        _context.SaveChanges();

        return Ok("Motorista Deletado com sucesso.");

    }

}