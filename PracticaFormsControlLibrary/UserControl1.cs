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

        string[] horario_bar1 = { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
        string[] horario_bar2 = { "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00", "24:00", "00:00", "01:00", "02:00" };
        string[] horario_bar3 = { "09:00", "10:00", "11:00", "12:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
        string[] horario_bar4 = { "12:00", "13:00", "14:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00", "00:00", "24:00", "01:00", "02:00" };
        string[] horario_bar5 = { "23:00", "24:00", "00:00", "01:00", "02:00", "03:00", "04:00", "05:00" };
        string[] horario_bar6 = { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00" };

        const String bar1 = "Honest Greens";
        const String bar2 = "Bee Beer";
        const String bar3 = "Pez Tortilla";
        const String bar4 = "La Playa de Lavapiés";
        const String bar5 = "The Tower Irish Pub";
        const String bar6 = "Levadura Madre";


        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.maskedTextBox1.Mask = "00:00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hola" + maskedTextBox1.Text + "BAR" + comboBox1.SelectedItem);
           
            switch (comboBox1.SelectedItem)
            {
                case bar1:
                    comprobarDisponibilidad(horario_bar1);
                    break;
                case bar2:
                    comprobarDisponibilidad(horario_bar2);
                    break;
                case bar3:
                    comprobarDisponibilidad(horario_bar3);
                    break;
                case bar4:
                    comprobarDisponibilidad(horario_bar4);
                    break;
                case bar5:
                    comprobarDisponibilidad(horario_bar5);
                    break;
                case bar6:
                    comprobarDisponibilidad(horario_bar6);
                    break;
            }       

            void comprobarDisponibilidad(string[] listaHorarios)
            {

                System.Diagnostics.Debug.WriteLine("SACAR-" + maskedTextBox1.Text);

                /*if (maskedTextBox1.Text.Equals("  :"))
                {
                    MessageBox.Show("DEBE INTRODUCIR UNA HORA", "ERROR", MessageBoxButtons.OK);
                } else*/ if (listaHorarios.Contains(maskedTextBox1.Text))
                {
                    MessageBox.Show(text: "El bar '" + comboBox1.SelectedItem + "' se encuentra abierto", caption: "Disponibilidad", buttons: MessageBoxButtons.OK);
                } else
                {
                    MessageBox.Show("Bar cerrado", "Disponibilidad", MessageBoxButtons.OK);
                }            
            }
        }
             
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) && !maskedTextBox1.Text.Equals("  :"))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            this.maskedTextBox1.Text = this.maskedTextBox1.Text.PadRight(this.maskedTextBox1.Mask.Length, '0');
            this.maskedTextBox1.Text = this.maskedTextBox1.Text.PadLeft(this.maskedTextBox1.Mask.Length, '0');
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            this.maskedTextBox1.PromptChar = '_';
            this.maskedTextBox1.Text = this.maskedTextBox1.Text.Trim();
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            Int32 horas = Int32.Parse(maskedTextBox1.Text.Substring(0, 2));
            Int32 minutos = Int32.Parse(maskedTextBox1.Text.Substring(3, 2));

            if (horas > 24)
            {
                MessageBox.Show("No puede superar las 24 horas.", "ERROR", MessageBoxButtons.OKCancel);
                seleccionarHoras(maskedTextBox1);
            }

            if (minutos != 00)
            {
                MessageBox.Show("Solo podrán ser horas exactas.", "ERROR", MessageBoxButtons.OKCancel);
                seleccionarMinutos(maskedTextBox1);
            }

            void seleccionarHoras(MaskedTextBox mkt)
            {
                mkt.Focus();
                mkt.SelectionStart = 0;
                mkt.SelectionLength = 2;
            }

            void seleccionarMinutos(MaskedTextBox mkt)
            {
                mkt.Focus();
                mkt.SelectionStart = 3;
                mkt.SelectionLength = 2;
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) && !maskedTextBox1.Text.Equals("  :"))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
