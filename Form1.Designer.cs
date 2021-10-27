
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
            this.movePolygonBtn = new System.Windows.Forms.Button();
            this.moveVerticeBtn = new System.Windows.Forms.Button();
            this.deleteVerticeBtn = new System.Windows.Forms.Button();
            this.addVerticeBtn = new System.Windows.Forms.Button();
            this.PolygonLbl = new System.Windows.Forms.Label();
            this.polygonListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.memoryPanel.SuspendLayout();
            this.polyActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(24, 81);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1200, 862);
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
            this.memoryPanel.Location = new System.Drawing.Point(1259, 59);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(345, 987);
            this.memoryPanel.TabIndex = 5;
            // 
            // polyActions
            // 
            this.polyActions.Controls.Add(this.movePolygonBtn);
            this.polyActions.Controls.Add(this.moveVerticeBtn);
            this.polyActions.Controls.Add(this.deleteVerticeBtn);
            this.polyActions.Controls.Add(this.addVerticeBtn);
            this.polyActions.Location = new System.Drawing.Point(70, 83);
            this.polyActions.Name = "polyActions";
            this.polyActions.Size = new System.Drawing.Size(229, 417);
            this.polyActions.TabIndex = 0;
            this.polyActions.TabStop = false;
            this.polyActions.Text = "Polygon Actions";
            this.polyActions.Visible = false;
            // 
            // movePolygonBtn
            // 
            this.movePolygonBtn.BackColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderSize = 5;
            this.movePolygonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.movePolygonBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.movePolygonBtn.Location = new System.Drawing.Point(34, 345);
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
            this.deleteVerticeBtn.Location = new System.Drawing.Point(34, 126);
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
            this.PolygonLbl.Location = new System.Drawing.Point(70, 568);
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
            this.polygonListBox.Location = new System.Drawing.Point(109, 596);
            this.polygonListBox.Name = "polygonListBox";
            this.polygonListBox.Size = new System.Drawing.Size(151, 159);
            this.polygonListBox.TabIndex = 2;
            this.polygonListBox.UseCompatibleStateImageBehavior = false;
            this.polygonListBox.SelectedIndexChanged += new System.EventHandler(this.polygonListBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1615, 1076);
            this.Controls.Add(this.memoryPanel);
            this.Controls.Add(this.NewPolygonBtn);
            this.Controls.Add(this.pictureBox);
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
    }
}

