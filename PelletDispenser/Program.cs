using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace PelletDispenser
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

            HostsFileController.Rebuild( );
            Application.Run( new MainForm( ) );
        }        
    }
}
