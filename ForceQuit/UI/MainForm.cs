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
            updateState( );
        }

        public void UpdateTakeBreakButton( )
        {
            updateState( );
        }

        public void ShowBrowserKilledBalloon( Website culprit )
        {
            BeginInvoke( new MethodInvoker( delegate
            {
                trayIcon.ShowBalloonTip( 2000, "ForceQuit", "We found you going to " + culprit.Name + " without starting a break, so we killed your browser.", ToolTipIcon.Info );

                // As if that wasn't enough...
                using ( SoundPlayer player = new SoundPlayer( Properties.Resources.PriceIsWrong ) )
                    player.Play( );
            } ) );
        }

        private void updateState( )
        {
            if ( Configuration.Instance.BreakActive )
            {
                btnStartBreak.Text = "Finish break";
                lblBreakTimeRemaining.Text = String.Format( "{0} min remaining...", Configuration.Instance.BreakEnds.Subtract( DateTime.Now ).Minutes + 1 );
                lblBreakTimeRemaining.Visible = true;
                siteButtonPanel.Enabled = false;
            }
            else
            {
                if ( Configuration.Instance.NextAllowedBreak.CompareTo( DateTime.Now ) > 0 )
                {
                    lblBreakTimeRemaining.Text = String.Format( "{0} min until next break...", Configuration.Instance.NextAllowedBreak.Subtract( DateTime.Now ).Minutes + 1 );
                    lblBreakTimeRemaining.Visible = true;
                    siteButtonPanel.Enabled = false;
                    btnStartBreak.Enabled = false;
                }
                else
                {
                    if ( siteButtonPanel.GetSelectedForBreak( ).Count > 0 )
                    {
                        btnStartBreak.Text = String.Format( "Start break! ({0})", siteButtonPanel.GetSelectedForBreak( ).Count );
                        btnStartBreak.Enabled = true;
                    }
                    else
                    {
                        btnStartBreak.Text = "Start break!";
                        btnStartBreak.Enabled = false;
                    }
                    lblBreakTimeRemaining.Visible = false;
                    siteButtonPanel.Enabled = true;
                }
            }

            siteButtonPanel.RefreshState( );
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
            updateState( );
        }

        private void finishBreak( )
        {
            Configuration.Instance.BreakEnds = DateTime.MinValue;
            Configuration.Instance.NextAllowedBreak = DateTime.Now.AddMinutes( 30 );
            foreach ( Website w in Configuration.Instance.Sites )
                w.Open = false;
            foreach ( SiteButton button in siteButtonPanel.Buttons )
                button.SelectedForBreak = false;
        }

        private void btnStartBreak_Click( object sender, EventArgs e )
        {            
            if ( Configuration.Instance.BreakActive )
            {
                MessageBox.Show( "Be sure you close any browser tabs that you used on your break.", "End break", MessageBoxButtons.OK, MessageBoxIcon.Information );
                finishBreak( );                
            }
            else
            {
                Configuration.Instance.BreakEnds = DateTime.Now.AddMinutes( 30 );
                Hide( );

                foreach ( SiteButton button in siteButtonPanel.GetSelectedForBreak( ) )
                {
                    button.Website.Use( );
                    Thread.Sleep( 1300 );
                }
            }

            updateState( );
            siteButtonPanel.Reflow( );
            Configuration.Save( );
        }
    }
}
