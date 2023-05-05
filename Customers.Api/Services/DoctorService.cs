using Doctors.Api.Domain;
using Doctors.Api.Mapping;
using Doctors.Api.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Doctors.Api.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<bool> CreateAsync(Doctor doctor)
    {
        var existingUser = await _doctorRepository.GetAsync(doctor.Id.Value);
        if (existingUser is not null)
        {
            var message = $"A user with id {doctor.Id} already exists";
            throw new ValidationException(message, GenerateValidationError(message));
        }
        
        var customerDto = doctor.ToDoctorDto();
        return await _doctorRepository.CreateAsync(customerDto);
    }

    public async Task<Doctor?> GetAsync(Guid id)
    {
        var customerDto = await _doctorRepository.GetAsync(id);
        return customerDto?.ToDoctor();
    }

    // public async Task<IEnumerable<Customer>> GetAllAsync()
    // {
    //     var customerDtos = await _customerRepository.GetAllAsync();
    //     return customerDtos.Select(x => x.ToCustomer());
    // }

    public async Task<bool> UpdateAsync(Doctor doctor)
    {
        var customerDto = doctor.ToDoctorDto();
        
        return await _doctorRepository.UpdateAsync(customerDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _doctorRepository.DeleteAsync(id);
    }

    private static ValidationFailure[] GenerateValidationError(string message)
    {
        return new []
        {
            new ValidationFailure(nameof(Doctor), message)
        };
    }
}
