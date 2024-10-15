namespace EFCore.Domain.VehicleManagement
{
    using EFCore.Domain.VehicleManagement.Exceptions;
    using System.Text.RegularExpressions;

    public record Vin(string value)
    {
        private static Regex VinValidationRegex = new Regex("[A-HJ-NPR-Z0-9]{17}");

        public static Vin Create(string value)
        {
            if (!IsValid(value))
            {
                throw new InvalidVinException();
            }
            return new Vin(value);
        }

        public static bool TryCreate(string value, out Vin? vin)
        {
            if (!IsValid(value))
            {
                vin = null;
                return false;
            }
            vin = new Vin(value);
            return true;
        }

        private static bool IsValid(string value) => VinValidationRegex.IsMatch(value);
    }
}
