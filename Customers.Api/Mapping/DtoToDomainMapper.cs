using Doctors.Api.Contracts.Data;
using Doctors.Api.Domain;
using Doctors.Api.Domain.Common;

namespace Doctors.Api.Mapping;

public static class DtoToDomainMapper
{
    public static Doctor ToDoctor(this DoctorDto doctorDto)
    {
        return new Doctor
        {
            Id = DoctorId.From(Guid.Parse(doctorDto.Id)),
            Name = FullName.From(doctorDto.Name),
        };
    }
}
