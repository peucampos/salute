using Doctors.Api.Domain.Common;

namespace Doctors.Api.Domain;

public class Doctor
{
    public DoctorId Id { get; init; } = DoctorId.From(Guid.NewGuid());

    public FullName Name { get; init; } = default!;
}
