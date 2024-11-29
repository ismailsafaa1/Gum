using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GymUnversity
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

     
        private void button3_Click(object sender, EventArgs e)
        {
            Traines te = new Traines();
            te.ShowDialog();
        }

      
    }
}
