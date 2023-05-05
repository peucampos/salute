using Doctors.Api.Contracts.Data;

namespace Doctors.Api.Repositories;

public interface IDoctorRepository
{
    Task<bool> CreateAsync(DoctorDto doctor);

    Task<DoctorDto?> GetAsync(Guid id);

    //Task<IEnumerable<CustomerDto>> GetAllAsync();

    Task<bool> UpdateAsync(DoctorDto doctor);

    Task<bool> DeleteAsync(Guid id);
}
