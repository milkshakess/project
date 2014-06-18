using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PingPongReseau
{
    public partial class FormIP : Form
    {
        public string IpServeur;

        public FormIP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IpServeur = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void FormIP_Load(object sender, EventArgs e)
        {

        }
    }
}
