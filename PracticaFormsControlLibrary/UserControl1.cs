using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaFormsControlLibrary
{
    public partial class UserControl1: UserControl
    {

        List<String> horario_bar1 = new List<String>()
        {
            "9:00", "10:00", "11:00", "12:00", "13:00", "16:00", "17:00", "18:00", "17:00"
        };

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for (var i = 0; i < horario_bar1.Count; i ++)
            //{
                if (maskedTextBox1.Text.Equals(horario_bar1))
                {
                    MessageBox.Show("Bar abierto", "Disponibilidad", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Bar cerrado", "Disponibilidad", MessageBoxButtons.OK);
                }
            //}
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "00:00";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
