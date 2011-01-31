using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ForceQuit
{
    /// <summary>
    /// Continuously searches for browsers that are open but haven't been authorized with ForceQuit.
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
                    Website matchingSite = findMatchingSite( p.MainWindowTitle );

                    if ( matchingSite != null && browsers.Exists( browser => stringContainsIgnoreCase( p.MainWindowTitle, browser ) ))
                    {
                        Console.WriteLine( p.MainWindowTitle + " is a match for " + matchingSite.Name + "." );
                        p.Kill( );
                        MainForm.Instance.ShowBrowserKilledBalloon( matchingSite );
                    }
                }

                Thread.Sleep( 100 );
            }
        }

        private static Website findMatchingSite( string titlebar )
        {
            return Configuration.Instance.Sites.Find( site => !site.Open && stringContainsIgnoreCase( titlebar, site.Name ) );
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
