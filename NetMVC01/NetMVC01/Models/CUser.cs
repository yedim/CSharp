using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMVC01.Models
{
    public class CUser
    {
        public int theUniqueID { get; set; } //property 
        public string theID { get; set; }
        public string thePW { get; set; }

        public string theName { get; set; }
        public string theEMail { get; set; }
        public bool bSubscription { get; set; }

        public DateTime theDate { get; set; }
    }
}