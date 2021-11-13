
namespace LightFiller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.NewPolygonBtn = new System.Windows.Forms.Button();
            this.memoryPanel = new System.Windows.Forms.Panel();
            this.lightSettingsPanel = new System.Windows.Forms.GroupBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.lightEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.lightHeightLabel = new System.Windows.Forms.Label();
            this.lightHeightInput = new System.Windows.Forms.NumericUpDown();
            this.lightPositionBtn = new System.Windows.Forms.Button();
            this.k_sLabel = new System.Windows.Forms.Label();
            this.k_dLabel = new System.Windows.Forms.Label();
            this.k_sTrackBar = new System.Windows.Forms.TrackBar();
            this.k_dTrackBar = new System.Windows.Forms.TrackBar();
            this.lightColorBtn = new System.Windows.Forms.Button();
            this.polyActions = new System.Windows.Forms.GroupBox();
            this.bitmapImageBtn = new System.Windows.Forms.Button();
            this.colorVerticeBtn = new System.Windows.Forms.Button();
            this.fillPolygonBtn = new System.Windows.Forms.Button();
            this.movePolygonBtn = new System.Windows.Forms.Button();
            this.moveVerticeBtn = new System.Windows.Forms.Button();
            this.deleteVerticeBtn = new System.Windows.Forms.Button();
            this.addVerticeBtn = new System.Windows.Forms.Button();
            this.PolygonLbl = new System.Windows.Forms.Label();
            this.polygonListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.animationBtn = new System.Windows.Forms.Button();
            this.lightModeBtn = new System.Windows.Forms.Button();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.heightImageBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.memoryPanel.SuspendLayout();
            this.lightSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightHeightInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_sTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_dTrackBar)).BeginInit();
            this.polyActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(24, 81);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1200, 861);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // NewPolygonBtn
            // 
            this.NewPolygonBtn.BackColor = System.Drawing.Color.Black;
            this.NewPolygonBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.NewPolygonBtn.FlatAppearance.BorderSize = 5;
            this.NewPolygonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewPolygonBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NewPolygonBtn.Location = new System.Drawing.Point(24, 12);
            this.NewPolygonBtn.Name = "NewPolygonBtn";
            this.NewPolygonBtn.Size = new System.Drawing.Size(147, 53);
            this.NewPolygonBtn.TabIndex = 4;
            this.NewPolygonBtn.Text = "New polygon";
            this.NewPolygonBtn.UseVisualStyleBackColor = false;
            this.NewPolygonBtn.Click += new System.EventHandler(this.NewPolygonBtn_Click);
            // 
            // memoryPanel
            // 
            this.memoryPanel.Controls.Add(this.polyActions);
            this.memoryPanel.Controls.Add(this.PolygonLbl);
            this.memoryPanel.Controls.Add(this.polygonListBox);
            this.memoryPanel.Controls.Add(this.lightSettingsPanel);
            this.memoryPanel.Location = new System.Drawing.Point(1259, 59);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(345, 987);
            this.memoryPanel.TabIndex = 5;
            // 
            // lightSettingsPanel
            // 
            this.lightSettingsPanel.Controls.Add(this.mLabel);
            this.lightSettingsPanel.Controls.Add(this.mTrackBar);
            this.lightSettingsPanel.Controls.Add(this.lightEnabledCheckBox);
            this.lightSettingsPanel.Controls.Add(this.lightHeightLabel);
            this.lightSettingsPanel.Controls.Add(this.lightHeightInput);
            this.lightSettingsPanel.Controls.Add(this.lightPositionBtn);
            this.lightSettingsPanel.Controls.Add(this.k_sLabel);
            this.lightSettingsPanel.Controls.Add(this.k_dLabel);
            this.lightSettingsPanel.Controls.Add(this.k_sTrackBar);
            this.lightSettingsPanel.Controls.Add(this.k_dTrackBar);
            this.lightSettingsPanel.Controls.Add(this.lightColorBtn);
            this.lightSettingsPanel.Location = new System.Drawing.Point(70, 71);
            this.lightSettingsPanel.Name = "lightSettingsPanel";
            this.lightSettingsPanel.Size = new System.Drawing.Size(229, 648);
            this.lightSettingsPanel.TabIndex = 9;
            this.lightSettingsPanel.TabStop = false;
            this.lightSettingsPanel.Text = "Light settings";
            this.lightSettingsPanel.Visible = false;
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(36, 345);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(22, 20);
            this.mLabel.TabIndex = 17;
            this.mLabel.Text = "m";
            // 
            // mTrackBar
            // 
            this.mTrackBar.Enabled = false;
            this.mTrackBar.Location = new System.Drawing.Point(35, 384);
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(151, 56);
            this.mTrackBar.TabIndex = 16;
            this.mTrackBar.Scroll += new System.EventHandler(this.mTrackBar_Scroll);
            // 
            // lightEnabledCheckBox
            // 
            this.lightEnabledCheckBox.AutoSize = true;
            this.lightEnabledCheckBox.Location = new System.Drawing.Point(33, 57);
            this.lightEnabledCheckBox.Name = "lightEnabledCheckBox";
            this.lightEnabledCheckBox.Size = new System.Drawing.Size(122, 24);
            this.lightEnabledCheckBox.TabIndex = 15;
            this.lightEnabledCheckBox.Text = "Light enabled";
            this.lightEnabledCheckBox.UseVisualStyleBackColor = true;
            this.lightEnabledCheckBox.CheckedChanged += new System.EventHandler(this.lightEnabledCheckBox_CheckedChanged);
            // 
            // lightHeightLabel
            // 
            this.lightHeightLabel.AutoSize = true;
            this.lightHeightLabel.Location = new System.Drawing.Point(34, 107);
            this.lightHeightLabel.Name = "lightHeightLabel";
            this.lightHeightLabel.Size = new System.Drawing.Size(54, 20);
            this.lightHeightLabel.TabIndex = 14;
            this.lightHeightLabel.Text = "Height";
            // 
            // lightHeightInput
            // 
            this.lightHeightInput.Enabled = false;
            this.lightHeightInput.Location = new System.Drawing.Point(36, 140);
            this.lightHeightInput.Name = "lightHeightInput";
            this.lightHeightInput.Size = new System.Drawing.Size(150, 27);
            this.lightHeightInput.TabIndex = 13;
            // 
            // lightPositionBtn
            // 
            this.lightPositionBtn.BackColor = System.Drawing.Color.Black;
            this.lightPositionBtn.Enabled = false;
            this.lightPositionBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.lightPositionBtn.FlatAppearance.BorderSize = 5;
            this.lightPositionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightPositionBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.lightPositionBtn.Location = new System.Drawing.Point(32, 460);
            this.lightPositionBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightPositionBtn.Name = "lightPositionBtn";
            this.lightPositionBtn.Size = new System.Drawing.Size(152, 53);
            this.lightPositionBtn.TabIndex = 12;
            this.lightPositionBtn.Text = "Choose position";
            this.lightPositionBtn.UseVisualStyleBackColor = false;
            this.lightPositionBtn.Click += new System.EventHandler(this.lightPositionBtn_Click);
            // 
            // k_sLabel
            // 
            this.k_sLabel.AutoSize = true;
            this.k_sLabel.Location = new System.Drawing.Point(33, 179);
            this.k_sLabel.Name = "k_sLabel";
            this.k_sLabel.Size = new System.Drawing.Size(28, 20);
            this.k_sLabel.TabIndex = 11;
            this.k_sLabel.Text = "k_s";
            // 
            // k_dLabel
            // 
            this.k_dLabel.AutoSize = true;
            this.k_dLabel.Location = new System.Drawing.Point(36, 264);
            this.k_dLabel.Name = "k_dLabel";
            this.k_dLabel.Size = new System.Drawing.Size(31, 20);
            this.k_dLabel.TabIndex = 10;
            this.k_dLabel.Text = "k_d";
            // 
            // k_sTrackBar
            // 
            this.k_sTrackBar.Enabled = false;
            this.k_sTrackBar.Location = new System.Drawing.Point(33, 297);
            this.k_sTrackBar.Name = "k_sTrackBar";
            this.k_sTrackBar.Size = new System.Drawing.Size(151, 56);
            this.k_sTrackBar.TabIndex = 9;
            this.k_sTrackBar.Scroll += new System.EventHandler(this.k_sTrackBar_Scroll);
            // 
            // k_dTrackBar
            // 
            this.k_dTrackBar.Enabled = false;
            this.k_dTrackBar.Location = new System.Drawing.Point(34, 215);
            this.k_dTrackBar.Name = "k_dTrackBar";
            this.k_dTrackBar.Size = new System.Drawing.Size(151, 56);
            this.k_dTrackBar.TabIndex = 8;
            this.k_dTrackBar.Scroll += new System.EventHandler(this.k_dTrackBar_Scroll);
            // 
            // lightColorBtn
            // 
            this.lightColorBtn.BackColor = System.Drawing.Color.Black;
            this.lightColorBtn.Enabled = false;
            this.lightColorBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.lightColorBtn.FlatAppearance.BorderSize = 5;
            this.lightColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightColorBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.lightColorBtn.Location = new System.Drawing.Point(32, 530);
            this.lightColorBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightColorBtn.Name = "lightColorBtn";
            this.lightColorBtn.Size = new System.Drawing.Size(152, 53);
            this.lightColorBtn.TabIndex = 7;
            this.lightColorBtn.Text = "Color";
            this.lightColorBtn.UseVisualStyleBackColor = false;
            this.lightColorBtn.Click += new System.EventHandler(this.lightColorBtn_Click);
            // 
            // polyActions
            // 
            this.polyActions.Controls.Add(this.heightImageBtn);
            this.polyActions.Controls.Add(this.bitmapImageBtn);
            this.polyActions.Controls.Add(this.colorVerticeBtn);
            this.polyActions.Controls.Add(this.fillPolygonBtn);
            this.polyActions.Controls.Add(this.movePolygonBtn);
            this.polyActions.Controls.Add(this.moveVerticeBtn);
            this.polyActions.Controls.Add(this.deleteVerticeBtn);
            this.polyActions.Controls.Add(this.addVerticeBtn);
            this.polyActions.Location = new System.Drawing.Point(70, 83);
            this.polyActions.Name = "polyActions";
            this.polyActions.Size = new System.Drawing.Size(229, 645);
            this.polyActions.TabIndex = 0;
            this.polyActions.TabStop = false;
            this.polyActions.Text = "Polygon Actions";
            this.polyActions.Visible = false;
            // 
            // bitmapImageBtn
            // 
            this.bitmapImageBtn.BackColor = System.Drawing.Color.Black;
            this.bitmapImageBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bitmapImageBtn.FlatAppearance.BorderSize = 5;
            this.bitmapImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bitmapImageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.bitmapImageBtn.Location = new System.Drawing.Point(32, 499);
            this.bitmapImageBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bitmapImageBtn.Name = "bitmapImageBtn";
            this.bitmapImageBtn.Size = new System.Drawing.Size(152, 53);
            this.bitmapImageBtn.TabIndex = 7;
            this.bitmapImageBtn.Text = "Color texture";
            this.bitmapImageBtn.UseVisualStyleBackColor = false;
            this.bitmapImageBtn.Click += new System.EventHandler(this.bitmapImageBtn_Click);
            // 
            // colorVerticeBtn
            // 
            this.colorVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.colorVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.colorVerticeBtn.FlatAppearance.BorderSize = 5;
            this.colorVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.colorVerticeBtn.Location = new System.Drawing.Point(34, 423);
            this.colorVerticeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colorVerticeBtn.Name = "colorVerticeBtn";
            this.colorVerticeBtn.Size = new System.Drawing.Size(152, 53);
            this.colorVerticeBtn.TabIndex = 6;
            this.colorVerticeBtn.Text = "Color vertice";
            this.colorVerticeBtn.UseVisualStyleBackColor = false;
            this.colorVerticeBtn.Click += new System.EventHandler(this.colorVerticeBtn_Click);
            // 
            // fillPolygonBtn
            // 
            this.fillPolygonBtn.BackColor = System.Drawing.Color.Black;
            this.fillPolygonBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.fillPolygonBtn.FlatAppearance.BorderSize = 5;
            this.fillPolygonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillPolygonBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.fillPolygonBtn.Location = new System.Drawing.Point(34, 349);
            this.fillPolygonBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fillPolygonBtn.Name = "fillPolygonBtn";
            this.fillPolygonBtn.Size = new System.Drawing.Size(152, 53);
            this.fillPolygonBtn.TabIndex = 5;
            this.fillPolygonBtn.Text = "FIll polygon";
            this.fillPolygonBtn.UseVisualStyleBackColor = false;
            this.fillPolygonBtn.Click += new System.EventHandler(this.fillPolygonBtn_Click);
            // 
            // movePolygonBtn
            // 
            this.movePolygonBtn.BackColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderSize = 5;
            this.movePolygonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.movePolygonBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.movePolygonBtn.Location = new System.Drawing.Point(34, 276);
            this.movePolygonBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.movePolygonBtn.Name = "movePolygonBtn";
            this.movePolygonBtn.Size = new System.Drawing.Size(152, 53);
            this.movePolygonBtn.TabIndex = 4;
            this.movePolygonBtn.Text = "Move polygon";
            this.movePolygonBtn.UseVisualStyleBackColor = false;
            this.movePolygonBtn.Click += new System.EventHandler(this.movePolygonBtn_Click);
            // 
            // moveVerticeBtn
            // 
            this.moveVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.moveVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.moveVerticeBtn.FlatAppearance.BorderSize = 5;
            this.moveVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.moveVerticeBtn.Location = new System.Drawing.Point(34, 51);
            this.moveVerticeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveVerticeBtn.Name = "moveVerticeBtn";
            this.moveVerticeBtn.Size = new System.Drawing.Size(152, 53);
            this.moveVerticeBtn.TabIndex = 0;
            this.moveVerticeBtn.Text = "Move vertice";
            this.moveVerticeBtn.UseVisualStyleBackColor = false;
            this.moveVerticeBtn.Click += new System.EventHandler(this.moveVerticeBtn_Click);
            // 
            // deleteVerticeBtn
            // 
            this.deleteVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.deleteVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteVerticeBtn.FlatAppearance.BorderSize = 5;
            this.deleteVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteVerticeBtn.Location = new System.Drawing.Point(34, 125);
            this.deleteVerticeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteVerticeBtn.Name = "deleteVerticeBtn";
            this.deleteVerticeBtn.Size = new System.Drawing.Size(152, 53);
            this.deleteVerticeBtn.TabIndex = 1;
            this.deleteVerticeBtn.Text = "Delete vertice";
            this.deleteVerticeBtn.UseVisualStyleBackColor = false;
            this.deleteVerticeBtn.Click += new System.EventHandler(this.deleteVerticeBtn_Click);
            // 
            // addVerticeBtn
            // 
            this.addVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.addVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addVerticeBtn.FlatAppearance.BorderSize = 5;
            this.addVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addVerticeBtn.Location = new System.Drawing.Point(34, 200);
            this.addVerticeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addVerticeBtn.Name = "addVerticeBtn";
            this.addVerticeBtn.Size = new System.Drawing.Size(152, 53);
            this.addVerticeBtn.TabIndex = 2;
            this.addVerticeBtn.Text = "Add vertice";
            this.addVerticeBtn.UseVisualStyleBackColor = false;
            this.addVerticeBtn.Click += new System.EventHandler(this.addVerticeBtn_Click);
            // 
            // PolygonLbl
            // 
            this.PolygonLbl.AutoSize = true;
            this.PolygonLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PolygonLbl.Location = new System.Drawing.Point(70, 731);
            this.PolygonLbl.Name = "PolygonLbl";
            this.PolygonLbl.Size = new System.Drawing.Size(85, 25);
            this.PolygonLbl.TabIndex = 3;
            this.PolygonLbl.Text = "Polygons";
            // 
            // polygonListBox
            // 
            this.polygonListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.polygonListBox.HideSelection = false;
            this.polygonListBox.Location = new System.Drawing.Point(104, 779);
            this.polygonListBox.Name = "polygonListBox";
            this.polygonListBox.Size = new System.Drawing.Size(151, 159);
            this.polygonListBox.TabIndex = 2;
            this.polygonListBox.UseCompatibleStateImageBehavior = false;
            this.polygonListBox.SelectedIndexChanged += new System.EventHandler(this.polygonListBox_SelectedIndexChanged);
            // 
            // animationBtn
            // 
            this.animationBtn.BackColor = System.Drawing.Color.Black;
            this.animationBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.animationBtn.FlatAppearance.BorderSize = 5;
            this.animationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.animationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.animationBtn.Location = new System.Drawing.Point(369, 12);
            this.animationBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.animationBtn.Name = "animationBtn";
            this.animationBtn.Size = new System.Drawing.Size(152, 53);
            this.animationBtn.TabIndex = 7;
            this.animationBtn.Text = "Animation";
            this.animationBtn.UseVisualStyleBackColor = false;
            this.animationBtn.Click += new System.EventHandler(this.animationBtn_Click);
            // 
            // lightModeBtn
            // 
            this.lightModeBtn.BackColor = System.Drawing.Color.Black;
            this.lightModeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.lightModeBtn.FlatAppearance.BorderSize = 5;
            this.lightModeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightModeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.lightModeBtn.Location = new System.Drawing.Point(198, 12);
            this.lightModeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightModeBtn.Name = "lightModeBtn";
            this.lightModeBtn.Size = new System.Drawing.Size(152, 53);
            this.lightModeBtn.TabIndex = 8;
            this.lightModeBtn.Text = "Light mode";
            this.lightModeBtn.UseVisualStyleBackColor = false;
            this.lightModeBtn.Click += new System.EventHandler(this.lightModeBtn_Click);
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Location = new System.Drawing.Point(551, 37);
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(130, 56);
            this.speedTrackBar.TabIndex = 9;
            this.speedTrackBar.Visible = false;
            this.speedTrackBar.Scroll += new System.EventHandler(this.speedTrackBar_Scroll);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(551, 9);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(51, 20);
            this.speedLabel.TabIndex = 11;
            this.speedLabel.Text = "Speed";
            this.speedLabel.Visible = false;
            // 
            // heightImageBtn
            // 
            this.heightImageBtn.BackColor = System.Drawing.Color.Black;
            this.heightImageBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.heightImageBtn.FlatAppearance.BorderSize = 5;
            this.heightImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heightImageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.heightImageBtn.Location = new System.Drawing.Point(32, 576);
            this.heightImageBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.heightImageBtn.Name = "heightImageBtn";
            this.heightImageBtn.Size = new System.Drawing.Size(152, 53);
            this.heightImageBtn.TabIndex = 8;
            this.heightImageBtn.Text = "Height texture";
            this.heightImageBtn.UseVisualStyleBackColor = false;
            this.heightImageBtn.Click += new System.EventHandler(this.heightImageBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1615, 1061);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.lightModeBtn);
            this.Controls.Add(this.animationBtn);
            this.Controls.Add(this.memoryPanel);
            this.Controls.Add(this.NewPolygonBtn);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.speedTrackBar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.memoryPanel.ResumeLayout(false);
            this.memoryPanel.PerformLayout();
            this.lightSettingsPanel.ResumeLayout(false);
            this.lightSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightHeightInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_sTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_dTrackBar)).EndInit();
            this.polyActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button NewPolygonBtn;
        private System.Windows.Forms.Panel memoryPanel;
        private System.Windows.Forms.Label PolygonLbl;
        private System.Windows.Forms.ListView polygonListBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button deleteVerticeBtn;
        private System.Windows.Forms.Button moveVerticeBtn;
        private System.Windows.Forms.Button addVerticeBtn;
        private System.Windows.Forms.Button movePolygonBtn;
        private System.Windows.Forms.GroupBox polyActions;
        private System.Windows.Forms.Button fillPolygonBtn;
        private System.Windows.Forms.Button colorVerticeBtn;
        private System.Windows.Forms.Button animationBtn;
        private System.Windows.Forms.Button bitmapImageBtn;
        private System.Windows.Forms.Button lightModeBtn;
        private System.Windows.Forms.GroupBox lightSettingsPanel;
        private System.Windows.Forms.Button lightColorBtn;
        private System.Windows.Forms.Label k_dLabel;
        private System.Windows.Forms.TrackBar k_sTrackBar;
        private System.Windows.Forms.TrackBar k_dTrackBar;
        private System.Windows.Forms.Label k_sLabel;
        private System.Windows.Forms.NumericUpDown lightHeightInput;
        private System.Windows.Forms.Button lightPositionBtn;
        private System.Windows.Forms.Label lightHeightLabel;
        private System.Windows.Forms.CheckBox lightEnabledCheckBox;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.TrackBar mTrackBar;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button heightImageBtn;
    }
}

