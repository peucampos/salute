using Microsoft.AspNetCore.Mvc;

namespace Doctors.Api.Contracts.Requests;

public class UpdateDoctorRequest
{
    [FromRoute(Name = "id")] public Guid Id { get; init; }

    [FromBody] public DoctorRequest Doctor { get; set; } = default!;
}
