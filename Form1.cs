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
        Bitmap bmp;

        public EditMode Mode { get; set; }

        private Polygon CurrentPolygon { get; set; }

        LineService LineService { get; set; }

        MemoryService MemoryService { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupScreen();

            this.LineService = new LineService(bmp, pictureBox);
            this.MemoryService = new MemoryService(
                this.polyActions, 
                this.polygonListBox,
                this.pictureBox, 
                this.LineService, 
                this);
           

        }

        private void SetupScreen()
        {
            bmp = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
     
            pictureBox.Image = bmp;
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
    }

    
}
