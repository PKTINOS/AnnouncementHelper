using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstTeitheApplication
{
    public class Announcement
    {

        //Δημιουργος ανακοινωσης
        public Publisher publisher
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

        //Χωρος για text χωρις newlines
        public string editedtext
        {
            get;
            set;
        }

        public string[] attachments
        {
            get;
            set;
        }
        public string date
        {
            get;
            set;
        }

        //Category id
        public string _about
        {
            get;
            set;
        }

        //Hash
        public string _id
        {
            get;
            set;
        }
        public class Publisher
        {
            public string id
            {
                get;
                set;
            }
            public string name
            {
                get;
                set;
            }
        }
        public string category
        {
            get
            {
                foreach (Category c in Program.categories)
                {
                    if (c._id == _about)
                    {
                        return c.name;
                    }
                }
                return "?????";
            }
        }
    }
}
