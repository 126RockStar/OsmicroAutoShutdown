namespace OsmicroAutoShutdown.SubForm
{
    partial class MessageNoticeShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notice_exit_btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.notice_ok_btn = new Bunifu.UI.WinForms.BunifuImageButton();
            this.notice_cancel_btn = new Bunifu.UI.WinForms.BunifuImageButton();
            this.notice_delay_alret_btn = new Bunifu.UI.WinForms.BunifuImageButton();
            this.info_label = new System.Windows.Forms.Label();
            this.delay_combobox = new System.Windows.Forms.ComboBox();
            this.delay_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OsmicroAutoShutdown.Properties.Resources.notice_message;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(469, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // notice_exit_btn
            // 
            this.notice_exit_btn.Active = false;
            this.notice_exit_btn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(7)))), ((int)(((byte)(23)))));
            this.notice_exit_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(111)))), ((int)(((byte)(195)))));
            this.notice_exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.notice_exit_btn.BorderRadius = 0;
            this.notice_exit_btn.ButtonText = "";
            this.notice_exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notice_exit_btn.DisabledColor = System.Drawing.Color.Gray;
            this.notice_exit_btn.Iconcolor = System.Drawing.Color.Transparent;
            this.notice_exit_btn.Iconimage = global::OsmicroAutoShutdown.Properties.Resources.exit_png;
            this.notice_exit_btn.Iconimage_right = null;
            this.notice_exit_btn.Iconimage_right_Selected = null;
            this.notice_exit_btn.Iconimage_Selected = null;
            this.notice_exit_btn.IconMarginLeft = 8;
            this.notice_exit_btn.IconMarginRight = 0;
            this.notice_exit_btn.IconRightVisible = true;
            this.notice_exit_btn.IconRightZoom = 0D;
            this.notice_exit_btn.IconVisible = true;
            this.notice_exit_btn.IconZoom = 40D;
            this.notice_exit_btn.IsTab = false;
            this.notice_exit_btn.Location = new System.Drawing.Point(430, 0);
            this.notice_exit_btn.Name = "notice_exit_btn";
            this.notice_exit_btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(111)))), ((int)(((byte)(195)))));
            this.notice_exit_btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(16)))), ((int)(((byte)(34)))));
            this.notice_exit_btn.OnHoverTextColor = System.Drawing.Color.White;
            this.notice_exit_btn.selected = false;
            this.notice_exit_btn.Size = new System.Drawing.Size(40, 22);
            this.notice_exit_btn.TabIndex = 28;
            this.notice_exit_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.notice_exit_btn.Textcolor = System.Drawing.Color.White;
            this.notice_exit_btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notice_exit_btn.Click += new System.EventHandler(this.Notice_exit_btn_Click);
            // 
            // notice_ok_btn
            // 
            this.notice_ok_btn.ActiveImage = global::OsmicroAutoShutdown.Properties.Resources.Ok_over_btn;
            this.notice_ok_btn.AllowAnimations = true;
            this.notice_ok_btn.AllowZooming = false;
            this.notice_ok_btn.BackColor = System.Drawing.Color.Transparent;
            this.notice_ok_btn.FadeWhenInactive = false;
            this.notice_ok_btn.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.notice_ok_btn.Image = global::OsmicroAutoShutdown.Properties.Resources.Ok_normal_btn;
            this.notice_ok_btn.ImageActive = global::OsmicroAutoShutdown.Properties.Resources.Ok_over_btn;
            this.notice_ok_btn.ImageMargin = 0;
            this.notice_ok_btn.ImageSize = new System.Drawing.Size(98, 24);
            this.notice_ok_btn.ImageZoomSize = new System.Drawing.Size(98, 24);
            this.notice_ok_btn.Location = new System.Drawing.Point(316, 91);
            this.notice_ok_btn.Name = "notice_ok_btn";
            this.notice_ok_btn.Rotation = 0;
            this.notice_ok_btn.ShowActiveImage = true;
            this.notice_ok_btn.ShowCursorChanges = true;
            this.notice_ok_btn.ShowImageBorders = false;
            this.notice_ok_btn.ShowSizeMarkers = false;
            this.notice_ok_btn.Size = new System.Drawing.Size(98, 24);
            this.notice_ok_btn.TabIndex = 29;
            this.notice_ok_btn.ToolTipText = "";
            this.notice_ok_btn.Zoom = 0;
            this.notice_ok_btn.ZoomSpeed = 10;
            this.notice_ok_btn.Click += new System.EventHandler(this.Notice_ok_btn_Click);
            // 
            // notice_cancel_btn
            // 
            this.notice_cancel_btn.ActiveImage = global::OsmicroAutoShutdown.Properties.Resources.Cancel_over_btn;
            this.notice_cancel_btn.AllowAnimations = true;
            this.notice_cancel_btn.AllowZooming = false;
            this.notice_cancel_btn.BackColor = System.Drawing.Color.Transparent;
            this.notice_cancel_btn.FadeWhenInactive = false;
            this.notice_cancel_btn.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.notice_cancel_btn.Image = global::OsmicroAutoShutdown.Properties.Resources.Cancel_normal_btn;
            this.notice_cancel_btn.ImageActive = global::OsmicroAutoShutdown.Properties.Resources.Cancel_over_btn;
            this.notice_cancel_btn.ImageMargin = 0;
            this.notice_cancel_btn.ImageSize = new System.Drawing.Size(98, 24);
            this.notice_cancel_btn.ImageZoomSize = new System.Drawing.Size(98, 24);
            this.notice_cancel_btn.Location = new System.Drawing.Point(194, 91);
            this.notice_cancel_btn.Name = "notice_cancel_btn";
            this.notice_cancel_btn.Rotation = 0;
            this.notice_cancel_btn.ShowActiveImage = true;
            this.notice_cancel_btn.ShowCursorChanges = true;
            this.notice_cancel_btn.ShowImageBorders = false;
            this.notice_cancel_btn.ShowSizeMarkers = false;
            this.notice_cancel_btn.Size = new System.Drawing.Size(98, 24);
            this.notice_cancel_btn.TabIndex = 30;
            this.notice_cancel_btn.ToolTipText = "";
            this.notice_cancel_btn.Zoom = 0;
            this.notice_cancel_btn.ZoomSpeed = 10;
            this.notice_cancel_btn.Click += new System.EventHandler(this.Notice_cancel_btn_Click);
            // 
            // notice_delay_alret_btn
            // 
            this.notice_delay_alret_btn.ActiveImage = global::OsmicroAutoShutdown.Properties.Resources.Delay_alert_overl_btn;
            this.notice_delay_alret_btn.AllowAnimations = true;
            this.notice_delay_alret_btn.AllowZooming = false;
            this.notice_delay_alret_btn.BackColor = System.Drawing.Color.Transparent;
            this.notice_delay_alret_btn.FadeWhenInactive = false;
            this.notice_delay_alret_btn.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.notice_delay_alret_btn.Image = global::OsmicroAutoShutdown.Properties.Resources.Delay_alert_normal_btn;
            this.notice_delay_alret_btn.ImageActive = global::OsmicroAutoShutdown.Properties.Resources.Delay_alert_overl_btn;
            this.notice_delay_alret_btn.ImageMargin = 0;
            this.notice_delay_alret_btn.ImageSize = new System.Drawing.Size(98, 24);
            this.notice_delay_alret_btn.ImageZoomSize = new System.Drawing.Size(98, 24);
            this.notice_delay_alret_btn.Location = new System.Drawing.Point(316, 142);
            this.notice_delay_alret_btn.Name = "notice_delay_alret_btn";
            this.notice_delay_alret_btn.Rotation = 0;
            this.notice_delay_alret_btn.ShowActiveImage = true;
            this.notice_delay_alret_btn.ShowCursorChanges = true;
            this.notice_delay_alret_btn.ShowImageBorders = false;
            this.notice_delay_alret_btn.ShowSizeMarkers = false;
            this.notice_delay_alret_btn.Size = new System.Drawing.Size(98, 24);
            this.notice_delay_alret_btn.TabIndex = 31;
            this.notice_delay_alret_btn.ToolTipText = "";
            this.notice_delay_alret_btn.Zoom = 0;
            this.notice_delay_alret_btn.ZoomSpeed = 10;
            this.notice_delay_alret_btn.Click += new System.EventHandler(this.Notice_delay_alret_btn_Click);
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_label.Location = new System.Drawing.Point(124, 41);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(208, 13);
            this.info_label.TabIndex = 32;
            this.info_label.Text = "Your computer will Shutdown after 2m 55s.";
            // 
            // delay_combobox
            // 
            this.delay_combobox.FormattingEnabled = true;
            this.delay_combobox.Location = new System.Drawing.Point(194, 144);
            this.delay_combobox.Name = "delay_combobox";
            this.delay_combobox.Size = new System.Drawing.Size(98, 21);
            this.delay_combobox.TabIndex = 33;
            // 
            // delay_timer
            // 
            this.delay_timer.Interval = 500;
            this.delay_timer.Tick += new System.EventHandler(this.Delay_timer_Tick);
            // 
            // MessageNoticeShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 187);
            this.Controls.Add(this.delay_combobox);
            this.Controls.Add(this.info_label);
            this.Controls.Add(this.notice_delay_alret_btn);
            this.Controls.Add(this.notice_cancel_btn);
            this.Controls.Add(this.notice_ok_btn);
            this.Controls.Add(this.notice_exit_btn);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageNoticeShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageNoticeShow";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton notice_exit_btn;
        private Bunifu.UI.WinForms.BunifuImageButton notice_ok_btn;
        private Bunifu.UI.WinForms.BunifuImageButton notice_cancel_btn;
        private Bunifu.UI.WinForms.BunifuImageButton notice_delay_alret_btn;
        private System.Windows.Forms.Label info_label;
        private System.Windows.Forms.ComboBox delay_combobox;
        private System.Windows.Forms.Timer delay_timer;
    }
}