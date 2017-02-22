using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcgtemplate_web.Config
{
    public class twilioSettings
    {
        public string Sid { get; set; }
        public string Token { get; set; }
        public string BaseUri { get; set; }
        public string SMSUri { get; set; }
        public string CallUri { get; set; }
        public string From { get; set; }
    }
}
