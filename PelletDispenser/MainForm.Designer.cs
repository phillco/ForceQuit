namespace PelletDispenser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
            this.trayIcon = new System.Windows.Forms.NotifyIcon( this.components );
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.itsTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.siteContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.trayIconMenu.SuspendLayout( );
            this.siteContextMenu.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "trayIcon.Icon" ) ) );
            this.trayIcon.Text = "Pellet Dispenser";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler( this.trayIcon_MouseClick );
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.itsTimeToolStripMenuItem,
            this.exitToolStripMenuItem} );
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size( 131, 48 );
            // 
            // itsTimeToolStripMenuItem
            // 
            this.itsTimeToolStripMenuItem.Font = new System.Drawing.Font( "Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.itsTimeToolStripMenuItem.Name = "itsTimeToolStripMenuItem";
            this.itsTimeToolStripMenuItem.Size = new System.Drawing.Size( 130, 22 );
            this.itsTimeToolStripMenuItem.Text = "It\'s time...";
            this.itsTimeToolStripMenuItem.Click += new System.EventHandler( this.itsTimeToolStripMenuItem_Click );
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size( 130, 22 );
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
            // 
            // siteContextMenu
            // 
            this.siteContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem} );
            this.siteContextMenu.Name = "siteContextMenu";
            this.siteContextMenu.Size = new System.Drawing.Size( 108, 48 );
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font( "Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
            this.editToolStripMenuItem.Text = "Edit...";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler( this.deleteToolStripMenuItem_Click );
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 445, 181 );
            this.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Pellet Dispenser";
            this.Load += new System.EventHandler( this.MainForm_Load );
            this.Resize += new System.EventHandler( this.MainForm_Resize );
            this.trayIconMenu.ResumeLayout( false );
            this.siteContextMenu.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itsTimeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip siteContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

