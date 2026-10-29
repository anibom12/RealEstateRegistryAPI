

namespace RealEstateAPI.Domain.Exceptions;

public partial class Errors
{
    public static class NationalCode
    {
        public static readonly Error IsRequired = new("NationalCode.IsRequired", "کد ملی الزامی است");
        public static readonly Error InvalidFormat = new("NationalCode.InvalidFormat", "کد ملی باید شامل ده رقم باشد");

    }
}
