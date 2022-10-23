/// File: ArticleDto.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace Cpate6_WebAPI_Project1.DataTransfer
{
    /// <summary>
    /// This class used for communicating with any client
    /// </summary>
    public class ArticleDto
    {
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }
        public bool ValidArticleDto { get; set; }

        //public string Key { get; set; }

        /// <summary>
        /// This method provides an easy to output the contents of the object
        /// mostly used for testing
        /// </summary>
        /// <returns>String representing all properties in an Article</returns>
        public override string? ToString()
        {
            return "Title: " + Title + " PostDate: " + PostDate.ToShortDateString + " Summary: " + Summary + " Link: " + Link; // + " Key: " + Key;
        }
    }
}
