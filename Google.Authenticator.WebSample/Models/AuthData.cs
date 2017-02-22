using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Authenticactor.WebSample.NETCore.Models
{
    public class AuthData
    {
        public string key { get; set; }
        public string qrCode { get; set; }
        public string manualCode { get; set; }
        public string code { get; set; }
    }
}
