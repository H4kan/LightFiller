using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightFiller.VertexPickers
{
    public class Deleter : VertexPicker
    {
        private MemoryService MemoryService { get; set; }

        public Deleter(Point origin, int index, MemoryService memoryService) : base(origin, index)
        {
            this.MemoryService = memoryService;
            this.MouseClick += DeleteVertice;
        }

        public void DeleteVertice(object sender, MouseEventArgs e)
        {
            this.MemoryService.DeleteVertice(this.Index);
        }

    }
}
