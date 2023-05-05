using Doctors.Api.Domain;

namespace Doctors.Api.Services;

public interface IDoctorService
{
    Task<bool> CreateAsync(Doctor doctor);

    Task<Doctor?> GetAsync(Guid id);

    //Task<IEnumerable<Customer>> GetAllAsync();

    Task<bool> UpdateAsync(Doctor doctor);

    Task<bool> DeleteAsync(Guid id);
}
