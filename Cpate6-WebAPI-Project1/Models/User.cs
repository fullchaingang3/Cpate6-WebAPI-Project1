/// File: ArticlesController.cs
/// Name: Christopher Pate
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Project 1

namespace Cpate6_WebAPI_Project1.Models
{
    /// <summary>
    /// This class matches the database table JetUser for CRUD operations
    /// </summary>
    internal class User
    {
        /// <summary>
        /// This is an entity class for the JetUser table in the database
        /// </summary>
        public string? UserGUID { get; set; }
        public string? Email{get; set; }
        public string? Password{get; set; }
        public string? FirstName{get; set; }
        public string? LastName{get; set; }
        public Boolean IsActive{get; set; }
        public int LevelID{get; set; }

        /// <summary>
        /// This method provides an easy way to output the contents of the object
        /// mostly used for testing
        /// </summary>
        /// <returns>String</returns>
        
        public override string? ToString()
        {
            return "Guid: " + UserGUID + " Email: " + Email + " Password: " + Password + " FIrstName: " + FirstName + " LastName: " + LastName + " IsActive " + IsActive + " LevelID " + LevelID;
        }
    }
}
