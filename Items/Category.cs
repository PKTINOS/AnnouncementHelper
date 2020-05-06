using Newtonsoft.Json;

namespace AnnouncementHelper
{
    public class Category
    {
        public int Index
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "_id")]
        public string Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string NameEn
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "public")]
        public bool IsPublic
        {
            get;
            set;
        }
    }
}
