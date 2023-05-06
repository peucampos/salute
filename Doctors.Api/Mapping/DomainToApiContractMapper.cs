using Doctors.Api.Contracts.Responses;
using Doctors.Api.Domain;

namespace Doctors.Api.Mapping;

public static class DomainToApiContractMapper
{
    public static DoctorResponse ToDoctorResponse(this Doctor doctor)
    {
        return new DoctorResponse
        {
            Id = doctor.Id.Value,
            Name = doctor.Name.Value
        };
    }

    public static GetAllDoctorsResponse ToDoctorsResponse(this IEnumerable<Doctor> doctors)
    {
        return new GetAllDoctorsResponse
        {
            Doctors = doctors.Select(x => new DoctorResponse
            {
                Id = x.Id.Value,
                Name = x.Name.Value
            })
        };
    }
}
