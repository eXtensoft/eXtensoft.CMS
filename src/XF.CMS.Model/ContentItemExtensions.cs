using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CMS.Model
{
    public static class ContentItemExtensions
    {
        public static string Trim(this Guid guid)
        {
            return guid.ToString().TrimStart('{').TrimEnd('}');
        }
    }
}
