/// File: RatingsByArticleIdDto.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace Cpate6_WebAPI_Project1.DataTransfer
{
    // TODO - created new Dto for sql join
    public class RatingsByArticleIdDto
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public double Value { get; set; }
    }
}
