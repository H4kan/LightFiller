
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
            this.polyActions = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.memoryPanel.SuspendLayout();
            this.polyActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(21, 61);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1050, 646);
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
            this.NewPolygonBtn.Location = new System.Drawing.Point(21, 9);
            this.NewPolygonBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewPolygonBtn.Name = "NewPolygonBtn";
            this.NewPolygonBtn.Size = new System.Drawing.Size(129, 40);
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
            this.memoryPanel.Location = new System.Drawing.Point(1102, 44);
            this.memoryPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(302, 740);
            this.memoryPanel.TabIndex = 5;
            // 
            // polyActions
            // 
            this.polyActions.Controls.Add(this.animationBtn);
            this.polyActions.Controls.Add(this.colorVerticeBtn);
            this.polyActions.Controls.Add(this.fillPolygonBtn);
            this.polyActions.Controls.Add(this.movePolygonBtn);
            this.polyActions.Controls.Add(this.moveVerticeBtn);
            this.polyActions.Controls.Add(this.deleteVerticeBtn);
            this.polyActions.Controls.Add(this.addVerticeBtn);
            this.polyActions.Location = new System.Drawing.Point(61, 62);
            this.polyActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.polyActions.Name = "polyActions";
            this.polyActions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.polyActions.Size = new System.Drawing.Size(200, 454);
            this.polyActions.TabIndex = 0;
            this.polyActions.TabStop = false;
            this.polyActions.Text = "Polygon Actions";
            this.polyActions.Visible = false;
            // 
            // colorVerticeBtn
            // 
            this.colorVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.colorVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.colorVerticeBtn.FlatAppearance.BorderSize = 5;
            this.colorVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.colorVerticeBtn.Location = new System.Drawing.Point(30, 317);
            this.colorVerticeBtn.Name = "colorVerticeBtn";
            this.colorVerticeBtn.Size = new System.Drawing.Size(133, 40);
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
            this.fillPolygonBtn.Location = new System.Drawing.Point(30, 262);
            this.fillPolygonBtn.Name = "fillPolygonBtn";
            this.fillPolygonBtn.Size = new System.Drawing.Size(133, 40);
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
            this.movePolygonBtn.Location = new System.Drawing.Point(30, 207);
            this.movePolygonBtn.Name = "movePolygonBtn";
            this.movePolygonBtn.Size = new System.Drawing.Size(133, 40);
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
            this.moveVerticeBtn.Location = new System.Drawing.Point(30, 38);
            this.moveVerticeBtn.Name = "moveVerticeBtn";
            this.moveVerticeBtn.Size = new System.Drawing.Size(133, 40);
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
            this.deleteVerticeBtn.Location = new System.Drawing.Point(30, 94);
            this.deleteVerticeBtn.Name = "deleteVerticeBtn";
            this.deleteVerticeBtn.Size = new System.Drawing.Size(133, 40);
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
            this.addVerticeBtn.Location = new System.Drawing.Point(30, 150);
            this.addVerticeBtn.Name = "addVerticeBtn";
            this.addVerticeBtn.Size = new System.Drawing.Size(133, 40);
            this.addVerticeBtn.TabIndex = 2;
            this.addVerticeBtn.Text = "Add vertice";
            this.addVerticeBtn.UseVisualStyleBackColor = false;
            this.addVerticeBtn.Click += new System.EventHandler(this.addVerticeBtn_Click);
            // 
            // PolygonLbl
            // 
            this.PolygonLbl.AutoSize = true;
            this.PolygonLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PolygonLbl.Location = new System.Drawing.Point(61, 548);
            this.PolygonLbl.Name = "PolygonLbl";
            this.PolygonLbl.Size = new System.Drawing.Size(68, 20);
            this.PolygonLbl.TabIndex = 3;
            this.PolygonLbl.Text = "Polygons";
            // 
            // polygonListBox
            // 
            this.polygonListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.polygonListBox.HideSelection = false;
            this.polygonListBox.Location = new System.Drawing.Point(91, 584);
            this.polygonListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.polygonListBox.Name = "polygonListBox";
            this.polygonListBox.Size = new System.Drawing.Size(133, 120);
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
            this.animationBtn.Location = new System.Drawing.Point(30, 376);
            this.animationBtn.Name = "animationBtn";
            this.animationBtn.Size = new System.Drawing.Size(133, 40);
            this.animationBtn.TabIndex = 7;
            this.animationBtn.Text = "Animation";
            this.animationBtn.UseVisualStyleBackColor = false;
            this.animationBtn.Click += new System.EventHandler(this.animationBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1413, 796);
            this.Controls.Add(this.memoryPanel);
            this.Controls.Add(this.NewPolygonBtn);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.memoryPanel.ResumeLayout(false);
            this.memoryPanel.PerformLayout();
            this.polyActions.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}

