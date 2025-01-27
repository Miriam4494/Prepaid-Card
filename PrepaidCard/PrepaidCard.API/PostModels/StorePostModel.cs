namespace PrepaidCard.API.PostModels
{
    public class StorePostModel
    {
        public string StoreName { get; set; }//שם
        public string? Address { get; set; }//כתובת
        public string City { get; set; }//עיר
        public string Phone { get; set; }//טלפון
        public string Email { get; set; }//מייל
        public string Manager { get; set; }//מנהל
        public string SiteStore { get; set; }//אתר חנות

    }
}
