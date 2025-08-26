using LogisticERP.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Get()
    {
        var motoristas = _context.Motoristas?.ToList();
        return Ok(motoristas);
    }

}
