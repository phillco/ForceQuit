using System;
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

        private SiteButtonPanel siteButtonPanel;

        public MainForm( )
        {
            Instance = this;            
            InitializeComponent( );
            siteButtonPanel = new SiteButtonPanel( siteContextMenu );
            websiteGroupBox.Controls.Add( siteButtonPanel );
            websiteGroupBox.SizeChanged += ( sender, e ) => siteButtonPanel.Reflow( );

            // Hide the window initially.    
            if ( false )
            {
                Opacity = 0; // Hide() will not work here, so we make the window invisible, the invoke a "real" hiding in MainForm_Load.
                ShowInTaskbar = false;
            }

            siteButtonPanel.Reflow( );
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
        }

        private void deleteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            siteButtonPanel.Remove( (SiteButton) siteContextMenu.SourceControl );
        }

        private void btnAddSite_Click( object sender, EventArgs e )
        {
            new AddSiteForm( ).ShowDialog( );
            siteButtonPanel.Reflow( );
        }

        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            trayIcon.Visible = false;
        }

        private void updateTimer_Tick( object sender, EventArgs e )
        {
        }
    }
}
