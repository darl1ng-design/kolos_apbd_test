using Kolos_Test.dto;
using Kolos_Test.exceptions;
using Kolos_Test.services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolos_Test.controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly IDbService dbService;
    public ApiController(IDbService dbService)
    {
        this.dbService = dbService;
    }


    [HttpGet("professors")]
    public async Task<IActionResult> getProfessors([FromQuery] string? lastName)
    {
        try
        {
            var result = await dbService.GetProfessorInfo(lastName);
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (InvalidArgumentException)
        {
            return BadRequest();
        }
    }

    [HttpPost("courses")]
    public async Task createCourse(CreateCourseDTO dto)
    {
        try
        {
            await dbService.createCourse(dto);
        }
        catch(NotFoundException)
        {
            NotFound();
        } catch (InvalidArgumentException)
        { 
            BadRequest();
        }
    }
}