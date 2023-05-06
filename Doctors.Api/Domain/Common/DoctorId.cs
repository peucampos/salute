using ValueOf;

namespace Doctors.Api.Domain.Common;

public class DoctorId : ValueOf<Guid, DoctorId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Customer Id cannot be empty", nameof(DoctorId));
        }
    }
}
