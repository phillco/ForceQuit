﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Media;

namespace ForceQuit.UI
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }

        private List<Button> SiteButtons = new List<Button>( );

        public MainForm( )
        {
            Instance = this;
            InitializeComponent( );

            // Hide the window initially.    
            if ( false )
            {
                Opacity = 0; // Hide() will not work here, so we make the window invisible, the invoke a "real" hiding in MainForm_Load.
                ShowInTaskbar = false;
            }

            rebuildSiteButtons( );
        }

        public void ShowBrowserKilledBalloon( Website culprit )
        {
            BeginInvoke( new MethodInvoker( delegate
            {
                trayIcon.ShowBalloonTip( 2000, "ForceQuit", "We found you going to " + culprit.Name + " without using up a dosage, so we killed your browser.", ToolTipIcon.Info );

                // As if that wasn't enough...
                using ( SoundPlayer player = new SoundPlayer( Properties.Resources.PriceIsWrong ) )
                    player.Play( );
            } ) );
        }

        private void rebuildSiteButtons( )
        {
            foreach ( Button b in SiteButtons )
                Controls.Remove( b );
            SiteButtons.Clear( );

            // Create the buttons for each site. 
            int x = 15;
            int y = 15;
            int widestButton = 0;
            foreach ( Website site in Configuration.Instance.Sites )
            {
                Button button = createSiteButton( site );

                // Start a new row if needed.
                if ( x + button.Width + 15 > Width )
                {
                    x = 15;
                    y += button.Height + 10;
                }

                button.Left = x;
                button.Top = y;

                if ( button.Width > widestButton )
                    widestButton = button.Width;

                x += button.Width + 10;

                Controls.Add( button );
                SiteButtons.Add( button );
            }

            MinimumSize = new Size( widestButton + 48, y + 125 );

            UpdateState( );
        }

        private Button createSiteButton( Website site )
        {
            Button button = new Button
            {
                Tag = site,
                Width = (int) ( 40 + site.ToString( ).Length * 5.75 ), // HACK
                Height = 32,
                ContextMenuStrip = siteContextMenu,
                Font = new Font( Font, FontStyle.Bold ),
                Padding = new Padding( 4, 0, 4, 0 ),
                Image = site.HasImage( ) && File.Exists( site.ImageFilename ) ? Image.FromFile( site.ImageFilename ) : null,
                Top = 15,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleRight
            };

            button.MouseClick += ( sender, e ) => siteButton_MouseClick( button, e );
            button.AutoSize = false;
            return button;
        }

        private void UpdateState( )
        {
            // If this method was called by a different thread, invoke it to run on the form thread.
            if ( InvokeRequired )
            {
                BeginInvoke( new MethodInvoker( delegate { UpdateState( ); } ) );
                return;
            }

            foreach ( Button b in SiteButtons )
            {
                Website site = (Website) b.Tag;

                b.Enabled = site.CanUse( );
                b.Text = site.ToString( );
            }
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void itsTimeToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Show( );
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            // *Really* hide the window here.
            if ( false )
                BeginInvoke( new MethodInvoker( delegate
                {
                    Hide( );
                    Opacity = 100;
                    ShowInTaskbar = true;
                } ) );
        }

        private void siteButton_MouseClick( Button button, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
                SiteButtonClicked( button );
        }

        private void trayIcon_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
            {
                Show( );
                WindowState = FormWindowState.Normal;
                BringToFront( );
            }
        }

        private void MainForm_Resize( object sender, EventArgs e )
        {
            if ( WindowState == FormWindowState.Minimized )
                Hide( );

            rebuildSiteButtons( );
        }

        private void SiteButtonClicked( Button button )
        {
            Website site = (Website) button.Tag;
            button.Enabled = false;
            site.Use( );
            Hide( );
            rebuildSiteButtons( );
        }

        private void deleteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Button button = (Button) siteContextMenu.SourceControl;
            Website site = (Website) button.Tag;

            Configuration.Instance.Sites.Remove( site );
            rebuildSiteButtons( );
        }

        private void btnAddSite_Click( object sender, EventArgs e )
        {
            new AddSiteForm( ).ShowDialog( );
            rebuildSiteButtons( );
        }

        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            trayIcon.Visible = false;
        }

        private void updateTimer_Tick( object sender, EventArgs e )
        {
            UpdateState( );
        }
    }
}