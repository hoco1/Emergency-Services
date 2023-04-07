namespace EmergencyServices
{
    public class Validator
    {
        public static bool ValidateName(string name)
        {
            // Check that the name only contains letters and not empty
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }

        public static bool ValidateIdentityNumber(string identityNumber)
        {
            // Check that the identity number only contains numbers and not empty and length is 10
            return !string.IsNullOrEmpty(identityNumber) && identityNumber.All(char.IsDigit) && identityNumber.Length == 10 && !EmergencyServicesDB.CheckUser(identityNumber);   
        }

        public static bool ValidateAddress(string address)
        {
            // Check that the address only contains letters and not empty
            return !string.IsNullOrEmpty(address) && address.All(char.IsLetter);
        }

        public static bool ValidateGender(int gender)
        {
            // 0 male , 1 female, 2 other
            return gender == 0 || gender == 1 || gender == 2;

        }
    }
}