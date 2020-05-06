using Newtonsoft.Json;

namespace AnnouncementHelper
{
    public class Profile
    {
        public string Uid
        {
            get;
            set;
        }
        public string Am
        {
            get;
            set;
        }
        public string Regyear
        {
            get;
            set;
        }
        public string Regsem
        {
            get;
            set;
        }
        public string GivenName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "sn")]
        public string LastName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "cn")]
        public string FullName
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Mail
        {
            get;
            set;
        }
        public string Sem
        {
            get;
            set;
        }
    }
}
