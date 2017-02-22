using mcgtemplate_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mcgtemplate_web.Services
{
    public interface IMessageSender
    {
        Task<string> SendAsync(message Msg);
    }
}
