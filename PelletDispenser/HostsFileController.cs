using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PelletDispenser
{
    /// <summary>
    /// Updates the system hosts file to ban sites that the user shouldn't be able to access.
    /// </summary>
    public class HostsFileController
    {
        private static string hostsDir = Path.Combine( Environment.GetEnvironmentVariable( "windir" ), @"system32\drivers\etc\" );

        private static string hostsFile = Path.Combine( hostsDir, "hosts" );

        private static string hostsTempFile = Path.Combine( hostsDir, "hosts.new" );

        public static void Rebuild( )
        {
            int startTime = Environment.TickCount;

            using ( StreamWriter writer = new StreamWriter( hostsTempFile, false ) )
            {
                // Parse existing hosts file and strip anything that matches one of our sites.
                parseExistingEntries( writer );

                // Write the blocklist.
                foreach ( Website site in Configuration.Instance.Sites )
                {
                    if ( !site.CanUse( ) )
                    {
                        writer.WriteLine( "127.0.0.1 " + site.Uri.Host );
                        writer.WriteLine( "127.0.0.1 www." + site.Uri.Host );
                    }
                }
            }

            // Swap the two files.
            File.Delete( Path.Combine( hostsDir, "hosts.bak" ) );
            File.Move( Path.Combine( hostsDir, "hosts" ), Path.Combine( hostsDir, "hosts.bak" ) );
            File.Move( Path.Combine( hostsDir, "hosts.new" ), Path.Combine( hostsDir, "hosts" ) );

            int stopTime = Environment.TickCount;
            Console.WriteLine( "Hosts file rebuilt in " + ( stopTime - startTime ) / 1000.0 + " seconds." );
        }

        /// <summary>
        /// Reads through the existing hosts file, writing every line to the output stream except for any host that matches a site.
        /// </summary>
        private static void parseExistingEntries( StreamWriter output )
        {
            using ( StreamReader reader = new StreamReader( hostsFile ) )
            {
                while ( !reader.EndOfStream )
                {
                    string line = reader.ReadLine( );

                    if ( !lineMatchesSite( line ) )
                        output.WriteLine( line );
                }
            }
        }

        private static bool lineMatchesSite( string line )
        {
            // Skip commented lines.
            if ( line.StartsWith( "#" ) )
                return false;

            string[] sections = line.Split( ' ' );

            // Skip lines without a host.
            if ( sections.Length < 2 )
                return false;

            string host = sections[1];

            // If the host matches any of our sites (with or without the www.), return true.
            return ( Configuration.Instance.Sites.Exists( site =>
                host.Equals( site.Uri.Host, StringComparison.CurrentCultureIgnoreCase ) ||
                host.Equals( "www." + site.Uri.Host, StringComparison.CurrentCultureIgnoreCase ) )
            );
        }
    }
}
