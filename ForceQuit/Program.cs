using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ForceQuit.UI;

namespace ForceQuit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            Configuration.Initialize( );
            
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );

            UnauthorizedBrowserKiller.Run( );
            Application.Run( new MainForm( ) );
            UnauthorizedBrowserKiller.Stop( );
        }        
    }
}
