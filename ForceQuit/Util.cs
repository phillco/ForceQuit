using System;
using System.Collections.Generic;
using System.Text;

namespace ForceQuit
{
    public class Util
    {
        public static string FormatUrl( string url )
        {
            if ( !url.StartsWith( "http://" ) && !url.StartsWith( "https://" ) )
                url = "http://" + url;

            return url;
        }
    }
}
