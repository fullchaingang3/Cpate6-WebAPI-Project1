using System.ComponentModel.DataAnnotations;

/// File: UserDto.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace dlblair_webapi_first.Data.DataTransfer
{
    /// <summary>
    /// This class used to communicate with any client
    /// </summary>
    public class UserDto
    {
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool ValidUserDto { get; set; }

        /// <summary>
        /// This method provides an easy to output the contents of the object
        /// Used mostly for testing
        /// </summary>
        /// <returns>Return all properties in UserDto</returns>
        public override string? ToString()
        {
            return "Email: " + Email + " User Password: " + UserPassword + " First Name: " + FirstName + " Last Name: " + LastName;
        }
    }
}
