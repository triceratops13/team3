using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string id = textBox2.Text;
            string type = textBox3.Text;

            Client client = new Client();
            client.generateIdNumber();
            if(type.ToLower() == "online")
            {
                client.setTypeOnline();
            }
            else if(type.ToLower() == "offline")
            {
                client.setTypeOffline();
            }
            else
            {
                MessageBox.Show("Incorect type");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
