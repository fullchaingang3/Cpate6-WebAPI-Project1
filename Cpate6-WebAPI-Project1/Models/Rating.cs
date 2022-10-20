namespace Cpate6_WebAPI_Project1.Models
{
    public class Rating
    {
        /// <summary>
        /// This is an entity class for the Rating table in the database
        /// </summary>
        public int ArticleID { get; set; }
        public string? UserID { get; set; }
        public float Ratings { get; set; }

    }
}
