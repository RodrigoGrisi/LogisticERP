using AutoMapper;
using LogisticERP.Context;
using LogisticERP.Domain;
using LogisticERP.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticERP.Controllers;

[Route("[controller]")]
[ApiController]
public class MotoristasController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;


    public MotoristasController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MotoristaDTO>>> Get()
    {

        var motoristas = await _context.Motoristas?.ToListAsync();
        if (motoristas is null)
        {
            return NotFound("Nenhum motorista cadastrado.");
        }
        var motoristaDTO = _mapper.Map<IEnumerable<MotoristaDTO>>(motoristas);

        return Ok(motoristaDTO);

    }

    [HttpGet("{id:int}", Name = "BuscarMotorista")]
    public async Task<ActionResult<MotoristaDTO>> Get(int id)
    {
        var motorista = await _context.Motoristas
            .FirstOrDefaultAsync(m => m.MotoristaID == id);

        if (motorista is null)
        {
            return NotFound("Motorista não localizado.");
        }

        var motoristaDTO = _mapper.Map<MotoristaDTO>(motorista);
        return Ok(motoristaDTO);
    }

    [HttpPost]
    public ActionResult<MotoristaDTO> Post(MotoristaDTO motoristaDTO)
    {

        if (motoristaDTO == null)
            return BadRequest();

        var motorista = _mapper.Map<Motorista>(motoristaDTO);

        _context.Motoristas.Add(motorista);
        _context.SaveChanges();

        return new CreatedAtRouteResult("BuscarMotorista",
            new { id = motoristaDTO.MotoristaID }, motoristaDTO);
    }


    [HttpPut("{id:int}")]
    public ActionResult<MotoristaDTO> EditarDadosMotorista(int id, MotoristaDTO motoristaDTO)
    {
        var motorista = _mapper.Map<MotoristaDTO>(id);

        if (id != motorista.MotoristaID)
            return BadRequest("não encontramos o motorista indicado.");

        _context.Entry(motorista).State = EntityState.Modified;
        _context.SaveChanges();

        var motoristaAtualizadoDTO = _mapper.Map<MotoristaDTO>(motorista);

        return Ok(motoristaAtualizadoDTO);

    }

    [HttpDelete("{id:int}")]
    public ActionResult<MotoristaDTO> DeletarMotorista(int id)
    {

        var motorista = _context.Motoristas?.FirstOrDefault(m => m.MotoristaID == id);

        if (motorista is null)
            return NotFound("Motorista não localizado");

        _context.Motoristas.Remove(motorista);
        _context.SaveChanges();

        var motoristaDeletadoDTO = _mapper.Map<MotoristaDTO>(motorista);

        return Ok(motoristaDeletadoDTO);

    }

}