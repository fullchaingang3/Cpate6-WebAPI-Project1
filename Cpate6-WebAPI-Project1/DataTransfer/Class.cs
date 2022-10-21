namespace Cpate6_WebAPI_Project1.DataTransfer
{
    public class UserDto
    {
        /// <summary>
        /// This is an entity class for the JetUser Data Transfer table in the database
        /// </summary>
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool ValidUserDto { get; set; }

        /// <summary>
        /// This method provides an easy way to output the contents of the object
        /// mostly used for testing
        /// </summary>
        /// <returns>String</returns>

        public override string? ToString()
        {
            return "Email: " + Email + " Password: " + Password + " FIrstName: " + FirstName + " LastName: " + LastName;
        }
    }
}
