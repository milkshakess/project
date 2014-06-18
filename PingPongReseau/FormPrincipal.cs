using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PingPongReseau
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect(0);
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(" Ce jeu a été devellopé dans le but de réalisé un projet en c#, mettant en oeuvre des structures de données, des interfaces graphiques, des threads et de la serialisation \n\n Réalisé par Echatibi Sofian ");

        }

    }
}
