using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;

namespace Slot_Machine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button1.Enabled = false;
            button5.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            button8.Enabled = false;
        }
        int m;
        int a;
        int b;
        int c;
        int credit = 50;
        int bet = 5;
        
		
        private void Button1_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            button8.Enabled = true;
            timer1.Enabled = true;
            timer1.Interval = 50;
        }

      
   

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m = m + 10;
            if (m < 100)
            {

                a = (int)(Conversion.Int(1 + VBMath.Rnd() * 3));

                b = (int)(Conversion.Int(1 + VBMath.Rnd() * 3));

                c = (int)(Conversion.Int(1 + VBMath.Rnd() * 3));

                switch (a)
                {
                    case 1:
                        PictureBox1.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_watermelon.png");
                        break;
                    case 2:
                        PictureBox1.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_grapes.png");
                        break;
                    case 3:
                        PictureBox1.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_sedmica.bmp");
                        break;

                }

                switch (b)
                {
                    case 1:
                        PictureBox2.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_watermelon.png");
                        break;
                    case 2:
                        PictureBox2.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_grapes.png");
                        break;
                    case 3:
                        PictureBox2.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_sedmica.bmp");
                        break;

                }
                switch (c)
                {
                    case 1:
                        PictureBox3.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_watermelon.png");
                        break;
                    case 2:
                        PictureBox3.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_grapes.png");
                        break;
                    case 3:
                        PictureBox3.Image = Image.FromFile("C:\\Users\\Mario\\Desktop\\SlotMachine\\rsz_sedmica.bmp");
                        break;

                }

            }
            else
            {
                timer1.Enabled = false;
                m = 0;
                if ((a == b) && (a == c))
                {
                    lblMsg.Text = "Jackpot! You won " + (2*bet).ToString()+" $!!!";
                    credit = credit + bet;
                    infolbl.Text = "CREDIT: " + credit.ToString() + " $";

                }
                else
                {
                    lblMsg.Text = "No luck, try again";
                    credit = credit - bet;
                    infolbl.Text = "CREDIT: " + credit.ToString() + " $";
                    if (credit < bet)
                    {
                        Button1.Enabled = false;
                        
                    }
                    if (credit == 0)
                    {
                        button2.Enabled = true;
                        button8.Enabled = false;
                        button5.Enabled = false;
                       
                    }
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            credit = 50;
            infolbl.Text = "CREDIT: "+"50 $";
            
            button3.Enabled = true;
            
            button9.Enabled = true;
            button2.Enabled = false;
            


           


        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            credit++;
            infolbl.Text = "CREDIT: " + credit.ToString() + " $";
            button9.Enabled = true;
            button4.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((credit > 0) && (bet<credit)) credit--;
            if (credit >= 0)
                infolbl.Text = "CREDIT: " + credit.ToString() + " $";
            if (credit == 0)
            {
                Button1.Enabled = false;
                button9.Enabled = false;
            }
            if (credit==5) button4.Enabled = false;
             
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((bet<=credit)&&(bet>0)) Button1.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            betlbl.Text = "BET: " + bet.ToString() + " $";

            
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bet > 0) bet--;
            if (bet <= credit) Button1.Enabled = true;
            betlbl.Text = "BET: " + bet.ToString() + " $";
            if (bet == 0)
            {
                Button1.Enabled = false;
                button7.Enabled = false;
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bet < credit)
            {
                Button1.Enabled = true;
                bet++;
                betlbl.Text = "BET: " + bet.ToString() + " $";
            }
            button7.Enabled = true;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button9.Enabled = false;
            button5.Enabled = true;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result1= MessageBox.Show("Thank you for playing!\n Would you like to play again?", "End of game", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Button1.Enabled = false;
                button5.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                button8.Enabled = false;
                button2.Enabled = true;
                credit = 50;
                bet = 5;
                infolbl.Text = "CREDIT: ";
                betlbl.Text = "BET: ";
                lblMsg.Text = "";
            }
            else Application.Exit();

        }
    }
}