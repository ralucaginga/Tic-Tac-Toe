using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xsi0
{
    public partial class Xsi0 : Form
    {
        bool turn = true; //X turn=true; false= 0 turn;
        int turn_count = 0;

        public Xsi0()
        {
            InitializeComponent();
        }

        private void despreJocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jocul tipic de X si 0.\n Autor: Ginga Raluca-Andreea\n Grupa: MI523");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else b.Text = "0";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            verifCastigator();
        }

        private void verifCastigator()
        {
            bool existaCastigator = false;

            //verificari pe linie
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                existaCastigator = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                existaCastigator = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                existaCastigator = true;

            //verificari pe coloana
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                existaCastigator = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                existaCastigator = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                existaCastigator = true;

            //verificari pe diagonala
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                existaCastigator = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                existaCastigator = true;

            if(existaCastigator)
            {
                disableButtons();
                String castigator = "";
                if (turn)
                    castigator = "0";
                else castigator = "X";
                MessageBox.Show(castigator + " a castigat!", "Yaaay!");
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Remiza!");
            }
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}
