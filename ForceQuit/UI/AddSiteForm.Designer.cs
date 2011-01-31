namespace ForceQuit.UI
{
    partial class AddSiteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AddSiteForm ) );
            this.label1 = new System.Windows.Forms.Label( );
            this.tbName = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.tbUrl = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.btnPaste = new System.Windows.Forms.Button( );
            this.lblImage = new System.Windows.Forms.Label( );
            this.siteImage = new System.Windows.Forms.PictureBox( );
            this.btnOK = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.fetchFaviconWorker = new System.ComponentModel.BackgroundWorker( );
            this.lookupTimer = new System.Windows.Forms.Timer( this.components );
            this.numUses = new System.Windows.Forms.NumericUpDown( );
            this.label4 = new System.Windows.Forms.Label( );
            ( (System.ComponentModel.ISupportInitialize) ( this.siteImage ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.numUses ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point( 9, 10 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 140, 21 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Add new website";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point( 85, 71 );
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size( 99, 22 );
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 40, 74 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 39, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point( 85, 43 );
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size( 222, 22 );
            this.tbUrl.TabIndex = 0;
            this.tbUrl.TextChanged += new System.EventHandler( this.tbUrl_TextChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 28, 46 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 51, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Address:";
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point( 313, 41 );
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size( 44, 23 );
            this.btnPaste.TabIndex = 5;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler( this.btnPaste_Click );
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point( 246, 74 );
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size( 41, 13 );
            this.lblImage.TabIndex = 6;
            this.lblImage.Text = "Image:";
            this.lblImage.Visible = false;
            // 
            // siteImage
            // 
            this.siteImage.Location = new System.Drawing.Point( 291, 73 );
            this.siteImage.Name = "siteImage";
            this.siteImage.Size = new System.Drawing.Size( 16, 16 );
            this.siteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.siteImage.TabIndex = 7;
            this.siteImage.TabStop = false;
            this.siteImage.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnOK.Location = new System.Drawing.Point( 229, 141 );
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size( 65, 25 );
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Add";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 300, 141 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 62, 25 );
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // fetchFaviconWorker
            // 
            this.fetchFaviconWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.fetchFaviconWorker_DoWork );
            // 
            // lookupTimer
            // 
            this.lookupTimer.Interval = 500;
            this.lookupTimer.Tick += new System.EventHandler( this.lookupTimer_Tick );
            // 
            // numUses
            // 
            this.numUses.Location = new System.Drawing.Point( 85, 99 );
            this.numUses.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.numUses.Name = "numUses";
            this.numUses.Size = new System.Drawing.Size( 40, 22 );
            this.numUses.TabIndex = 10;
            this.numUses.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 18, 101 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 61, 13 );
            this.label4.TabIndex = 11;
            this.label4.Text = "Daily uses:";
            // 
            // AddSiteForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 378, 178 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.numUses );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOK );
            this.Controls.Add( this.siteImage );
            this.Controls.Add( this.lblImage );
            this.Controls.Add( this.btnPaste );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.tbUrl );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.tbName );
            this.Controls.Add( this.label1 );
            this.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.Name = "AddSiteForm";
            this.Text = "Add site";
            ( (System.ComponentModel.ISupportInitialize) ( this.siteImage ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.numUses ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox siteImage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker fetchFaviconWorker;
        private System.Windows.Forms.Timer lookupTimer;
        private System.Windows.Forms.NumericUpDown numUses;
        private System.Windows.Forms.Label label4;
    }
}