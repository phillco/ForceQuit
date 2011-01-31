namespace ForceQuit.UI
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
            this.btnAddSite = new System.Windows.Forms.Button( );
            this.updateTimer = new System.Windows.Forms.Timer( this.components );
            this.websiteGroupBox = new System.Windows.Forms.GroupBox( );
            this.btnStartBreak = new System.Windows.Forms.Button( );
            this.lblBreakTimeRemaining = new System.Windows.Forms.Label( );
            this.trayIconMenu.SuspendLayout( );
            this.siteContextMenu.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "trayIcon.Icon" ) ) );
            this.trayIcon.Text = "ForceQuit";
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
            this.editToolStripMenuItem.Size = new System.Drawing.Size( 107, 22 );
            this.editToolStripMenuItem.Text = "Edit...";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size( 107, 22 );
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler( this.deleteToolStripMenuItem_Click );
            // 
            // btnAddSite
            // 
            this.btnAddSite.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAddSite.Image = global::ForceQuit.Properties.Resources.add;
            this.btnAddSite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSite.Location = new System.Drawing.Point( 375, 144 );
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size( 74, 26 );
            this.btnAddSite.TabIndex = 2;
            this.btnAddSite.Text = "Add site";
            this.btnAddSite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSite.UseVisualStyleBackColor = true;
            this.btnAddSite.Click += new System.EventHandler( this.btnAddSite_Click );
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += new System.EventHandler( this.updateTimer_Tick );
            // 
            // websiteGroupBox
            // 
            this.websiteGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.websiteGroupBox.Location = new System.Drawing.Point( 16, 16 );
            this.websiteGroupBox.Name = "websiteGroupBox";
            this.websiteGroupBox.Size = new System.Drawing.Size( 433, 122 );
            this.websiteGroupBox.TabIndex = 3;
            this.websiteGroupBox.TabStop = false;
            this.websiteGroupBox.Text = "Your sites";
            // 
            // btnStartBreak
            // 
            this.btnStartBreak.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.btnStartBreak.Location = new System.Drawing.Point( 16, 144 );
            this.btnStartBreak.Name = "btnStartBreak";
            this.btnStartBreak.Size = new System.Drawing.Size( 112, 26 );
            this.btnStartBreak.TabIndex = 4;
            this.btnStartBreak.Text = "Start break!";
            this.btnStartBreak.UseVisualStyleBackColor = true;
            this.btnStartBreak.Click += new System.EventHandler( this.btnStartBreak_Click );
            // 
            // lblBreakTimeRemaining
            // 
            this.lblBreakTimeRemaining.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.lblBreakTimeRemaining.AutoSize = true;
            this.lblBreakTimeRemaining.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblBreakTimeRemaining.Location = new System.Drawing.Point( 134, 151 );
            this.lblBreakTimeRemaining.Name = "lblBreakTimeRemaining";
            this.lblBreakTimeRemaining.Size = new System.Drawing.Size( 107, 13 );
            this.lblBreakTimeRemaining.TabIndex = 5;
            this.lblBreakTimeRemaining.Text = "25 min remaining...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 465, 180 );
            this.Controls.Add( this.lblBreakTimeRemaining );
            this.Controls.Add( this.websiteGroupBox );
            this.Controls.Add( this.btnStartBreak );
            this.Controls.Add( this.btnAddSite );
            this.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 200, 200 );
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding( 16, 16, 16, 42 );
            this.Text = "ForceQuit";
            this.Load += new System.EventHandler( this.MainForm_Load );
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainForm_FormClosing );
            this.Resize += new System.EventHandler( this.MainForm_Resize );
            this.trayIconMenu.ResumeLayout( false );
            this.siteContextMenu.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itsTimeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip siteContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnAddSite;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.GroupBox websiteGroupBox;
        private System.Windows.Forms.Button btnStartBreak;
        private System.Windows.Forms.Label lblBreakTimeRemaining;
    }
}

