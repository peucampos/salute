namespace Doctors.Api.Contracts.Responses;

public class DoctorResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;
}
