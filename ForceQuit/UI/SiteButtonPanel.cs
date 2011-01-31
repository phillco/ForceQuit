
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ForceQuit.UI
{
    class SiteButtonPanel : Panel
    {
        public List<SiteButton> Buttons = new List<SiteButton>( );

        private ContextMenuStrip siteButtonMenu;

        public SiteButtonPanel( ContextMenuStrip siteButtonMenu )
        {
            this.siteButtonMenu = siteButtonMenu;
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding( 12, 8, 8, 8 );
            Reflow( );
        }

        public void RefreshState( )
        {
            foreach ( SiteButton button in Buttons )
                button.RefreshState( );
        }

        public void Remove( SiteButton button )
        {
            Configuration.Instance.Sites.Remove( button.Website );
            Reflow( );
        }

        public List<SiteButton> GetSelectedForBreak( )
        {
            return Buttons.FindAll( button => button.SelectedForBreak );
        }

        public void Reflow( )
        {
            // Create the buttons for each site. 
            List<SiteButton> newLayout = new List<SiteButton>( );
            int x = Padding.Left, y = Padding.Top;
            foreach ( Website site in getSortedList( ) )
            {
                SiteButton button = new SiteButton( site );
                button.ContextMenuStrip = siteButtonMenu;

                // Start a new row if needed.
                if ( x + button.Width > Width - Padding.Right )
                {
                    x = Padding.Left;
                    y += button.Height + 10;
                }

                button.Left = x;
                button.Top = y;

                x += button.Width + 10;
                newLayout.Add( button );
            }

            if ( isLayoutDifferent( newLayout ) )
            {
                foreach ( SiteButton b in Buttons )
                    Controls.Remove( b );

                Buttons = newLayout;

                foreach ( SiteButton b in Buttons )
                    Controls.Add( b );

            }
        }

        private List<Website> getSortedList( )
        {
            List<Website> copy = new List<Website>( Configuration.Instance.Sites );
            copy.Sort( ( a, b ) => a.Name.CompareTo( b.Name ) );
            return copy;
        }

        private bool isLayoutDifferent( List<SiteButton> newLayout )
        {
            if ( newLayout.Count != Buttons.Count )
                return true;

            for ( int i = 0; i < Buttons.Count; i++ )
            {
                if ( Buttons[i].Location != newLayout[i].Location )
                    return true;
            }

            return false;
        }
    }
}
