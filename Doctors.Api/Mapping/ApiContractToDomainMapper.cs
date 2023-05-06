using Doctors.Api.Contracts.Requests;
using Doctors.Api.Domain;
using Doctors.Api.Domain.Common;

namespace Doctors.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Doctor ToDoctor(this DoctorRequest request)
    {
        return new Doctor
        {
            Id = DoctorId.From(Guid.NewGuid()),
            Name = FullName.From(request.Name)
        };
    }

    public static Doctor ToDoctor(this UpdateDoctorRequest request)
    {
        return new Doctor
        {
            Id = DoctorId.From(request.Id),
            Name = FullName.From(request.Doctor.Name)
        };
    }
}
