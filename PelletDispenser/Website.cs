using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace PelletDispenser
{
    /// <summary>
    /// Represents a distracting website that the user is managing.
    /// </summary>
    public class Website
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string ImageFilename { get; set; }

        public int DailyUses { get; set; }

        public DateTime NextUsableTime { get; private set; }

        public bool Open { get; private set; }

        public Uri Uri
        {
            get
            {
                return new Uri( Util.FormatUrl( Url ) );
            }
        }

        public int UsesLeftToday
        {
            get
            {
                // Roll over the uses for today.
                if ( lastRolledOver.DayOfYear != DateTime.Now.DayOfYear )
                {
                    usesLeftToday = DailyUses;
                    lastRolledOver = DateTime.Now;
                }

                return usesLeftToday;
            }

            set
            {
                usesLeftToday = value;
            }
        }

        private int usesLeftToday;

        private DateTime lastRolledOver;

        public bool CanUse( )
        {
            return Open || ( UsesLeftToday > 0 && ( DateTime.Now.CompareTo( NextUsableTime ) >= 0 ));
        }

        public void Use( )
        {
            if ( Open )
            {
                Open = false;
                NextUsableTime = DateTime.Now.AddMinutes( 30 );
                return;
            }
            
            UsesLeftToday--;
            Open = true;
            Configuration.Save( );

            using ( Process process = new Process( ) )
            {
                string url = Url;
                if ( !url.StartsWith( "http://" ) && !url.StartsWith( "https://" ) )
                    url = "http://" + url;

                process.StartInfo.FileName = url;
                process.Start( );
            }
        }

        public bool HasImage( )
        {
            return ( ImageFilename != null ) && ( ImageFilename.Length > 0 );
        }

        public override string ToString( )
        {
            if ( Open )
                return String.Format( "{0} (open)", Name );
            else if ( DateTime.Now.CompareTo( NextUsableTime ) < 0 )
                return String.Format( "{0} ({1} min)", Name, NextUsableTime.Subtract( DateTime.Now ).Minutes );
            else
            return String.Format( "{0} ({1})", Name, UsesLeftToday );
        }
    }
}
