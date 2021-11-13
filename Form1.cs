using LightFiller.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightFiller
{
    public partial class Form1 : Form
    {
        DirectBitmap bmp;

        public DirectBitmap imageBmp;

        public EditMode Mode { get; set; }

        private Polygon CurrentPolygon { get; set; }

        LineService LineService { get; set; }

        public MemoryService MemoryService { get; set; }

        FillingService FillingService { get; set; }

        RandomService RandomService { get; set; }

        LightService LightService { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupScreen();

            var lightShower = new LightShower();
            this.pictureBox.Controls.Add(lightShower);

            this.RandomService = new RandomService();

            this.LightService = new LightService(lightShower);

            this.LightService.InitLight(new Point(this.pictureBox.Width / 2, this.pictureBox.Height / 2));

            this.LineService = new LineService(bmp, pictureBox, LightService, this);


            this.FillingService = new FillingService(this.LineService, this);
            this.MemoryService = new MemoryService(
                this.polyActions, 
                this.polygonListBox,
                this.pictureBox, 
                this.LineService, 
                this.FillingService,
                this.RandomService,
                this);

        }

        private void SetupScreen()
        {
            bmp = new DirectBitmap(pictureBox.Size.Width, pictureBox.Size.Height);
     
            pictureBox.Image = bmp.Bitmap;

            this.k_sTrackBar.SetRange(0, 100);
            this.k_sTrackBar.Value = 50;

            this.k_dTrackBar.SetRange(0, 100);
            this.k_dTrackBar.Value = 50;

            this.mTrackBar.SetRange(0, 100);
            this.mTrackBar.Value = 50;

            this.lightHeightInput.Minimum = 1;
            this.lightHeightInput.Maximum = 2000;
            this.lightHeightInput.Value = 200;

            this.lightHeightInput.ValueChanged += lightHeightInput_ValueChanged;

            this.speedTrackBar.SetRange(0, 100);
            this.speedTrackBar.Value = 50;
        }

        private void BeginPolygon(object sender, MouseEventArgs e)
        {
            CurrentPolygon = new Polygon(e.X, e.Y);
            pictureBox.Invalidate();
            this.pictureBox.MouseClick -= BeginPolygon;
            this.LineService.BeginTracking(e.X, e.Y);

            this.pictureBox.MouseClick += ContinuePolygon;

        }

        private void ContinuePolygon(object sender, MouseEventArgs e)
        {
            
        
            if (e.Button == MouseButtons.Left)
            {
                this.pictureBox.MouseClick -= ContinuePolygon;
                this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;
                CurrentPolygon.AppendLine(this.LineService.LineTracker.LastLine);
                this.LineService.StopTracking();
                pictureBox.Invalidate();
                this.LineService.BeginTracking(e.X, e.Y);
        
                this.pictureBox.MouseClick += ContinuePolygon;
      
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (CurrentPolygon.Vertices.Count < 3) return;
                this.pictureBox.MouseClick -= ContinuePolygon;
                this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;

                var lastLine = this.LineService.LineTracker.LastLine;

                this.LineService.AbortTracking();

                CurrentPolygon.CompletePolygon(
                    this.LineService.CreateLine(CurrentPolygon.Vertices[0].X,
                    CurrentPolygon.Vertices[0].Y,
                    CurrentPolygon.Vertices[CurrentPolygon.Vertices.Count - 1].X,
                    CurrentPolygon.Vertices[CurrentPolygon.Vertices.Count - 1].Y));

                this.MemoryService.SavePolygon(CurrentPolygon);

                this.Mode = EditMode.Default;

                this.NewPolygonBtn.FlatAppearance.BorderColor = Color.Black;
            }
        }

        private void AbortPolygonTracking()
        {
            if (this.LineService.IsLineTracking)
            {
                this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;
                this.pictureBox.MouseClick -= ContinuePolygon;
                this.LineService.AbortTracking();
                foreach (var line in CurrentPolygon.Edges)
                {
                    this.LineService.EraseLine(line);
                }
                CurrentPolygon = null;
            }
            else
            {
                this.pictureBox.MouseClick -= BeginPolygon;
            }
        }

        private void NewPolygonBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.AddPolygon)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.polygonListBox.SelectedItems.Clear();
                this.MemoryService.ExitPolygonOptions();
                this.NewPolygonBtn.FlatAppearance.BorderColor = Color.Red;
                this.pictureBox.MouseClick += BeginPolygon;
                this.Mode = EditMode.AddPolygon;
            }
            
        }

        private void polygonListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ExitAnyMode();
            if (this.polygonListBox.SelectedItems.Count > 0)
            {
                this.MemoryService.SelectedPolygon = this.MemoryService.Polygons[this.polygonListBox.SelectedItems[0].Index];
                this.MemoryService.ShowPolygonOptions();
            }
            else
            {
                this.polyActions.Visible = false;
            }
        }

        private void moveVerticeBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.MoveVertice)
            {
                this.ExitAnyMode();     
            }
            else
            {
                switchToMoveVerticeMode();
            }
        }

        public void switchToMoveVerticeMode()
        {
            this.ExitAnyMode();
            this.Mode = EditMode.MoveVertice;
            this.moveVerticeBtn.FlatAppearance.BorderColor = Color.Red;
            this.MemoryService.EnterMoveVerticeMode();
        }

        private void deleteVerticeBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.DeleteVertice)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.Mode = EditMode.DeleteVertice;
                this.deleteVerticeBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.EnterDeleteVerticeMode();
            }
            
        }

        public void ExitAnyMode()
        {
            switch (this.Mode)
            {
                case EditMode.MoveVertice:
                    this.moveVerticeBtn.FlatAppearance.BorderColor = Color.Black;
                    this.MemoryService.ExitVertexPickersMode();
                    break;
                case EditMode.DeleteVertice:
                    this.deleteVerticeBtn.FlatAppearance.BorderColor = Color.Black;
                    this.MemoryService.ExitVertexPickersMode();
                    break;
                case EditMode.AddPolygon:
                    this.NewPolygonBtn.FlatAppearance.BorderColor = Color.Black;
                    this.AbortPolygonTracking();
                    break;
                case EditMode.AddVertice:
                    this.addVerticeBtn.FlatAppearance.BorderColor = Color.Black;
                    this.MemoryService.ExitVertexPickersMode();
                    break;
                case EditMode.MovePolygon:
                    this.movePolygonBtn.FlatAppearance.BorderColor = Color.Black;
                    this.MemoryService.ExitVertexPickersMode();
                    break;
                case EditMode.FillPolygon:
                    this.fillPolygonBtn.FlatAppearance.BorderColor = Color.Black;
                    break;
                case EditMode.ColorVertice:
                    this.colorVerticeBtn.FlatAppearance.BorderColor = Color.Black;
                    this.MemoryService.ExitVertexPickersMode();
                    break;
                case EditMode.Animation:
                    this.animationBtn.FlatAppearance.BorderColor = Color.Black;
                    this.speedTrackBar.Visible = false;
                    this.speedLabel.Visible = false;
                    this.MemoryService.StopAnimation();
                    break;
                case EditMode.LightMode:
                    this.lightModeBtn.FlatAppearance.BorderColor = Color.Black;
                    this.ExitLightning();
                    break;
                case EditMode.ImagePolygon:
                    this.bitmapImageBtn.FlatAppearance.BorderColor = Color.Black;
                    break;
                case EditMode.HeightImage:
                    this.heightImageBtn.FlatAppearance.BorderColor = Color.Black;
                    break;
            }
            this.Mode = EditMode.Default;
        }

        private void addVerticeBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.AddVertice)
            {
                this.ExitAnyMode();

            }
            else
            {
                this.ExitAnyMode();
                this.Mode = EditMode.AddVertice;
                this.addVerticeBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.EnterAddVerticeMode();
            }
        }

        private void movePolygonBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.MovePolygon)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.Mode = EditMode.MovePolygon;
                this.movePolygonBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.EnterMovePolygonMode();
            }
        }

        private void fillPolygonBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.FillPolygon)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.Mode = EditMode.FillPolygon;
                this.fillPolygonBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.EnterFillPolygonMode();
                this.ExitAnyMode();
            }
        }

        private void colorVerticeBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.ColorVertice)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.Mode = EditMode.ColorVertice;
                this.colorVerticeBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.EnterColorVerticeMode();
            }
        }

        private void animationBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.Animation)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.polygonListBox.SelectedItems.Clear();
                this.Mode = EditMode.Animation;
                this.speedTrackBar.Visible = true;
                this.speedLabel.Visible = true;
                this.animationBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.BeginAnimation();
            }
        }

        private void bitmapImageBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.ImagePolygon)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.Mode = EditMode.ImagePolygon;
                this.bitmapImageBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.EnterImagePolygonMode();
                this.ExitAnyMode();
            }
        }

        private void lightModeBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.LightMode)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.polygonListBox.SelectedItems.Clear();
                this.Mode = EditMode.LightMode;
                this.lightModeBtn.FlatAppearance.BorderColor = Color.Red;
                this.lightSettingsPanel.Visible = true;
                
            }
        }

        private void lightColorBtn_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = Color.White;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.LightService.SetLight(colorDialog.Color);
            }
            this.MemoryService.CauseRedrawPolygons();
        }

        private void k_dTrackBar_Scroll(object sender, EventArgs e)
        {
            this.LightService.k_d = this.k_dTrackBar.Value / (double)100;
            this.MemoryService.CauseRedrawPolygons();
        }

        private void k_sTrackBar_Scroll(object sender, EventArgs e)
        {
            this.LightService.k_s = this.k_sTrackBar.Value / (double)100;
            this.MemoryService.CauseRedrawPolygons();
        }

        private void lightEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.FillingService.isLightningApplied = this.lightEnabledCheckBox.Checked;
            this.lightHeightInput.Enabled = this.lightEnabledCheckBox.Checked;
            this.k_dTrackBar.Enabled = this.lightEnabledCheckBox.Checked;
            this.k_sTrackBar.Enabled = this.lightEnabledCheckBox.Checked;
            this.mTrackBar.Enabled = this.lightEnabledCheckBox.Checked;
            this.lightPositionBtn.Enabled = this.lightEnabledCheckBox.Checked;
            this.lightColorBtn.Enabled = this.lightEnabledCheckBox.Checked;
            this.LightService.LightShower.SetLocation(this.LightService.LightPosition);
            this.LightService.LightShower.Visible = this.lightEnabledCheckBox.Checked;
            this.MemoryService.CauseRedrawPolygons();
        }

        private void lightHeightInput_ValueChanged(object sender, EventArgs e)
        {
            this.LightService.LightHeight = Convert.ToInt32(this.lightHeightInput.Value);
            this.MemoryService.CauseRedrawPolygons();
        }

        private void lightPositionBtn_Click(object sender, EventArgs e)
        {
            this.pictureBox.Cursor = Cursors.Hand;
            this.pictureBox.MouseClick += setLightLocation;
        }

        private void setLightLocation(object sender, MouseEventArgs e)
        {
            this.pictureBox.MouseClick -= setLightLocation;
            this.LightService.LightPosition = e.Location;
            this.pictureBox.Cursor = Cursors.Default;
            this.LightService.LightShower.SetLocation(this.LightService.LightPosition);
            this.MemoryService.CauseRedrawPolygons();
        }

        private void ExitLightning()
        {
            this.lightSettingsPanel.Visible = false;
            this.pictureBox.Cursor = Cursors.Default;
            this.pictureBox.MouseClick -= setLightLocation;
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            this.LightService.m = this.mTrackBar.Value;
            this.MemoryService.CauseRedrawPolygons();
        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            this.MemoryService.speedRatio = this.speedTrackBar.Value / (double)100;
        }

        private void heightImageBtn_Click(object sender, EventArgs e)
        {
            if (this.Mode == EditMode.HeightImage)
            {
                this.ExitAnyMode();
            }
            else
            {
                this.ExitAnyMode();
                this.Mode = EditMode.HeightImage;
                this.heightImageBtn.FlatAppearance.BorderColor = Color.Red;
                this.MemoryService.EnterHeightImageMode();
                this.ExitAnyMode();
            }
        }
    }

    
}
