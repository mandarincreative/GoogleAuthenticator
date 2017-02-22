using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MandarinCreative.Extensions
{
    public static class ContextExtensions
    {
        public static string AbsoluteUrl(this HttpContext context) {
            return context.Request.Scheme + "://" + context.Request.Host + context.Request.Path + "?" + context.Request.QueryString;
        }
    }
}
