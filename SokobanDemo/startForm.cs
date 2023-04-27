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
    public partial class startForm : Form
    {

        Bitmap creepyFarm = new Bitmap(typeof(startForm), "creepyFarm.png");

        public startForm()
        {
            InitializeComponent();
            pbCreepyFarm.Image = creepyFarm;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnInstruct_Click(object sender, EventArgs e)
        {
            instructions instructions = new instructions();
            instructions.ShowDialog();
        }
    }
}
