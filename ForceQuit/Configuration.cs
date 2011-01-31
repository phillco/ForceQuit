using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using ForceQuit.Properties;

namespace ForceQuit
{
    public class Configuration
    {
        public List<Website> Sites { get; set; }

        public bool BreakActive
        {
            get
            {
                return ( BreakEnds.CompareTo( DateTime.Now ) > 0 );
            }
        }

        public DateTime BreakEnds { get; set; }

        public DateTime NextAllowedBreak { get; set; }

        public const string FileName = "ForceQuit.json";

        public static Configuration Instance { get; private set; }

        public static Configuration DefaultSettings
        {
            get
            {
                return new Configuration
                {
                    Sites = new List<Website>( ),
                };
            }
        }

        public static void Initialize( )
        {
            if ( File.Exists( FileName ) )
            {
                using ( StreamReader file = new StreamReader( FileName ) )
                    Instance = JsonConvert.DeserializeObject<Configuration>( file.ReadToEnd( ) );
            }
            else
                LoadDefaultSettings( );
        }

        public static void LoadDefaultSettings( )
        {
            Instance = DefaultSettings;
            Save( );
        }

        public static void Save( )
        {
            ThreadPool.QueueUserWorkItem( delegate { Instance.SaveToFile( ); } );
        }

        private void SaveToFile( )
        {
            using ( StreamWriter file = new StreamWriter( FileName ) )
                file.Write( JsonConvert.SerializeObject( Instance, Formatting.Indented ) );
        }
    }
}
