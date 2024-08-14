using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void FmMain_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen Pen = new Pen(White,10);

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 550 , 90, 550 , 480);
            e.Graphics.DrawLine(Pen, 755, 90, 755, 480);
            e.Graphics.DrawLine(Pen, 400, 200, 900, 200);
            e.Graphics.DrawLine(Pen, 400, 350, 900, 350);


        }

        void Restart()
        {

            pb1.Image = Resources.question_mark_96;
            pb2.Image = Resources.question_mark_96;
            pb3.Image = Resources.question_mark_96;
            pb4.Image = Resources.question_mark_96;
            pb5.Image = Resources.question_mark_96;
            pb6.Image = Resources.question_mark_96;
            pb7.Image = Resources.question_mark_96;
            pb8.Image = Resources.question_mark_96;
            pb9.Image = Resources.question_mark_96;

            pb1.Tag = 0;
            pb2.Tag = 0;
            pb3.Tag = 0;
            pb4.Tag = 0;
            pb5.Tag = 0;
            pb6.Tag = 0;
            pb7.Tag = 0;
            pb8.Tag = 0;
            pb9.Tag = 0;

            lbWinner.Tag = 0;

            pb1.BackColor = Color.Black;
            pb2.BackColor = Color.Black;
            pb3.BackColor = Color.Black;
            pb4.BackColor = Color.Black;
            pb5.BackColor = Color.Black;
            pb6.BackColor = Color.Black;
            pb7.BackColor = Color.Black;
            pb8.BackColor = Color.Black;
            pb9.BackColor = Color.Black;


            lbPlayer.Text = "Player  1" ;
            lbWinner.Text = "In Progress";

        }

        bool IsGameOver()
        {
            return ((Convert.ToInt16(pb1.Tag) != 0) && (Convert.ToInt16(pb2.Tag) != 0) && (Convert.ToInt16(pb3.Tag) != 0) &&
                (Convert.ToInt16(pb4.Tag) != 0) && (Convert.ToInt16(pb5.Tag) != 0) && (Convert.ToInt16(pb6.Tag) != 0) &&
                (Convert.ToInt16(pb7.Tag) != 0) && (Convert.ToInt16(pb8.Tag) != 0) && (Convert.ToInt16(pb9.Tag) != 0));
        }

        void CheckWinner(short Index)
        {

            if (Convert.ToInt16(pb1.Tag) == Index && Convert.ToInt16(pb2.Tag) == Index &&
                Convert.ToInt16(pb3.Tag) == Index)
            {
                pb1.BackColor = Color.Green;
                pb2.BackColor = Color.Green;
                pb3.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;
            }

            if ((Convert.ToInt16(pb1.Tag) == Index && Convert.ToInt16(pb4.Tag) == Index &&
                Convert.ToInt16(pb7.Tag) == Index))
            {
                pb1.BackColor = Color.Green;
                pb4.BackColor = Color.Green;
                pb7.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;
            }

            if (Convert.ToInt16(pb2.Tag) == Index && Convert.ToInt16(pb5.Tag) == Index &&
                Convert.ToInt16(pb8.Tag) == Index)
            {
                pb2.BackColor = Color.Green;
                pb5.BackColor = Color.Green;
                pb8.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;
            }

            if (Convert.ToInt16(pb3.Tag) == Index && Convert.ToInt16(pb6.Tag) == Index &&
                Convert.ToInt16(pb9.Tag) == Index)
            {
                pb3.BackColor = Color.Green;
                pb6.BackColor = Color.Green;
                pb9.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;
            }

            if (Convert.ToInt16(pb1.Tag) == Index && Convert.ToInt16(pb5.Tag) == Index &&
                Convert.ToInt16(pb9.Tag) == Index)
            {
                pb1.BackColor = Color.Green;
                pb5.BackColor = Color.Green;
                pb9.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;
            }

            if (Convert.ToInt16(pb3.Tag) == Index && Convert.ToInt16(pb5.Tag) == Index &&
                Convert.ToInt16(pb7.Tag) == Index) {

                pb3.BackColor = Color.Green;
                pb5.BackColor = Color.Green;
                pb7.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;
            }

            if (Convert.ToInt16(pb4.Tag) == Index && Convert.ToInt16(pb5.Tag) == Index &&
                Convert.ToInt16(pb6.Tag) == Index)
            {
                pb4.BackColor = Color.Green;
                pb5.BackColor = Color.Green;
                pb6.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;
            }

            if (Convert.ToInt16(pb7.Tag) == Index && Convert.ToInt16(pb8.Tag) == Index &&
                Convert.ToInt16(pb9.Tag) == Index)
            {
                pb7.BackColor = Color.Green;
                pb8.BackColor = Color.Green;
                pb9.BackColor = Color.Green;
                lbWinner.Tag = Index;
                return;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Restart();
        }

        void UpdateGame(object sender)
        {

            if (Convert.ToInt16(((PictureBox)sender).Tag) == 1 || Convert.ToInt16(((PictureBox)sender).Tag) == 2)
                MessageBox.Show("Wrong Choice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (lbPlayer.Text == "Player  1")
                {
                    ((PictureBox)sender).Image = Resources.X;
                    ((PictureBox)sender).Tag = 1;

                    CheckWinner(1);

                    if (Convert.ToInt16(lbWinner.Tag) == 1)
                    {
                        lbWinner.Text = "Player  1";
                        lbPlayer.Text = "Game Over";
                        MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    lbPlayer.Text = "Player  2";


                }

                else
                {
                    ((PictureBox)sender).Image = Resources.O;
                    ((PictureBox)sender).Tag = 2;

                    CheckWinner(2);

                    if (Convert.ToInt16(lbWinner.Tag) == 2)
                    {
                        lbWinner.Text = "Player  2";
                        lbPlayer.Text = "Game Over";
                        MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    lbPlayer.Text = "Player  1";
                }
            }

            if (IsGameOver())
            {
                lbWinner.Text = "Draw";
                lbPlayer.Text = "Game Over";
                MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb3_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb4_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb5_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb6_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb7_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb8_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

        private void pb9_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }
    }
}
