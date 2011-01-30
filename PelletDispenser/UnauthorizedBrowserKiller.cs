using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace PelletDispenser
{
    /// <summary>
    /// Continuously searches for browsers that are open but haven't been authorized with PelletDispenser.
    /// </summary>
    public static class UnauthorizedBrowserKiller
    {
        private static List<String> browsers = new List<string>( new string[] { "Google Chrome", "Opera", "Mozilla Firefox", "Internet Explorer" } );
        private static Thread runThread = new Thread( new ThreadStart( KillBrowsers ) );

        private static bool shouldRun = true;

        public static void Run( )
        {
            runThread.Name = "UnauthorizedBrowserKiller thread";
            shouldRun = true;
            runThread.Start( );
        }

        public static void Stop( )
        {
            shouldRun = false;
        }

        public static void KillBrowsers( )
        {
            while ( shouldRun )
            {
                foreach ( Process p in Process.GetProcesses( ) )
                {
                    if ( isMatch( p.MainWindowTitle ) )
                    {
                        Console.WriteLine( p.MainWindowTitle + " is a match." );
                        p.Kill( );
                    }
                }

                Thread.Sleep( 100 );
            }
        }


        private static bool isMatch( string titlebar )
        {
            // Return true if a program matches one of our inactive sites...
            return Configuration.Instance.Sites.Exists( site => !site.Open && stringContainsIgnoreCase( titlebar, site.Name )) &&
                browsers.Exists( browser => stringContainsIgnoreCase( titlebar, browser ) ); // ...AND is a web browser.         
        }

        /// <summary>
        /// Returns whether a contains b (case insensitive).
        /// </summary>
        private static bool stringContainsIgnoreCase( string a, string b )
        {
            return ( a.ToUpper( ).Contains( b.ToUpper( ) ) );
        }
    }
}
