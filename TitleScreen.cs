using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class titlescreen : Form
    {
        public titlescreen()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // grabs the speed of bullet, player, and firerate of the bombs. Array order is, {bullet speed, player speed, bomb firerate, alien color}
            string[] speeds = new string[4] {bulletSpeedInput.Text, playerSpeedInput.Text, firerateInput.Text, alienColorInput.Text};
            
            //create the game window, (speeds) gets sent to Form1 so it can access the data
            Form1 game = new Form1(speeds);

            //hide the title screen
            this.Hide();
            //display the game window
            game.ShowDialog();
            //close the title screen
            this.Close();
        }
    }
}
