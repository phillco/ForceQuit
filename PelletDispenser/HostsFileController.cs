using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.ServiceProcess;

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

        private static string hostsBackupFile = Path.Combine( hostsDir, "hosts.bak" );

        public static void Rebuild( )
        {
            int startTime = Environment.TickCount;

            using ( StreamWriter writer = new StreamWriter( hostsTempFile, false ) )
            {
                // Parse existing hosts file and strip anything that matches one of our sites.
                parseExistingEntries( writer );

                // Write the blocklist.
                writer.WriteLine( "# [DrugDealer Entries]" );
                foreach ( Website site in Configuration.Instance.Sites )
                {
                    if ( !site.Open )
                    {
                        writer.WriteLine( "127.0.0.1 " + site.Uri.Host );
                        writer.WriteLine( "127.0.0.1 www." + site.Uri.Host );
                    }
                }
                writer.WriteLine( "# [/DrugDealer Entries]" );
                writer.Flush( );
            }

            // Swap the two files.
            try
            {
                if ( File.Exists( hostsFile ) )
                {
                    if ( File.Exists( hostsBackupFile ) )
                        File.Delete( hostsBackupFile );

                    File.Copy( hostsFile, hostsBackupFile );
                    File.Delete( hostsFile );
                }

                File.Move( hostsTempFile, hostsFile );
                Console.WriteLine( "Hosts file rebuilt in " + ( Environment.TickCount - startTime ) / 1000.0 + " seconds." );
                RestartService( );
            }
            catch ( IOException )
            {
                Console.WriteLine( "Hosts file not rebuilt." );
            }
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

                    if ( line.Equals( "# [DrugDealer Entries]" ) )
                        return;

                    output.WriteLine( line );
                }
            }
        }

        public static void RestartService( )
        {
            int startTime = Environment.TickCount;

            ServiceController service = new ServiceController( "DNS Client" );

            if ( service.Status == ServiceControllerStatus.Running )
            {
                service.Stop( );
                service.WaitForStatus( ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds( 1500 ) );
            }

            service.Start( );
            service.WaitForStatus( ServiceControllerStatus.Running, TimeSpan.FromMilliseconds( 1500 ) );

            Console.WriteLine( "Restarted " + service.DisplayName + " in " + ( Environment.TickCount - startTime ) / 1000.0 + " seconds...");
        }
    }
}
