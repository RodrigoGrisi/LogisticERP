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
    public ActionResult<IEnumerable<Motorista>> Get()
    {
        var motoristas = _context.Motoristas?.ToList();

        if(motoristas != null && motoristas.Count == 0)
        {
            return NotFound();
        }

        return motoristas;
    }

    [HttpGet("{id:int}", Name="ObterMotorista")]
    public ActionResult<Motorista> Get(int id)
    {
        var motorista = _context.Motoristas?.FirstOrDefault(m => m.MotoristaID == id);
        if(motorista == null)
        {
            return NotFound("Motorista não encontrado...");
        }
        return motorista;
    }

    [HttpPost]
    public ActionResult Post(Motorista motorista)
    {

        if(motorista == null)
        {
            return BadRequest();
        }

        _context.Motoristas.Add(motorista);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterMotorista", 
            new { id = motorista.MotoristaID  }, motorista);

    }

    [HttpPut("{id:int}")]
    public ActionResult EditarDadosMotorista(int id, Motorista motorista)
    {

        if(id != motorista.MotoristaID)
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

        if(motorista is null)
        {
            return NotFound("Motorista não localizado");
        }

        _context.Motoristas.Remove(motorista);
        _context.SaveChanges();

        return Ok("Motorista Deletado com sucesso.");

    }



}
