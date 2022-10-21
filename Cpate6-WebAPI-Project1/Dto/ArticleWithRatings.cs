﻿namespace dlblair_webapi_first.Data.DataTransfer
{
    public class ArticleWithRating
    {
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }
        public List<RatingWithNameDto> ratingWithNameDto { get; set; }

    }
}
