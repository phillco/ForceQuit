using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ForceQuit.UI
{
    /// <summary>
    /// A button tied to one of the user's websites.
    /// </summary>
    class SiteButton : Button
    {
        public Website Website { get; private set; }

        public SiteButton( Website site )
        {
            this.Website = site;

            Width = (int) ( 40 + site.ToString( ).Length * 5.75 ); // HACK
            Height = 32;            
            Font = new Font( "Tahoma", 8, FontStyle.Bold );
            Padding = new Padding( 4, 0, 4, 0 );
            Top = 15;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextAlign = ContentAlignment.MiddleRight;

            Click += new EventHandler( SiteButton_Click );

            // Use the downloaded icon, if available.
            if ( site.HasImage( ) && File.Exists( site.ImageFilename ) )
                Image = Image.FromFile( site.ImageFilename );

            RefreshState( );
        }

        public void Remove( )
        {
            Configuration.Instance.Sites.Remove( Website );
        }

        public void RefreshState( )
        {
            Text = Website.ToString();
            Enabled = Website.CanUse( );
        }

        private void SiteButton_Click( object sender, EventArgs e )
        {
            Enabled = false;
            Website.Use( );
        }

    }
}
