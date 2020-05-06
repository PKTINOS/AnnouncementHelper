using Newtonsoft.Json;

namespace AnnouncementHelper
{
    public class Announcement
    {

        //Δημιουργος ανακοινωσης
        public Publisher Publisher
        {
            get;
            set;
        }
        //Τιτλος ανακοινωσης
        public string Title
        {
            get;
            set;
        }
        //Περιεχομενο ανακοινωσης
        public string Text
        {
            get;
            set;
        }
        public string[] Attachments
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "_about")]
        public string CategoryId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "_id")]
        public string AnnouncementHash
        {
            get;
            set;
        }
        public string Category
        {
            get
            {
                foreach (Category c in Program.Categories)
                {
                    if (c.Id == CategoryId)
                    {
                        return c.Name;
                    }
                }
                return "?????";
            }
        }
    }
}
