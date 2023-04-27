using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SokobanDemo
{
    public partial class instructions : Form
    {
        Bitmap graphicsInstruction = new Bitmap(typeof(instructions), "graphics.png");

        public instructions()
        {
            InitializeComponent();
            pbGraphicInstruct.Image = graphicsInstruction;
        }
    }
}
