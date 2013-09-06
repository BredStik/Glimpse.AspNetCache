using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Extensibility;
using Glimpse.AspNet.Extensions;
using Glimpse.AspNet.Extensibility;
using System.Security.Principal;
using System.Collections;
using System.Diagnostics;

namespace Glimpse.AspNetCache
{
    public class AspNetCacheTab : TabBase<HttpContextBase>
    {
        public override string Name
        {
            get
            {
                return "ASP.NET Cache";
            }
        }

        public string Key
        {
            get
            {
                return "glimpse_aspnet_cache";
            }
        }

        public override object GetData(ITabContext context)
        {
            var cache = context.GetHttpContext().Cache;

            return cache.Cast<DictionaryEntry>().Select(x => new { Key = x.Key, Type = x.Value.GetType().ToString(), Value = x.Value });
        }
    }
}