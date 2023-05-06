using Doctors.Api.Attributes;
using Doctors.Api.Contracts.Requests;
using Doctors.Api.Mapping;
using Doctors.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Api.Controllers;

[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost("doctor")]
    public async Task<IActionResult> Create([FromBody] DoctorRequest request)
    {
        var doctor = request.ToDoctor();

        await _doctorService.CreateAsync(doctor);

        var customerResponse = doctor.ToDoctorResponse();

        return CreatedAtAction("Get", new { customerResponse.Id }, customerResponse);
    }

    [HttpGet("doctor/{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var doctor = await _doctorService.GetAsync(id);

        if (doctor is null)
        {
            return NotFound();
        }

        var doctorResponse = doctor.ToDoctorResponse();
        return Ok(doctorResponse);
    }

    // [HttpGet("doctor")]
    // public async Task<IActionResult> GetAll()
    // {
    //     var customers = await _customerService.GetAllAsync();
    //     var customersResponse = customers.ToCustomersResponse();
    //     return Ok(customersResponse);
    // }

    [HttpPut("doctor/{id:guid}")]
    public async Task<IActionResult> Update(
        [FromMultiSource] UpdateDoctorRequest request)
    {
        var existingDoctor = await _doctorService.GetAsync(request.Id);

        if (existingDoctor is null)
        {
            return NotFound();
        }

        var doctor = request.ToDoctor();
        await _doctorService.UpdateAsync(doctor);

        var doctorResponse = doctor.ToDoctorResponse();
        return Ok(doctorResponse);
    }
    
    [HttpDelete("doctor/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _doctorService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}
