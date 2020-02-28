namespace OsmicroAutoShutdown.SubForm
{
    partial class ErrorMessage
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
            this.error_exit_btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.error_ok_btn = new Bunifu.UI.WinForms.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // error_exit_btn
            // 
            this.error_exit_btn.Active = false;
            this.error_exit_btn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(7)))), ((int)(((byte)(23)))));
            this.error_exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.error_exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.error_exit_btn.BorderRadius = 0;
            this.error_exit_btn.ButtonText = "";
            this.error_exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.error_exit_btn.DisabledColor = System.Drawing.Color.Gray;
            this.error_exit_btn.Iconcolor = System.Drawing.Color.Transparent;
            this.error_exit_btn.Iconimage = global::OsmicroAutoShutdown.Properties.Resources.exit_png;
            this.error_exit_btn.Iconimage_right = null;
            this.error_exit_btn.Iconimage_right_Selected = null;
            this.error_exit_btn.Iconimage_Selected = null;
            this.error_exit_btn.IconMarginLeft = 8;
            this.error_exit_btn.IconMarginRight = 0;
            this.error_exit_btn.IconRightVisible = true;
            this.error_exit_btn.IconRightZoom = 0D;
            this.error_exit_btn.IconVisible = true;
            this.error_exit_btn.IconZoom = 50D;
            this.error_exit_btn.IsTab = false;
            this.error_exit_btn.Location = new System.Drawing.Point(223, 0);
            this.error_exit_btn.Name = "error_exit_btn";
            this.error_exit_btn.Normalcolor = System.Drawing.Color.Transparent;
            this.error_exit_btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(16)))), ((int)(((byte)(34)))));
            this.error_exit_btn.OnHoverTextColor = System.Drawing.Color.White;
            this.error_exit_btn.selected = false;
            this.error_exit_btn.Size = new System.Drawing.Size(43, 31);
            this.error_exit_btn.TabIndex = 27;
            this.error_exit_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.error_exit_btn.Textcolor = System.Drawing.Color.White;
            this.error_exit_btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error_exit_btn.Click += new System.EventHandler(this.Error_exit_btn_Click);
            // 
            // error_ok_btn
            // 
            this.error_ok_btn.ActiveImage = global::OsmicroAutoShutdown.Properties.Resources.Ok_over_btn;
            this.error_ok_btn.AllowAnimations = true;
            this.error_ok_btn.AllowZooming = false;
            this.error_ok_btn.BackColor = System.Drawing.Color.Transparent;
            this.error_ok_btn.FadeWhenInactive = false;
            this.error_ok_btn.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.error_ok_btn.Image = global::OsmicroAutoShutdown.Properties.Resources.Ok_normal_btn;
            this.error_ok_btn.ImageActive = global::OsmicroAutoShutdown.Properties.Resources.Ok_over_btn;
            this.error_ok_btn.ImageMargin = 0;
            this.error_ok_btn.ImageSize = new System.Drawing.Size(98, 24);
            this.error_ok_btn.ImageZoomSize = new System.Drawing.Size(98, 24);
            this.error_ok_btn.Location = new System.Drawing.Point(83, 103);
            this.error_ok_btn.Name = "error_ok_btn";
            this.error_ok_btn.Rotation = 0;
            this.error_ok_btn.ShowActiveImage = true;
            this.error_ok_btn.ShowCursorChanges = true;
            this.error_ok_btn.ShowImageBorders = false;
            this.error_ok_btn.ShowSizeMarkers = false;
            this.error_ok_btn.Size = new System.Drawing.Size(98, 24);
            this.error_ok_btn.TabIndex = 26;
            this.error_ok_btn.ToolTipText = "";
            this.error_ok_btn.Zoom = 0;
            this.error_ok_btn.ZoomSpeed = 10;
            this.error_ok_btn.Click += new System.EventHandler(this.Error_exit_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::OsmicroAutoShutdown.Properties.Resources.error_message;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.error_exit_btn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 33);
            this.panel1.TabIndex = 28;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 139);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.error_ok_btn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ErrorMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ErrorMessage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuImageButton error_ok_btn;
        private Bunifu.Framework.UI.BunifuFlatButton error_exit_btn;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}