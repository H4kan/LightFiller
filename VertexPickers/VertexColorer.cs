using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller.VertexPickers
{
    public class VertexColorer : VertexPicker
    {
        private MemoryService MemoryService { get; set; }

        public VertexColorer(Point origin, int index, MemoryService memoryService) : base(origin, index)
        {
            this.MemoryService = memoryService;
            this.MouseClick += ColorVertice;
        }

        public void ColorVertice(object sender, MouseEventArgs e)
        {
            this.MemoryService.ColorVertice(this.Index);
        }

    }
}
