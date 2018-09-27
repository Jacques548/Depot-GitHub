using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIORIENTATION
{
    public partial class Form1 : Form
    {
        string ndc = "a";
        string mdp = "a";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == ndc && textBox2.Text== mdp)
            {
                Orientation ori = new Orientation();
                ori.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nom de compte ou mot de passe incorrect.");
            }
        }
    }
}
