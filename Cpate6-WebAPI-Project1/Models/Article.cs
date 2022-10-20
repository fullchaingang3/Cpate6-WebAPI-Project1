namespace Cpate6_WebAPI_Project1.Models
{
    public class Article
    {
        /// <summary>
        /// This is an entity class for the Article table in the database
        /// </summary>
        public int ArticleID { get; set; }
        public string? Title { get; set; }
        public DateTime? Postdate { get; set; }
        public string? Summary { get; set; }
        public string? Link { get; set; }
        public string? OwnerGuid { get; set; }
    }
}
