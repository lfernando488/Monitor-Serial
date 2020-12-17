using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SerialPort serialcom = new SerialPort();

        string msg;

        public Form1()
        {
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select...";
            comboBox2.Text = "Select...";
            comboBox3.Text = "Select...";
            comboBox4.Text = "Select...";
            comboBox5.Text = "Select...";

            foreach (string str in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(str);
            
            }
            foreach(string str in Enum.GetNames(typeof(Parity)))
            {
                comboBox3.Items.Add(str);
            
            }

            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                comboBox5.Items.Add(str);

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {   button2.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button1.Enabled = true;
                    button3.Enabled = true;
                    serialcom.Close();
            }
            catch { 
                MessageBox.Show("A porta não pode serfechada", "Erro", MessageBoxButtons.OK); 
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes){
                this.Close();
            } 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialcom.IsOpen){
                serialcom.Close();
            }

            try
            {
                serialcom.PortName = comboBox1.Text;
                serialcom.BaudRate = Convert.ToInt32(comboBox2.Text);
                serialcom.Parity = (Parity)comboBox3.SelectedIndex;
                serialcom.DataBits = Convert.ToInt32(comboBox4.Text);
                serialcom.StopBits = (StopBits)comboBox5.SelectedIndex;

                serialcom.Open();

                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialcom.Write(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            msg = serialcom.ReadExisting();
            label6.Text = msg;
        }
    }
}
