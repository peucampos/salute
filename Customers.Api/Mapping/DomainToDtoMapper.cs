using Doctors.Api.Contracts.Data;
using Doctors.Api.Domain;

namespace Doctors.Api.Mapping;

public static class DomainToDtoMapper
{
    public static DoctorDto ToDoctorDto(this Doctor doctor)
    {
        return new DoctorDto
        {
            Id = doctor.Id.Value.ToString(),
            Name = doctor.Name.Value
        };
    }
}
