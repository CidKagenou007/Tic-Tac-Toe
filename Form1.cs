using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        void ResetPictureBox(PictureBox pb)
        {

            pb.Image = Resources.question_mark_96;
            pb.BackColor = Color.Black;
            pb.Tag = 0;
        }

        void Restart()
        {

            ResetPictureBox(pb1);
            ResetPictureBox(pb2);
            ResetPictureBox(pb3);
            ResetPictureBox(pb4);
            ResetPictureBox(pb5);
            ResetPictureBox(pb6);
            ResetPictureBox(pb7);
            ResetPictureBox(pb8);
            ResetPictureBox(pb9);


            lbWinner.Tag = 0;


            lbPlayer.Text = "Player  1" ;
            lbWinner.Text = "In Progress";

        }

        bool IsGameOver()
        {
            return ((Convert.ToInt16(pb1.Tag) != 0) && (Convert.ToInt16(pb2.Tag) != 0) && (Convert.ToInt16(pb3.Tag) != 0) &&
                (Convert.ToInt16(pb4.Tag) != 0) && (Convert.ToInt16(pb5.Tag) != 0) && (Convert.ToInt16(pb6.Tag) != 0) &&
                (Convert.ToInt16(pb7.Tag) != 0) && (Convert.ToInt16(pb8.Tag) != 0) && (Convert.ToInt16(pb9.Tag) != 0));
        }

        bool CheckValue(PictureBox pb1 , PictureBox pb2 , PictureBox pb3)
        {
            if (Convert.ToInt16(pb1.Tag) != 0 && Convert.ToInt16(pb1.Tag) ==
                Convert.ToInt16(pb2.Tag) && Convert.ToInt16(pb2.Tag) == Convert.ToInt16(pb3.Tag) {

                pb1.BackColor = Color.Green;
                pb2.BackColor = Color.Green;
                pb3.BackColor = Color.Green;
                

                lbWinner.Text = pb1.Tag.ToString();

                return true;
                

            }

            return false;
        }

        void CheckWinner()
        {

            if (CheckValue(pb1 , pb2 , pb3))
                return;

            if (CheckValue(pb1, pb4, pb7))
                return;


            if (CheckValue(pb2, pb5, pb8))
                return;

            if (CheckValue(pb3, pb6, pb9))
                return;

            if (CheckValue(pb1, pb5, pb9))
                return;

            if (CheckValue(pb3, pb5, pb7))
                return;

            if (CheckValue(pb4, pb5, pb6))
                return;

            if (CheckValue(pb7, pb8, pb9))
                return;
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

                    CheckWinner();

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

                    CheckWinner();

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

        private void pb_Click(object sender, EventArgs e)
        {
            UpdateGame(sender);
        }

    }
}
