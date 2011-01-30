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

        public const string FileName = "ForceQuit.json";

        public static Configuration Instance { get; private set; }

        public static Configuration DefaultSettings
        {
            get
            {
                return new Configuration
                {
                    Sites = new List<Website>
                    {
                        new Website
                        {
                            Name = "Gmail",
                            Url = "https://gmail.com",
                            DailyUses = 5,
                            ImageFilename = @"images\gmail.ico",
                        },
                        
                        new Website
                        {
                            Name = "Facebook",
                            Url = "http://facebook.com",
                            DailyUses = 5,
                            ImageFilename = @"images\facebook.ico",
                        },
                        new Website
                        {
                            Name = "Twitter",
                            Url = "http://twitter.com",
                            DailyUses = 5,
                            ImageFilename = @"images\twitter.ico",
                        },
                    }
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
