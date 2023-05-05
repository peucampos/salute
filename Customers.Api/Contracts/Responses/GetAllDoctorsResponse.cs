namespace Doctors.Api.Contracts.Responses;

public class GetAllDoctorsResponse
{
    public IEnumerable<DoctorResponse> Doctors { get; init; } = Enumerable.Empty<DoctorResponse>();
}
