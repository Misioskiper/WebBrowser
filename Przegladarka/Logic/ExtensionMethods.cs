using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przegladarka.Logic
{
    public static class ExtensionMethods
    {
        public static bool HasHttpScheme(this string uri)
        {
            return Uri.TryCreate(uri, UriKind.Absolute, out var result) && (result.Scheme == "http");
        }

        public static bool HasHttpsScheme(this string uri)
        {
            return Uri.TryCreate(uri, UriKind.Absolute, out var result) && (result.Scheme == "https");
        }
    }
}
