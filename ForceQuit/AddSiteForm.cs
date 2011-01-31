using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using ForceQuit.Properties;
using System.IO;

namespace ForceQuit
{
    public partial class AddSiteForm : Form
    {
        public AddSiteForm( )
        {
            InitializeComponent( );
        }

        private void btnOK_Click( object sender, EventArgs e )
        {
            Website siteToSave = new Website
            {
                Name = tbName.Text,
                Url = tbUrl.Text,
                DailyUses = (int) numUses.Value,
            };

            // Write the image to a file.
            if ( siteImage.Image != null )
            {
                if ( !Directory.Exists( "images" ) )
                    Directory.CreateDirectory( "images" );

                string imagePath = Path.Combine( @"images\", tbName.Text + ".ico" );
                siteImage.Image.Save( imagePath, System.Drawing.Imaging.ImageFormat.Icon );
                siteToSave.ImageFilename = imagePath;
            }

            Configuration.Instance.Sites.Add( siteToSave );
            Configuration.Save( );

            Close( );
        }
     
        private void tbUrl_TextChanged( object sender, EventArgs e )
        {
            tbName.Text = GetSiteName( tbUrl.Text );

            lookupTimer.Interval = 100;
            lookupTimer.Enabled = true;
        }

        public static string GetSiteName( string url )
        {
            url = url.Trim( );

            // Remove prefixes.
            if ( url.StartsWith( "http://" ) )
                url = url.Remove( 0, "http://".Length );
            if ( url.StartsWith( "www." ) )
                url = url.Remove( 0, "www.".Length );

            // Remove contexts and subpaths.
            if ( url.Contains( "/" ) )
                url = url.Substring( 0, url.IndexOf( '/' ) );

            // Remove tld.
            if ( url.Contains( "." ) )
                url = url.Substring( 0, url.LastIndexOf( '.' ) );

            if ( url.Length > 1 )
                return url[0].ToString( ).ToUpper( ) + url.Substring( 1 );
            else
                return url;
        }

        private void btnPaste_Click( object sender, EventArgs e )
        {
            tbUrl.Text = Clipboard.GetText( );
        }

        private void fetchFaviconWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            string url = Util.FormatUrl( tbUrl.Text );

            Uri uri;
            if ( Uri.TryCreate( url, UriKind.Absolute, out uri ) )
            {
                setSiteImage( null );
                Uri favicon = new Uri( uri, "/favicon.ico" );


                HttpWebRequest request = (HttpWebRequest) WebRequest.Create( favicon );
                request.Proxy = null; // This fixes an odd .NET bug that causes the first request to take several minutes.
                request.Timeout = 2000;
                request.Method = "GET";

                try
                {
                    setSiteImage( Image.FromStream( request.GetResponse( ).GetResponseStream( ) ) );
                }
                catch ( WebException ) { setSiteImage( null ); }
                catch ( ArgumentException ) { setSiteImage( null ); }
            }
            else
                setSiteImage( null );
        }

        private void setSiteImage( Image image )
        {
            // If this method was called by a different thread, invoke it to run on the form thread.
            if ( InvokeRequired )
            {
                BeginInvoke( new MethodInvoker( delegate { setSiteImage( image ); } ) );
                return;
            }

            if ( image == null )
                siteImage.Hide( );
            else
            {
                siteImage.Image = image;
                siteImage.Show( );
            }
        }

        private void lookupTimer_Tick( object sender, EventArgs e )
        {
            if ( fetchFaviconWorker.IsBusy )
                lookupTimer.Interval = 30;
            else
            {
                fetchFaviconWorker.RunWorkerAsync( );
                lookupTimer.Enabled = false;
            }
        }
    }
}
