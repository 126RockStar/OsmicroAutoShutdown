namespace OsmicroAutoShutdown.SubForm
{
    partial class Confirmation
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
            this.confirm_no_btn = new Bunifu.UI.WinForms.BunifuImageButton();
            this.confirm_yes = new Bunifu.UI.WinForms.BunifuImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.confirm_exit_btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OsmicroAutoShutdown.Properties.Resources.confirmation_message;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // confirm_no_btn
            // 
            this.confirm_no_btn.ActiveImage = global::OsmicroAutoShutdown.Properties.Resources.no_alert_overl_btn;
            this.confirm_no_btn.AllowAnimations = true;
            this.confirm_no_btn.AllowZooming = false;
            this.confirm_no_btn.BackColor = System.Drawing.Color.Transparent;
            this.confirm_no_btn.FadeWhenInactive = false;
            this.confirm_no_btn.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.confirm_no_btn.Image = global::OsmicroAutoShutdown.Properties.Resources.no_normal_btn;
            this.confirm_no_btn.ImageActive = global::OsmicroAutoShutdown.Properties.Resources.no_alert_overl_btn;
            this.confirm_no_btn.ImageMargin = 0;
            this.confirm_no_btn.ImageSize = new System.Drawing.Size(98, 24);
            this.confirm_no_btn.ImageZoomSize = new System.Drawing.Size(98, 24);
            this.confirm_no_btn.Location = new System.Drawing.Point(125, 103);
            this.confirm_no_btn.Name = "confirm_no_btn";
            this.confirm_no_btn.Rotation = 0;
            this.confirm_no_btn.ShowActiveImage = true;
            this.confirm_no_btn.ShowCursorChanges = true;
            this.confirm_no_btn.ShowImageBorders = false;
            this.confirm_no_btn.ShowSizeMarkers = false;
            this.confirm_no_btn.Size = new System.Drawing.Size(98, 24);
            this.confirm_no_btn.TabIndex = 27;
            this.confirm_no_btn.ToolTipText = "";
            this.confirm_no_btn.Zoom = 0;
            this.confirm_no_btn.ZoomSpeed = 10;
            this.confirm_no_btn.Click += new System.EventHandler(this.Confirm_no_btn_Click);
            // 
            // confirm_yes
            // 
            this.confirm_yes.ActiveImage = global::OsmicroAutoShutdown.Properties.Resources.yes_over_btn;
            this.confirm_yes.AllowAnimations = true;
            this.confirm_yes.AllowZooming = false;
            this.confirm_yes.BackColor = System.Drawing.Color.Transparent;
            this.confirm_yes.FadeWhenInactive = false;
            this.confirm_yes.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.confirm_yes.Image = global::OsmicroAutoShutdown.Properties.Resources.yes_normal_btn;
            this.confirm_yes.ImageActive = global::OsmicroAutoShutdown.Properties.Resources.yes_over_btn;
            this.confirm_yes.ImageMargin = 0;
            this.confirm_yes.ImageSize = new System.Drawing.Size(98, 24);
            this.confirm_yes.ImageZoomSize = new System.Drawing.Size(98, 24);
            this.confirm_yes.Location = new System.Drawing.Point(12, 103);
            this.confirm_yes.Name = "confirm_yes";
            this.confirm_yes.Rotation = 0;
            this.confirm_yes.ShowActiveImage = true;
            this.confirm_yes.ShowCursorChanges = true;
            this.confirm_yes.ShowImageBorders = false;
            this.confirm_yes.ShowSizeMarkers = false;
            this.confirm_yes.Size = new System.Drawing.Size(98, 24);
            this.confirm_yes.TabIndex = 28;
            this.confirm_yes.ToolTipText = "";
            this.confirm_yes.Zoom = 0;
            this.confirm_yes.ZoomSpeed = 10;
            this.confirm_yes.Click += new System.EventHandler(this.Confirm_yes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.confirm_exit_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 34);
            this.panel1.TabIndex = 29;
            // 
            // confirm_exit_btn
            // 
            this.confirm_exit_btn.Active = false;
            this.confirm_exit_btn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(7)))), ((int)(((byte)(23)))));
            this.confirm_exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.confirm_exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.confirm_exit_btn.BorderRadius = 0;
            this.confirm_exit_btn.ButtonText = "";
            this.confirm_exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm_exit_btn.DisabledColor = System.Drawing.Color.Gray;
            this.confirm_exit_btn.Iconcolor = System.Drawing.Color.Transparent;
            this.confirm_exit_btn.Iconimage = global::OsmicroAutoShutdown.Properties.Resources.exit_png;
            this.confirm_exit_btn.Iconimage_right = null;
            this.confirm_exit_btn.Iconimage_right_Selected = null;
            this.confirm_exit_btn.Iconimage_Selected = null;
            this.confirm_exit_btn.IconMarginLeft = 8;
            this.confirm_exit_btn.IconMarginRight = 0;
            this.confirm_exit_btn.IconRightVisible = true;
            this.confirm_exit_btn.IconRightZoom = 0D;
            this.confirm_exit_btn.IconVisible = true;
            this.confirm_exit_btn.IconZoom = 50D;
            this.confirm_exit_btn.IsTab = false;
            this.confirm_exit_btn.Location = new System.Drawing.Point(192, 0);
            this.confirm_exit_btn.Name = "confirm_exit_btn";
            this.confirm_exit_btn.Normalcolor = System.Drawing.Color.Transparent;
            this.confirm_exit_btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(16)))), ((int)(((byte)(34)))));
            this.confirm_exit_btn.OnHoverTextColor = System.Drawing.Color.White;
            this.confirm_exit_btn.selected = false;
            this.confirm_exit_btn.Size = new System.Drawing.Size(43, 31);
            this.confirm_exit_btn.TabIndex = 28;
            this.confirm_exit_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.confirm_exit_btn.Textcolor = System.Drawing.Color.White;
            this.confirm_exit_btn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_exit_btn.Click += new System.EventHandler(this.Confirm_exit_btn_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 139);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirm_yes);
            this.Controls.Add(this.confirm_no_btn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Confirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuImageButton confirm_no_btn;
        private Bunifu.UI.WinForms.BunifuImageButton confirm_yes;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuFlatButton confirm_exit_btn;
    }
}