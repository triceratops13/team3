using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientManager
{
    public partial class Form1 : Form
    {
        public Client clientManager = new Client();

        public Form1()
        {
            InitializeComponent();
        }

        // Add client
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string type = checkBox1.Checked ? "online" : "offline";

            Client client = new ClientBuilder()
                .WithName(name)
                .WithType(type)
                .Build();

            clientManager.AddClient(client);
            listView1.Items.Add(client.ToListViewItem()).Tag = client;
        }

        // Edit client
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                Client client = selectedItem.Tag as Client;

                string newName = textBox1.Text;
                string newType = checkBox1.Checked ? "online" : "offline";

                try
                {
                    clientManager.EditClient(client.Id, newName, newType);
                    selectedItem.SubItems[1].Text = newName;
                    selectedItem.SubItems[2].Text = newType;
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a client to edit.");
            }
        }

        // Remove client
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                Client client = selectedItem.Tag as Client;

                clientManager.RemoveClient(client);

                listView1.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a client to remove.");
            }
        }
    }
}
