/// File: RatingRto.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace Cpate6_WebAPI_Project1.DataTransfer
{
    public class RatingRto
    {
        /// <summary>
        /// Class Properties, entity to match database table Rating
        /// </summary>
        public int ArticleID { get; set; }
        public string? UserID { get; set; }

        /// <summary>
        /// Output properties for testing, mostly
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            return "Artile ID: " + ArticleID + " User ID: " + UserID;
        }
    }
}
