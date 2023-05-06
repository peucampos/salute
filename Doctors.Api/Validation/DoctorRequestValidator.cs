using Doctors.Api.Contracts.Requests;
using FluentValidation;

namespace Doctors.Api.Validation;

public class DoctorRequestValidator : AbstractValidator<DoctorRequest>
{
    public DoctorRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
